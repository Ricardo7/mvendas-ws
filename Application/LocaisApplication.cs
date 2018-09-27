using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Repository;
using MongoDB.Driver;

namespace Application
{
    public class LocaisApplication
    {
        private LocaisRepository dbLocais;

        public LocaisApplication()
        {
            dbLocais = new LocaisRepository();
        }

        public List<Pais> GetListaPaises()
        {
            try
            {
                return dbLocais.GetListaPaises();
            }
            catch (Exception)
            {
                List<Pais> ListaVazio = new List<Pais>();

                return ListaVazio;
            }
        }

        public List<Estado> GetListaEstados(Pais pais)
        {
            try
            {
                return dbLocais.GetListaEstados(pais);
            }
            catch (Exception)
            {
                List<Estado> ListaVazio = new List<Estado>();

                return ListaVazio;
            }
        }

        public List<Cidade> GetListaCidades()
        {
            try
            {
                return dbLocais.GetListaCidades();
            }
            catch (Exception)
            {
                List<Cidade> ListaVazio = new List<Cidade>();

                return ListaVazio;
            }
        }

    }
}
