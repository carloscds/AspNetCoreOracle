using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracleAcesso
{
    class Program
    {
        static void Main(string[] args)
        {
            var conexao = new OracleConnection("data source=oracle; " +
                "user id=system; password=cds123456");

            var cmd = new OracleCommand("select * from customers", conexao);

            //var dr = cmd.ExecuteReader();
            //while(dr.Read())
            //{
            //    Console.WriteLine(dr["Company_Name"].ToString());
            //    if(dr["Company_Name"].ToString() == "Bottom-Dollar Markets")
            //    {
            //        Console.WriteLine("Meu Cliente Favorito!");
            //    }
            //}
            //dr.Close();

            try
            {
                conexao.Open();
                var insere = new OracleCommand("insert into customers(" +
                    "customer_id,customer_code,company_name, " +
                    "contact_name) values(:customer_id,:customer_code," +
                    ":company_name,:contact_name)", conexao);
                insere.Parameters.Add("customer_id", 1001);
                insere.Parameters.Add("customer_code", "CDS 1");
                insere.Parameters.Add("company_name", "CDS 1");
                insere.Parameters.Add("contact_name", "Carlos 1");
                insere.ExecuteNonQuery();
            }
            catch (OracleException ex)
            {
                Console.WriteLine("Erro no Oracle: " + ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}
