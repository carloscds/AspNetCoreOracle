using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExemploCrudCoreOracle.Models;
using Devart.Data.Oracle;
using Dapper;

namespace ExemploCrudCoreOracle.Controllers
{
    public class ClientesController : Controller
    {
        OracleConnection conexao = new OracleConnection(
                "User Id=system; Password=cds123456; " +
                "Server=cdsoracle.southcentralus.cloudapp.azure.com; " +
                "Direct=True; Sid=xe; Port=1521");

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            var clientes = conexao.Query<Cliente>("select CLIENTEID, NOME from CLIENTE");
            return View(clientes);
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = conexao.Query<Cliente>(
                "select CLIENTEID,NOME from CLIENTE where CLIENTEID = :CLIENTEID",
                new Dictionary<string, object>() {
                { "CLIENTEID", id}}).FirstOrDefault();
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClienteID,Nome")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                conexao.Execute("insert into CLIENTE(NOME) values(:NOME)",
                                new Dictionary<string, object>() {
                                { "NOME", cliente.Nome}});
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cliente = conexao.Query<Cliente>(
                "select CLIENTEID,NOME from CLIENTE where CLIENTEID = :CLIENTEID",
                new Dictionary<string, object>() {
                { "CLIENTEID", id}}).FirstOrDefault();
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClienteID,Nome")] Cliente cliente)
        {
            if (id != cliente.ClienteID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    conexao.Execute("update CLIENTE set NOME = :NOME where CLIENTEID = :CLIENTEID",
                         new Dictionary<string, object>() {
                        { "CLIENTEID", id},
                        {"NOME", cliente.Nome } });
                }
                catch
                {
                    // tratar 
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cliente = conexao.Query<Cliente>(
                "select CLIENTEID,NOME from CLIENTE where CLIENTEID = :CLIENTEID",
                new Dictionary<string, object>() {
                { "CLIENTEID", id}}).FirstOrDefault();
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            conexao.Execute("delete from CLIENTE where CLIENTEID = :CLIENTEID",
                        new Dictionary<string, object>() {
                        { "CLIENTEID", id} });
            return RedirectToAction(nameof(Index));
        }
    }
}
