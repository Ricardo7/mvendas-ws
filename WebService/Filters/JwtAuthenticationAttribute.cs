using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using WebService.Controllers;

namespace WebService.Filters
{
    public class JwtAuthenticationAttribute : Attribute, IAuthenticationFilter
    {
        public string Realm { get; set; }
        public bool AllowMultiple => false;

        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            
            var request = context.Request;
            var authorization = request.Headers.Authorization;

            if (authorization == null || authorization.Scheme != "Bearer")
            {
                return;
            }

            if (string.IsNullOrEmpty(authorization.Parameter))
            {
                context.ErrorResult = new AuthenticationFailureResult("Missing Jwt Token", request);
                return;
            }

            var token = authorization.Parameter;
            var principal = await AuthenticateJwtToken(token);

            if (principal == null)
            {
                context.ErrorResult = new AuthenticationFailureResult("Invalid token", request);
                RetornoController retorno = new RetornoController();
                RetornoController.MontaRetornoUsuario(404,"ERROR","",null);
            }
            else
            {
                context.Principal = principal;
            }
        }

        private static bool ValidateToken(string token, out string userID)
        {
            
            userID = null;

            var simplePrinciple = JwtManager.GetPrincipal(token);
            ClaimsIdentity identity = simplePrinciple?.Identity as ClaimsIdentity;
            
            if (identity == null)
            {
                return false;
            }

            if (!identity.IsAuthenticated)
            {
                return false;
            }

            var usernameClaim = identity.FindFirst(ClaimTypes.Name);
                        
            userID = usernameClaim?.Value;
            
            if (string.IsNullOrEmpty(userID))
            {

                return false;
            }

            // More validate to check whether username exists in system

            return true;
        }

        public string GetUserIdToken(string token)
        {

            string userID = null;
            try
            {
                var simplePrinciple = JwtManager.GetPrincipal(token);
                ClaimsIdentity identity = simplePrinciple?.Identity as ClaimsIdentity;

                if (identity == null)
                {
                    throw new Exception("Token inválido");
                }

                if (!identity.IsAuthenticated)
                {
                    throw new Exception("Token inválido");
                }

                var usernameClaim = identity.FindFirst(ClaimTypes.Name);

                userID = usernameClaim?.Value;

                if (string.IsNullOrEmpty(userID))
                {

                    throw new Exception("Token inválido, ID do usuário não encontrado.");
                }

                // More validate to check whether username exists in system
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return userID;
        }

        protected Task<IPrincipal> AuthenticateJwtToken(string token)
        {
            string userID;
            
            if (ValidateToken(token, out userID))
            {
                // based on username to get more information from database in order to build local identity
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userID)
                    // Add more claims if needed: Roles, ...
                };

                var identity = new ClaimsIdentity(claims, "Jwt");
                IPrincipal user = new ClaimsPrincipal(identity);

                return Task.FromResult(user);
            }

            return Task.FromResult<IPrincipal>(null);
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            
            Challenge(context);
            return Task.FromResult(0);
        }

        private void Challenge(HttpAuthenticationChallengeContext context)
        {
            string parameter = null;
            
            if (!string.IsNullOrEmpty(Realm)) { 
                parameter = "realm=\"" + Realm + "\"";
            }

            context.ChallengeWith("Bearer", parameter);
        }
    }
}
