using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using Domain;
using Repository;
using Application;

namespace Test {
    public class PopulaLocais {

        private LocaisRepository dbLocais;

        public void Popula() {
            dbLocais = new LocaisRepository();

            Pais brasil = new Pais {
                Descricao = "Brasil",
                Sigla = "BR"
            };

            Estado sP = new Estado {
                Descricao = "São Paulo",
                Sigla = "SP",
                Pais_Estado = brasil
            };

            Estado rS = new Estado {
                Descricao = "Rio Grande do Sul",
                Sigla = "RS",
                Pais_Estado = brasil
            };

            Cidade caxias = new Cidade {
                Descricao = "Caxias do Sul",
                Sigla = "CXS",
                Estado_Cidade = rS
            };

            Cidade poa = new Cidade {
                Descricao = "Porto Alegre",
                Sigla = "POA",
                Estado_Cidade = rS
            };

            Cidade saoPaulo = new Cidade {
                Descricao = "São Paulo",
                Sigla = "SPO",
                Estado_Cidade = sP
            };

            Cidade campinas = new Cidade {
                Descricao = "Campinas",
                Sigla = "CMP",
                Estado_Cidade = sP
            };

            dbLocais.AddPais(brasil);
            dbLocais.AddEstado(rS);
            dbLocais.AddEstado(sP);
            dbLocais.AddCidade(caxias);
            dbLocais.AddCidade(poa);
            dbLocais.AddCidade(saoPaulo);
            dbLocais.AddCidade(campinas);

        }

    }
}
