using System.IO;
using System.Linq;
using LivePass.Data;
using LivePass.DTO;
using LivePass.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;

namespace LivePass.Controllers
{
    public class CategoriaController : Controller
    {
        private IWebHostEnvironment _hostingEnvironment;
        private readonly ApplicationDbContext database;
        public CategoriaController(ApplicationDbContext database, IWebHostEnvironment environment){
            this.database = database;
        }   
        [HttpPost]
        public IActionResult Salvar(CategoriaDTO categoriaTemporaria){
            if(ModelState.IsValid){
                Categoria categoria = new Categoria();
                categoria.Estilo = categoriaTemporaria.Estilo;
                categoria.Imagem = categoriaTemporaria.Imagem;
                categoria.Status = true;
                database.Categorias.Add(categoria);
                database.SaveChanges();
                return RedirectToAction("Categorias","Gestao");
            }else{
                return View("../Gestao/NovaCategoria");
            }
        }   
        [HttpPost]
        public IActionResult Atualizar(CategoriaDTO categoriaTemporaria){
            if(ModelState.IsValid){
                var categoria = database.Categorias.First(cat => cat.Id == categoriaTemporaria.Id);
                categoria.Estilo = categoriaTemporaria.Estilo;
                categoria.Imagem = categoriaTemporaria.Imagem;
                database.SaveChanges();
                return RedirectToAction("Categorias","Gestao");
            }else{
                return View("../Gestao/EditarCategoria");
            }
        }  
        [HttpPost]
        public IActionResult Deletar(int Id){
            if(Id > 0){
                var categoria = database.Categorias.First(cat => cat.Id == Id);
                categoria.Status = false;
                database.SaveChanges();
            }
            return RedirectToAction("Categorias","Gestao");
        }
    }
}

       