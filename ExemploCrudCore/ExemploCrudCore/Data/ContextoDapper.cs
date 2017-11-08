using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExemploCrudCore.Dados.Entidades;
using Dapper;
using Dapper.Contrib.Extensions;
using Devart.Data.Oracle;

namespace ExemploCrudCore.Models
{
    public class ContextoDapper
    {
        OracleConnection conexao;

        public ContextoDapper (Microsoft.Extensions.Configuration.IConfiguration config)
        {

            //OracleConnectionStringBuilder oraCSB = new OracleConnectionStringBuilder();
            //oraCSB.LicenseKey = "XXXXXXX";
            //oraCSB.Direct = true;
            //oraCSB.Server = "cdsoracle.southcentralus.cloudapp.azure.com";
            //oraCSB.Port = 1521;
            //oraCSB.Sid = "xe";
            //oraCSB.UserId = "system";
            //oraCSB.Password = "cds123456";
            //OracleConnection conexao = new OracleConnection(oraCSB.ConnectionString);

            var stringConexao = config.GetSection("ConnectionStrings:Contexto").Value;
            conexao = new OracleConnection(stringConexao);
        }

        public async Task<IEnumerable<Cliente>> ClienteListar()
        {
            return await conexao.GetAllAsync<Cliente>();
        }

        public async Task<Cliente> ClienteLer(int id)
        {
            var ClienteID = id;
            var ret = await conexao.QueryAsync<Cliente>("Select CLIENTEID, NOME from CLIENTE where CLIENTEID = :CLIENTEID",
                new Dictionary<string, object>() { { "CLIENTEID", id } });
            return ret.FirstOrDefault();
        }

        public async void ClienteAdicionar(Cliente cliente)
        {
            await conexao.InsertAsync<Cliente>(cliente);
        }

        public async void  ClienteUpdate(Cliente cliente)
        {
            await conexao.ExecuteAsync("update cliente set NOME = :NOME where CLIENTEID = :CLIENTEID",
                new Dictionary<string, object>() { { "CLIENTEID", cliente.ClienteID }, { "NOME", cliente.Nome } });
        }

        public async void ClienteDeletar(int id)
        {
            await conexao.ExecuteAsync("delete from cliente where CLIENTEID = :CLIENTEID",
                    new Dictionary<string, object>() { { "CLIENTEID", id } });
        }
    }
}
