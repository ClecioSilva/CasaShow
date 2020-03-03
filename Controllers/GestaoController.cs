using System.Linq;
using LivePass.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using LivePass.DTO;

namespace LivePass.Controllers
{
    public class GestaoController : Controller
    {

        public IActionResult Index(){
            return View();
        }

        //------------------------ Gestao controle CATEGORIAS ---------------------------------------------
        public IActionResult Categorias(){
            var categoria = database.Categorias.Where(cat => cat.Status == true).ToList();
            return View(categoria);
        }

        public IActionResult NovaCategoria(){
            return View();
        }

        public IActionResult EditarCategoria(int id){
            var categorias = database.Categorias.First(cat => cat.Id == id);
            CategoriaDTO categoriaView = new CategoriaDTO();
            categoriaView.Id = categorias.Id;
            categoriaView.Estilo = categorias.Estilo;
            categoriaView.Imagem = categorias.Imagem;
            return View(categoriaView);
        }

        //----------------------------  Gestao controller CASA SHOW  -------------------------------

        public IActionResult CasaShows(){
            var casashow = database.CasaShows.Where(cas => cas.Status == true).ToList();
            return View(casashow);
        }

        public IActionResult NovaCasaShow(){
            return View();
        }

        public IActionResult EditarCasaShow(int id){
            var casaShows = database.CasaShows.First(cas => cas.Id == id);
            CasaShowDTO casaShowView = new CasaShowDTO();
            casaShowView.Id = casaShows.Id;
            casaShowView.Nome = casaShows.Nome;
            casaShowView.End = casaShows.End;
            return View(casaShowView);  
        }

        //----------------------------  Gestao controller EVENTO  -------------------------------

        public IActionResult Eventos(){
            var evento = database.Eventos.Where(evt => evt.Status == true).ToList();
            return View(evento);
        }

        public IActionResult NovoEvento(){
            return View();
        }

        public IActionResult EditarEvento(int id){
            var eventos = database.Eventos.First(evt => evt.Id == id);
            EventoDTO eventoView = new EventoDTO();
            eventoView.Id = eventos.Id;
            eventoView.Nome = eventos.Nome;
            eventoView.Capacidade = eventos.Capacidade; 
            eventoView.Data = eventos.Data;
            eventoView.Valor = eventos.Valor;
            eventoView.CasaShow = eventos.CasaShow;
            eventoView.Categoria = eventos.Categoria;
            return View(eventoView);

        }

        public IActionResult Login(){
            return View();
        }

        private readonly ApplicationDbContext database;
        public GestaoController(ApplicationDbContext database){
            this.database = database;
        }
            
    }
}