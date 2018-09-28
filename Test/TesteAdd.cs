using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Test {
    public class TesteAdd {
        private AddTeste db;

        public void Add() {
            db = new AddTeste();

            Meta meta = new Meta {
                Estimado = 231321,
                Realizado = 132456
            };
            db.AddMeta(meta);

            Produto produto = new Produto {
                ID = "asd45as4das",
                Cod = "21454",
                Descricao = "Produto Tal",
                Observacao = "Produto de uso Tal",
                DtAtualizacao = "2018-01-01 00:00:00",
                DtCadastro = "2018-01-01 00:00:00",                
            };

            ItemTabelaPreco itemTabelaPreco = new ItemTabelaPreco {
                MaxDesconto = 15,
                ProdutoTabelaPreco = produto,
                VlrUnitario = 25
            };
            db.AddItemTabelaPreco(itemTabelaPreco);

            List<ItemTabelaPreco> listaItemTabelaPrecos = new List<ItemTabelaPreco>();
            listaItemTabelaPrecos.Add(itemTabelaPreco);

            TabelaPrecos tabelaPrecos = new TabelaPrecos {
                Cod = "13213213",
                Descricao = "Tabela de Teste",
                ItensTabelaPrecos = listaItemTabelaPrecos
            };

            db.AddTabelaPrecos(tabelaPrecos);

            CondicaoPagamento condicaoPagamento = new CondicaoPagamento() {
                Cod = "132121",
                Descricao = "Descricao da condicao",
                DescAcr = 14
                
            };

            db.AddCondicaoPagamento(condicaoPagamento);

            ItemPedido itemPedido = new ItemPedido() {
                DataAtualizacao = "2018-01-01 00:00:00",
                DataCriacao = "2018-01-01 00:00:00",
                VlrDesconto = 5,
                VlrUnitario = 56,
                VlrTotal = 554,
                Quantidade = 10,
                ProdutoPedido = produto
            };
            db.AddItemPedido(itemPedido);

            List<ItemPedido> listaItensPedido = new List<ItemPedido>();
            listaItensPedido.Add(itemPedido);

            Cliente cliente = new Cliente() {
               
            };

            Pedido pedido = new Pedido() {
                CondicaoPagamentoPedido = condicaoPagamento,
                DataAtualizacao = "2018-01-01 00:00:00",
                DataCriacao = "2018-01-01 00:00:00",
                Situacao = 1,
                ListaItemPedido = listaItensPedido,
                TabelaPrecosPedido = tabelaPrecos,
                ClientePedido = cliente

            };
            db.AddPedido(pedido);

        }
    }
}
