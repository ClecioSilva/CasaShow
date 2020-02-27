using System.Linq;
using LivePass.Data;
using LivePass.Models;
using Microsoft.AspNetCore.Mvc;

namespace LivePass.Controllers
{
    public class EventoController: Controller
    {
         private readonly ApplicationDbContext database;
        public EventoController(ApplicationDbContext database){
            this.database = database;
        }

         public IActionResult Index(){
            var eventos = database.Eventos.ToList();
            return View(eventos);
        }

        public IActionResult CadastrarEvento(){
            return View();
        }

        public IActionResult EditarEvento(int id){
            Evento evento = database.Eventos.First(registro => registro.Id == id);
            return View("CadastrarEvento",evento);
        }

        public IActionResult DeletarEvento(int id){
            Evento evento = database.Eventos.First(registro => registro.Id == id);
            database.Eventos.Remove(evento);
            database.SaveChanges();
            return RedirectToAction("Index");
        }

       [HttpPost]
        public IActionResult Salvar(Evento evento){
            if(evento.Id == 0){
                //Salve uma nova Casa de Show
                database.Eventos.Add(evento);
            }else{
                //Atualiza uma Casa de Show
                Evento eventoDoBanco = database.Eventos.First(registro => registro.Id == evento.Id);
                
                eventoDoBanco.Nome = evento.Nome;
                eventoDoBanco.Capacidade = evento.Capacidade;
                eventoDoBanco.Data = eventoDoBanco.Data;
                eventoDoBanco.Valor = eventoDoBanco.Valor;
                eventoDoBanco.CasaShow = eventoDoBanco.CasaShow;
                eventoDoBanco.Categoria = eventoDoBanco.Categoria;

            }
            
            
            database.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}