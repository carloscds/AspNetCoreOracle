using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using WebAPIOracle.Servico;
using WebAPIOracle.Entidades;
using Dapper;
using System.Net;
using System.Net.Http;

namespace WebAPIOracle.Controllers
{
    //[Authorize("Bearer")]
    [Route("api/cliente")]
    public class ClienteController : Controller
    {
        private DapperContexto _contexto;

        public ClienteController(DapperContexto contexto)
        {
            _contexto = contexto;
        }
        // GET: Cliente
        public List<Cliente> Get()
        {
            try
            {
                return _contexto.ConexaoOracle().Query<Cliente>("select clienteid,nome from cliente").ToList();
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                Response.WriteAsync(ex.Message);
                return null;
            }
        }

        [HttpGet]
        [Route("GetID")]
        public Cliente GetID(int id)
        {
            try
            {
                var ret = _contexto.ConexaoOracle().QueryAsync<Cliente>("Select CLIENTEID, NOME from CLIENTE where CLIENTEID = :CLIENTEID",
                    new Dictionary<string, object>() { { "CLIENTEID", id } }).Result;
                return ret.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                Response.WriteAsync(ex.Message);
                return null;
            }
        }

        [HttpPost]
        [Route("inserir")]
        public IActionResult Insere([FromBody]Cliente cliente)
        {
            try
            {
                _contexto.ConexaoOracle().ExecuteAsync("insert into cliente(NOME) values(:NOME)",
                    new Dictionary<string, object>() { { "NOME", cliente.Nome } });
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpPut]
        [Route("altera")]
        public IActionResult Update([FromBody]Cliente cliente)
        {
            try
            {
                _contexto.ConexaoOracle().ExecuteAsync("update cliente set NOME = :NOME where CLIENTEID = :CLIENTEID",
                    new Dictionary<string, object>() { { "CLIENTEID", cliente.ClienteID }, { "NOME", cliente.Nome } });
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpDelete]
        [Route("deletar")]
        public IActionResult Deleta(int id)
        {
            try
            {
                _contexto.ConexaoOracle().ExecuteAsync("delete from cliente where CLIENTEID = :CLIENTEID",
                        new Dictionary<string, object>() { { "CLIENTEID", id } });
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
    }
}