using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using Devart.Data.Oracle;

namespace WebApplication1.Controllers
{
    [Produces("application/json")]
    [Route("api/Cliente")]
    public class ClienteController : Controller
    {
        string strConn = "User Id=system;Password=cds123456;" +
                          "Server=cdsoracle.southcentralus.cloudapp.azure.com;" +
                          "Direct=True;Sid=xe;Port=1521";

        [HttpGet]
        public List<Cliente> Get()
        {
            var db = new OracleConnection(strConn);
            var clientes = db.Query<Cliente>("select clienteid,nome from cliente");
            return clientes.ToList();
        }

        [HttpPut]
        [Route("alterar")]
        public ActionResult Alterar([FromBody]Cliente cliente)
        {
            try
            {
                var db = new OracleConnection(strConn);
                db.Execute("update clientessss set NOME = :NOME " +
                           "where CLIENTEID = :CLIENTEID",
                           new Dictionary<string, object>()
                           {{"CLIENTEID", cliente.ClienteID},
                            {"NOME",cliente.Nome }});
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400,ex.Message);
            }
        }

        [HttpDelete]
        [Route("deletar")]
        public ActionResult Deletar(int ID)
        {
            try
            {
                var db = new OracleConnection(strConn);
                db.Execute("delete from cliente where CLIENTEID = :CLIENTEID",
                           new Dictionary<string, object>()
                           {{"CLIENTEID", ID}});
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400,ex.Message);
            }
        }
    }
}