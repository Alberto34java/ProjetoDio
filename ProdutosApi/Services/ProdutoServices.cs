using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using ProdutosApi.Models;

namespace ProdutosApi.Services
{
    public class ProdutoServices
    {
         private readonly IMongoCollection<Produto> _produtos;

         public ProdutoServices(IConfiguration conf)
         {
              var cli=new MongoClient(conf.GetConnectionString("Conexao"));
            var db= cli.GetDatabase("LojaDB");
            _produtos = db.GetCollection<Produto>("Produtos");
         }

         public List<Produto> ListarProdutos()=> _produtos.Find( Produto => true).ToList();
         
             //_produtos.Find( Produto => true).ToList();
         
         //=> _produtos.Find( Produto => true).ToList();
        //metodo para mostrar Novela Selecionada 
        public Produto ExibirProduto(string id)=> _produtos.Find(produto=> produto.Id == id).FirstOrDefault();
        
        //=> _produtos.Find(produto=> produto.Id == id).FirstOrDefault();

        //metodo de salvar 
        public Produto Salvar(Produto produto)
        {
            _produtos.InsertOne(produto);
            return produto;
        }

        //metodo de alteração só para 
        public void AtualizarProduto(string id, Produto p)
        {
            _produtos.ReplaceOne(produto=> produto.Id == id, p);
            
        }

        //Metodo de Remoção
        public void RemoverProduto(string id)
        {
            //var p=_produtos.Find(produto => produto.Id == id).FirstOrDefault();
            _produtos.DeleteOne(produto => produto.Id == id);
            //return p;
        } 

        public void Remover(Produto p)
        {
           _produtos.DeleteOne(produto => produto.Id == produto.Id);
        }
    }
}