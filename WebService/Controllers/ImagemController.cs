﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Application;
using Domain;
using System.Threading.Tasks;
using WebService.Filters;

namespace WebService.Controllers {
    public class ImagemController : ApiController {

        public ImagemApplication imagemApplication;

        public ImagemController() {
            imagemApplication = new ImagemApplication();
        }

        [JwtAuthentication]
        [HttpPost]
        [Route("api/Imagem/AddImagem")]
        public ImagemDTO AddImagem(Imagem imagem) {
            Imagem imagemCadastrado = null;
            try
            {
                imagemCadastrado = imagemApplication.AddImagem(imagem);
            }catch (Exception ex)
            {
                return RetornoController.MontaRetornoImagem(200, "ERROR", ex.Message, null);
            }

            if (imagemCadastrado != null) {
                return RetornoController.MontaRetornoImagem(200, "SUCCESS", "", imagemCadastrado);
            } else {
                return RetornoController.MontaRetornoImagem(200, "ERROR", "", null);
            }

        }

        [JwtAuthentication]
        [HttpPut]
        [Route("api/Imagem/EditaImagem")]
        public ImagemDTO Editaimagem(Imagem imagem) {
            Imagem imagemCadastrado;

            try
            {
                imagemCadastrado = imagemApplication.EditarImagem(imagem);
            }
            catch (Exception ex)
            {
                return RetornoController.MontaRetornoImagem(200, "ERROR", ex.Message, null);
            }

            if (imagemCadastrado != null) {
                return RetornoController.MontaRetornoImagem(200, "SUCCESS", "", imagemCadastrado);
            } else {
                return RetornoController.MontaRetornoImagem(200, "ERROR", "", null);
            }

        }

        [JwtAuthentication]
        [HttpGet]
        [Route("api/Imagem/GetImagem")]
        public ImagemDTO GetImagem(string id) {

            Imagem imagemRetorno = imagemApplication.GetImagem(id);

            if (imagemRetorno != null) {
                return RetornoController.MontaRetornoImagem(200, "SUCCESS", "", imagemRetorno);
            } else {
                return RetornoController.MontaRetornoImagem(200, "ERROR", "", null);
            }

        }

        [JwtAuthentication]
        [HttpGet]
        [Route("api/Imagem/GetListaImagens")]
        public ListaImagensDTO GetListaImagens() {
            List<Imagem> ListaTemp = imagemApplication.GetListaImagens();

            if (ListaTemp.Count() != 0) {
                return RetornoController.MontaRetornoListaImagens(200, "SUCCESS", "", ListaTemp);
            } else {
                return RetornoController.MontaRetornoListaImagens(200, "ERROR", "", null);
            }

        }

        [JwtAuthentication]
        [HttpGet]
        [Route("api/Imagem/GetListaImagensAtualizadas")]
        public ListaImagensDTO GetListaImagensAtualizados(string dataAt) {
            List<Imagem> ListaTemp = imagemApplication.GetListaImagensAtualizados(dataAt);

            if (ListaTemp.Count() != 0) {

                return RetornoController.MontaRetornoListaImagens(200, "SUCCESS", "", ListaTemp);
            } else {
                return RetornoController.MontaRetornoListaImagens(200, "ERROR", "", null);
            }

        }

        [JwtAuthentication]
        [HttpGet]
        [Route("api/Imagem/GetListaImagensProduto")]
        public ListaImagensDTO GetListaImagensProduto(string produtoID) {
            List<Imagem> ListaTemp = imagemApplication.GetListaImagensProduto(produtoID);

            if (ListaTemp.Count() != 0) {

                return RetornoController.MontaRetornoListaImagens(200, "SUCCESS", "", ListaTemp);
            } else {
                return RetornoController.MontaRetornoListaImagens(200, "ERROR", "", null);
            }

        }

        [JwtAuthentication]
        [HttpDelete]
        [Route("api/Imagem/RemoveImagem")]
        public ImagemDTO RemoveImagem(string id) {

            bool executou = imagemApplication.RemoveImagem(id);

            if (executou != false) {
                return RetornoController.MontaRetornoImagem(200, "SUCCESS", "", null);
            } else {
                return RetornoController.MontaRetornoImagem(200, "ERROR", "", null);
            }

        }
        

    }
}
