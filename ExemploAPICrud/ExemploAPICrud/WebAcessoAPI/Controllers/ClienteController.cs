using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAcessoAPI.Entidades;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace WebAcessoAPI.Controllers
{
    public class ClienteController : Controller
    {
        string urlBase = "http://cdsoracle.southcentralus.cloudapp.azure.com/exemploapi/api/cliente";

        public ActionResult Index()
        {
            List<Cliente> clientes = null;
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(urlBase).Result;
                var dados = response.Content.ReadAsStringAsync().Result;
                clientes = JsonConvert.DeserializeObject<List<Cliente>>(dados);
            }
            return View(clientes);
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return StatusCode(400, "Não encontrado");
            }
            Cliente cliente = null;
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(urlBase+"/GetID?id="+id.ToString()).Result;
                var dados = response.Content.ReadAsStringAsync().Result;
                cliente = JsonConvert.DeserializeObject<Cliente>(dados);
            }
            if (cliente == null)
            {
                return StatusCode(400, "Não encontrado");
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    JObject obj = new JObject();
                    obj.Add("ClienteID", "0");
                    obj.Add("Nome", cliente.Nome);
                    var response = client.PostAsync(urlBase + "/incluir", new StringContent(obj.ToString(), Encoding.UTF8, "application/json")).Result;
                }
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return StatusCode(400, "Não encontrado!");
            }
            Cliente cliente = null;
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(urlBase + "/GetID?id=" + id.ToString()).Result;
                var dados = response.Content.ReadAsStringAsync().Result;
                cliente = JsonConvert.DeserializeObject<Cliente>(dados);
            }
            if (cliente == null)
            {
                return StatusCode(400, "Não encontrado!");
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    JObject obj = new JObject();
                    obj.Add("ClienteID", cliente.ClienteID);
                    obj.Add("Nome", cliente.Nome);
                    var response = client.PutAsync(urlBase + "/alterar", new StringContent(obj.ToString(), Encoding.UTF8, "application/json")).Result;
                }
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return StatusCode(400, "Não encontrado!");
            }
            Cliente cliente = null;
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(urlBase + "/GetID?id=" + id.ToString()).Result;
                var dados = response.Content.ReadAsStringAsync().Result;
                cliente = JsonConvert.DeserializeObject<Cliente>(dados);
            }
            if (cliente == null)
            {
                return StatusCode(400, "Não encontrado!");
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var client = new HttpClient())
            {
                var response = client.DeleteAsync(urlBase + "/deletar?id=" + id.ToString()).Result;
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

    }
}