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
        public ActionResult<List<Produto>> Listar()
        {
            return _services.ListarProdutos();
        }
        //=>_services.ListarProdutos();

        [HttpGet("{id:length(24)}", Name = "ExibirProduto")]
        public ActionResult<Produto> ExibirProduto(string id)
        {
           var p=_services.ExibirProduto(id);

           if(p == null)
           {
               return NotFound();
           }   

           return p;     
        }
        //=> _services.ExibirProduto(id);
        [HttpPost]
        public ActionResult<Produto> Salvar(Produto produto)
        {
            _services.Salvar(produto);

            return CreatedAtRoute("ExibirProduto", new { id = produto.Id.ToString() }, produto);
        }
        //=> _services.Salvar(produto);

        [HttpPut("{id:length(24)}")]
        public ActionResult<Produto> Atualizar(string id,Produto produto)
        {
             var p= _services.ExibirProduto(id);

             if(p == null)
             {
                 return NotFound();
             }

             _services.AtualizarProduto(id,produto);

             return NoContent();
        }
        //=>_services.AtualizarProduto(id,produto);

        [HttpDelete("{id:length(24)}")]
        public ActionResult<Produto> Delete(string id)
        {
            var p= _services.ExibirProduto(id);

            if(p == null)
            {
                return NotFound();

            }
            _services.RemoverProduto(id);

            return NoContent();
        }
    }
}