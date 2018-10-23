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

        public AtividadeApplication() {
            dbAtividade = new AtividadeRepository();
        }

        public Atividade GetAtividade(string ID) {
            try {
                return dbAtividade.ConsultaAtividade(ID);
            } catch (Exception) {
                return null;
            }
        }

        public List<Atividade> GetListaAtividades() {
            try {
                return dbAtividade.GetListaAtividades();
            } catch (Exception) {
                List<Atividade> ListaAtividadesvazio = new List<Atividade>();

                return ListaAtividadesvazio;
            }
        }

        public List<Atividade> GetListaAtividadesAtualizados(string data) {
            try {
                return dbAtividade.GetListaAtividadesAtualizadas(data);
            } catch (Exception) {
                List<Atividade> ListaAtividadesvazio = new List<Atividade>();

                return ListaAtividadesvazio;
            }
        }

        public List<Atividade> GetListaAtividadesUsuario(string usuarioID) {
            try {
                return dbAtividade.GetListaAtividadesUsuario(usuarioID);
            } catch (Exception) {
                List<Atividade> ListaAtividadesvazio = new List<Atividade>();

                return ListaAtividadesvazio;
            }
        }

        public List<Atividade> GetListaAtividadesCliente(string clienteID) {
            try {
                return dbAtividade.GetListaAtividadesCliente(clienteID);
            } catch (Exception) {
                List<Atividade> ListaAtividadesvazio = new List<Atividade>();

                return ListaAtividadesvazio;
            }
        }

        public List<Atividade> GetListaAtividadesClienteUsuario(string clienteID, string usuarioID) {
            try {
                return dbAtividade.GetListaAtividadesClienteUsuario(clienteID, usuarioID);
            } catch (Exception) {
                List<Atividade> ListaAtividadesvazio = new List<Atividade>();

                return ListaAtividadesvazio;
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
