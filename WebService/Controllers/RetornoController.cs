using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebService.Controllers
{
    public class RetornoController
    {
        /**
         * Monta o objeto Json padrão de retorno da API
         * 
         */
        public static object MontaRetorno(int Cod, String Status, String Message, Object Data) 
        {
            return new
            {
                cod = Cod,
                status = Status,
                message = Message,
                data = Data
            };
        }
    }
}