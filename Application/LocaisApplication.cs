using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Repository;
using MongoDB.Driver;

namespace Application {
    public class LocaisApplication {
        private LocaisRepository dbLocais;

        public LocaisApplication() {
            dbLocais = new LocaisRepository();
        }

        public Pais GetPais(string ID) {
            try {
                return dbLocais.GetPais(ID);
            } catch (Exception) {
                Pais PaisVazio = new Pais();

                return PaisVazio;
            }
        }

        public List<Pais> GetListaPaises() {
            try {
                return dbLocais.GetListaPaises();
            } catch (Exception) {
                List<Pais> ListaVazio = new List<Pais>();

                return ListaVazio;
            }
        }

        public List<Pais> GetListaPaisesAtualizados(string data) {
            try {
                return dbLocais.GetListaPaisesAtualizados(data);
            } catch (Exception) {
                List<Pais> ListaVazio = new List<Pais>();

                return ListaVazio;
            }
        }

        public Estado GetEstado(string ID) {
            try {
                return dbLocais.GetEstado(ID);
            } catch (Exception) {
                Estado EstadoVazio = new Estado();

                return EstadoVazio;
            }
        }

        public List<Estado> GetListaEstados(String siglaPais) {
            try {
                return dbLocais.GetListaEstados(siglaPais);
            } catch (Exception) {
                List<Estado> ListaVazio = new List<Estado>();

                return ListaVazio;
            }
        }

        public List<Estado> GetListaEstadosAtualizados(string data) {
            try {
                return dbLocais.GetListaEstadosAtualizados(data);
            } catch (Exception) {
                List<Estado> ListaVazio = new List<Estado>();

                return ListaVazio;
            }
        }

        public Cidade GetCidade(string ID) {
            try {
                return dbLocais.GetCidade(ID);
            } catch (Exception) {
                Cidade CidadeVazio = new Cidade();

                return CidadeVazio;
            }
        }

        public List<Cidade> GetListaCidades(String siglaEstado) {
            try {
                return dbLocais.GetListaCidades(siglaEstado);
            } catch (Exception) {
                List<Cidade> ListaVazio = new List<Cidade>();

                return ListaVazio;
            }
        }

        public List<Cidade> GetListaCidadesAtualizadas(string data) {
            try {
                return dbLocais.GetListaCidadesAtualizados(data);
            } catch (Exception) {
                List<Cidade> ListaVazio = new List<Cidade>();

                return ListaVazio;
            }
        }

        public Pais AddPais(Pais pais) {
            Pais consultaExiste = new Pais(); ;
            try {
                consultaExiste = new Pais();
                //consultaExiste = dbLocais.GetPais(pais.ID);

                if (consultaExiste == null) {
                    Pais cadastrado = dbLocais.AddPais(pais);

                    return cadastrado;
                } else {
                    return consultaExiste;
                }
                
            } catch (Exception) {
                return consultaExiste;
            }
        }

        public Estado AddEstado(Estado estado) {
            Estado consultaExiste = new Estado(); ;
            try {
                consultaExiste = new Estado();
                //consultaExiste = dbLocais.GetPais(pais.ID);

                if (consultaExiste == null) {
                    Estado cadastrado = dbLocais.AddEstado(estado);

                    return cadastrado;
                } else {
                    return consultaExiste;
                }

            } catch (Exception) {
                return consultaExiste;
            }
        }

        public Cidade AddCidade(Cidade cidade) {
            Cidade consultaExiste = new Cidade(); ;
            try {
                consultaExiste = new Cidade();
                //consultaExiste = dbLocais.GetPais(pais.ID);

                if (consultaExiste == null) {
                    Cidade cadastrado = dbLocais.AddCidade(cidade);

                    return cadastrado;
                } else {
                    return consultaExiste;
                }

            } catch (Exception) {
                return consultaExiste;
            }
        }

    }
}
