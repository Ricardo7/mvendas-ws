using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Domain;
using MongoDB.Driver;

namespace Application {
    public class AtividadeApplication {
        private AtividadeRepository dbAtividade;
        private UsuarioRepository dbUsuario;

        public AtividadeApplication() {
            dbAtividade = new AtividadeRepository();
            dbUsuario = new UsuarioRepository();
        }

        public Atividade GetAtividade(string ID) {
            
            try {
                return dbAtividade.ConsultaAtividade(ID);
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public List<Atividade> GetListaAtividades(string UsuarioID, int origem)
        {
            Usuario usuario = dbUsuario.ConsultaUsuarioID(UsuarioID);
            if (usuario == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            List<Atividade> atividades = null;
            try {

                atividades = new List<Atividade>();
                //Testa se é usuário Adminstrador(1) se for retorna todos os dados, senão retorna somente os dados relacionados ao usuário.
                if (usuario.Tipo == 1 && origem == 1)
                {
                    atividades = dbAtividade.GetListaAtividadesAdm();
                }
                else
                {
                    atividades = dbAtividade.GetListaAtividades(UsuarioID);
                }
               
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }

            return atividades;
        }

        public List<Atividade> GetListaAtividadesAtualizados(string data, string UsuarioID, int origem)
        {
            Usuario usuario = dbUsuario.ConsultaUsuarioID(UsuarioID);
            if (usuario == null)
            {
                throw new Exception("Usuário não encontrado");
            }
           
            List<Atividade> atividades = null;
            try
            {

                atividades = new List<Atividade>();
                //Testa se é usuário Adminstrador(1) se for retorna todos os dados, senão retorna somente os dados relacionados ao usuário.
                if (usuario.Tipo == 1 && origem == 1)
                {
                    atividades = dbAtividade.GetListaAtividadesAtualizadasAdm(data);
                }
                else
                {
                    atividades = dbAtividade.GetListaAtividadesAtualizadas(data, UsuarioID);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return atividades;
        }

        public List<Atividade> GetListaAtividadesUsuario(string usuarioID) {
            try {
                return dbAtividade.GetListaAtividadesUsuario(usuarioID);
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Atividade> GetListaAtividadesCliente(string clienteID) {
            try {
                return dbAtividade.GetListaAtividadesCliente(clienteID);
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /**
         * Retora todos os dados para o usuário solicitado, não testa se é Adm ou não pois este método é utilizado pelo
         * portal Web como filtro e neste caso, mesmo sendo usuário Adm, vai ver só as informações do usuário solicitado.
         * 
         **/
        public List<Atividade> GetListaAtividadesClienteCheckin(string UsuarioID, string DataIni, string DataFim)
        {
            
                Usuario usuario = dbUsuario.ConsultaUsuarioID(UsuarioID);
                if (usuario == null)
                {
                    throw new Exception("Usuário não encontrado");
                }
                try
            {
                return dbAtividade.GetListaAtividadesClienteCheckin(UsuarioID, DataIni, DataFim);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Atividade> GetListaAtividadesClienteUsuario(string clienteID, string usuarioID) {
            try {
                return dbAtividade.GetListaAtividadesClienteUsuario(clienteID, usuarioID);
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Atividade AddAtividade(Atividade atividade) {
            Atividade consultaExiste;
            try {
                consultaExiste = dbAtividade.ConsultaAtividade(atividade.ID);

                if (consultaExiste == null) {
                    Atividade cadastrado = dbAtividade.AddAtividade(atividade);
                    return cadastrado;

                } else {
                    return null;
                }

            } catch (Exception) {
                return null;
            }
        }

        public Atividade EditarAtividade(Atividade atividade) {
            Atividade consultaExiste;
            try {
                consultaExiste = dbAtividade.ConsultaAtividade(atividade.ID);

                if (consultaExiste == null) {
                    Atividade editado = dbAtividade.EditarAtividade(atividade);
                    return editado;

                } else {
                    return null;
                }

            } catch (Exception) {
                return null;
            }
        }

        public bool RemoveAtividade(string ID) {
            Atividade consultaExiste;
            try {
                consultaExiste = dbAtividade.ConsultaAtividade(ID);

                if (consultaExiste != null) {
 
                    return dbAtividade.RemoveAtividade(ID);

                } else {
                    return false;
                }

            } catch (Exception) {
                return false;
            }
        }
    }
}
