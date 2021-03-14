using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProdutosApi.Models;
using ProdutosApi.Services;

namespace ProdutosApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoServices _services;

        public ProdutoController(ProdutoServices services)
        {
            _services = services;
        }

        [HttpGet]
        public ActionResult<List<Produto>> Listar()=>_services.ListarProdutos();

        [HttpGet("{id}")]
        public ActionResult<Produto> ExibirProduto(string id)=> _services.ExibirProduto(id);
        [HttpPost]
        public ActionResult<Produto> Salvar(Produto produto)=> _services.Salvar(produto);

        [HttpPut]
        public ActionResult<Produto> Atualizar(string id,Produto produto)=>
        _services.AtualizarProduto(id,produto);

        [HttpDelete]
        public ActionResult<Produto> Delete(string id)=> _services.RemoverProduto(id);
    }
}