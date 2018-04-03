using ExemploValidacao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExemploValidacao.Controllers
{
    public class NoticiaController : Controller
    {
        //criou uma lista/ array do tipo "Noticia"
        private readonly IEnumerable<Noticia> todasAsNoticias;

        public NoticiaController()
        {
            //pega as notícias na ordem decrescente pelas datas
            todasAsNoticias = new Noticia().TodasAsNoticias().OrderByDescending(x => x.Data);

            //Noticia noticia = new Noticia();
            //todasAsNoticias = noticia.TodasAsNoticias().OrderByDescending(x => x.Data);
        }
        
        public ActionResult IndexNoticia()
        {
            var ultimasNoticias = todasAsNoticias.Take(3);

            var todasAsCategorias = todasAsNoticias.Select(x => x.Categoria).Distinct().ToList();

            //posso acessar a var "todasAsCategorias" na View através da ViewBag
            ViewBag.Categorias = todasAsCategorias;

            return View(ultimasNoticias);
        }

        public ActionResult TodasAsNoticias() 
        {
            return View(todasAsNoticias);
        }

        public ActionResult MostraNoticia(int noticiaId, string titulo, string categoria) 
        {
            return View(todasAsNoticias.FirstOrDefault(x => x.NoticiaId == noticiaId));
        }

        public ActionResult MostraCategoria(string categoria)
        {
            //traz uma lista de notícias de uma categoria específica
            var categoriaEspecifica = todasAsNoticias.Where(x => x.Categoria.ToLower() == categoria.ToLower()).ToList();

            ViewBag.Categoria = categoria;

            return View("MostraCategoria", categoriaEspecifica);
        }
    }
}
