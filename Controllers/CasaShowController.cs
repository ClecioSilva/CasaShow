using System.Linq;
using LivePass.Data;
using LivePass.DTO;
using LivePass.Models;
using Microsoft.AspNetCore.Mvc;

namespace LivePass.Controllers
{
    public class CasaShowController: Controller
    {

        private readonly ApplicationDbContext database;
        public CasaShowController(ApplicationDbContext database){
            this.database = database;
        }

        [HttpPost]
        public IActionResult Salvar(CasaShowDTO casaShowTemporaria){
            if(ModelState.IsValid){
                CasaShow casaShow = new CasaShow();
                casaShow.Nome = casaShowTemporaria.Nome;
                casaShow.End = casaShowTemporaria.End;
                casaShow.Status = true;
                database.CasaShows.Add(casaShow);
                database.SaveChanges();
                return RedirectToAction("CasaShows","Gestao");
            }else{
                return View("../Gestao/NovaCasaShow");
            }
        }
        
        [HttpPost]
        public IActionResult Atualizar(CasaShowDTO casaShowTemporaria){
            if(ModelState.IsValid){
                var casaShow = database.CasaShows.First(cas => cas.Id == casaShowTemporaria.Id);
                casaShow.Nome = casaShowTemporaria.Nome;
                casaShow.End = casaShowTemporaria.End;
                database.SaveChanges();
                return RedirectToAction("CasaShows","Gestao");
            }else{
                return View("../Gestao/EditarCasaShow");
            }
        }

        [HttpPost]
        public IActionResult Deletar(int Id){
            if(Id > 0){
                var casaShow = database.CasaShows.First(cas => cas.Id == Id);
                casaShow.Status = false;
                database.SaveChanges();
            }
            return RedirectToAction("CasaShows","Gestao");
        }
    }
}