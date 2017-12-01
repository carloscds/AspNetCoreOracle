using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Devart.Data.Oracle;
using WebAPI.Entidades;
using Dapper;
using Microsoft.AspNetCore.Cors;

namespace WebAPI.Controllers
{
    /// <summary>
    /// Manipula dados dos clientes.
    /// </summary>
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
            try
            {
                var db = new OracleConnection(strConn);
                var clientes = db.Query<Cliente>("select clienteid,nome from cliente");
                return clientes.ToList();
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
        public ActionResult Incluir([FromBody]Cliente cliente)
        {
            try
            {
                var db = new OracleConnection(strConn);
                db.Execute("insert into cliente(NOME) values(:NOME)",
                           new Dictionary<string, object>()
                           { {"NOME",cliente.Nome }});
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetID")]
        public Cliente GetID(int ID)
        {
            try
            {
                var db = new OracleConnection(strConn);
                var cliente = db.Query<Cliente>("select ClienteID,NOME from cliente  " +
                           "where CLIENTEID = :CLIENTEID",
                           new Dictionary<string, object>()
                           {{"CLIENTEID", ID} });
                return cliente.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                Response.WriteAsync(ex.Message);
                return null;

            }
        }

        [HttpPut]
        [Route("alterar")]
        public ActionResult Alterar([FromBody]Cliente cliente)
        {
            try
            {
                var db = new OracleConnection(strConn);
                db.Execute("update cliente set NOME = :NOME " +
                           "where CLIENTEID = :CLIENTEID",
                           new Dictionary<string, object>()
                           {{"CLIENTEID", cliente.ClienteID},
                            {"NOME",cliente.Nome }});
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
        /// <summary>
        /// Deleta um cliente do sistema
        /// </summary>
        /// <param name="ID">codigo do cliente</param>
        /// <returns></returns>
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
                return StatusCode(400, ex.Message);
            }
        }
    }
}