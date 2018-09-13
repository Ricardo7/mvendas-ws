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
                ID = 1,
                Descricao = "Brasil",
                Sigla = "BR"
            };

            Estado sP = new Estado {
                ID = 1,
                Descricao = "São Paulo",
                Sigla = "SP",
                Pais_Estado = brasil
            };

            Estado rS = new Estado {
                ID = 2,
                Descricao = "Rio Grande do Sul",
                Sigla = "RS",
                Pais_Estado = brasil
            };

            Cidade caxias = new Cidade {
                ID = 1,
                Descricao = "Caxias do Sul",
                Sigla = "CXS",
                Estado_Cidade = rS
            };

            Cidade poa = new Cidade {
                ID = 2,
                Descricao = "Porto Alegre",
                Sigla = "POA",
                Estado_Cidade = rS
            };

            Cidade saoPaulo = new Cidade {
                ID = 3,
                Descricao = "São Paulo",
                Sigla = "SPO",
                Estado_Cidade = sP
            };

            Cidade campinas = new Cidade {
                ID = 4,
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
