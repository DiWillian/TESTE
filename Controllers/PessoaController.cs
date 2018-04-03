using ExemploValidacao.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace ExemploValidacao.Controllers
{
    public class PessoaController : Controller
    {
        //
        // GET: /Pessoa/

        public ActionResult IndexPessoa()
        {
            return View("IndexPessoa");
        }

        [HttpPost]
        public ActionResult IndexPessoa(Pessoa pessoa) {
            //if (string.IsNullOrEmpty(pessoa.Nome))
            //{
            //    ModelState.AddModelError("Nome", @"O campo ""nome"" é obrigatório");
            //}

            //if (pessoa.Senha != pessoa.ConfirmarSenha)
            //{
            //    ModelState.AddModelError("", "As senhas não conferem!");
            //}

            if (ModelState.IsValid)
            {
                return View("Resultado", pessoa);
            }
            else
            {
                return View("IndexPessoa", pessoa);
            }
        }

        public ActionResult Resultado(Pessoa pessoa)
        {
            return View(pessoa);
        }

        public ActionResult LoginUnico(string login) 
        {
            var bancoDeNomes = new Collection<string>{
                "Cleyton",
                "Anderson",
                "Renata"
            };
            return Json(bancoDeNomes.All(x => x.ToLower() != login.ToLower()), JsonRequestBehavior.AllowGet);
        }

    }
}
