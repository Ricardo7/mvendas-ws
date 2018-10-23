using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Domain;
using MongoDB.Driver;

namespace Application {
    public class ImagemApplication {
        private ImagemRepository dbImagem;

        public ImagemApplication() {
            dbImagem = new ImagemRepository();
        }

        public Imagem GetImagem(string ID) {
            try {
                return dbImagem.ConsultaImagem(ID);
            } catch (Exception) {
                return null;
            }
        }

        public List<Imagem> GetListaImagens() {
            try {
                return dbImagem.GetListaImagens();
            } catch (Exception) {
                List<Imagem> ListaImagensvazio = new List<Imagem>();

                return ListaImagensvazio;
            }
        }

        public List<Imagem> GetListaImagensAtualizados(string data) {
            try {
                return dbImagem.GetListaImagensAtualizados(data);
            } catch (Exception) {
                List<Imagem> ListaImagensvazio = new List<Imagem>();

                return ListaImagensvazio;
            }
        }

        public List<Imagem> GetListaImagensProduto(string produtoID) {
            try {
                return dbImagem.GetListaImagensProduto(produtoID);
            } catch (Exception) {
                List<Imagem> ListaImagensvazio = new List<Imagem>();

                return ListaImagensvazio;
            }
        }

        public Imagem AddImagem(Imagem imagem) {
            try {

                Imagem cadastrado = dbImagem.AddImagem(imagem);
                return cadastrado;

            } catch (Exception) {
                return null;
            }
        }

        public Imagem EditarImagem(Imagem imagem) {
            Imagem consultaExiste;
            try {
                consultaExiste = dbImagem.ConsultaImagem(imagem.ID);

                if (consultaExiste == null) {
                    Imagem editado = dbImagem.EditarImagem(imagem);
                    return editado;

                } else {
                    return null;
                }

            } catch (Exception) {
                return null;
            }
        }

    }
}
