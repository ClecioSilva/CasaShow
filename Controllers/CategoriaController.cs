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
        public CategoriaController(ApplicationDbContext database, IWebHostEnvironment environment)
        {
            _hostingEnvironment = environment;
            this.database = database;
        }

    private async Task<string> ImageUpload(IFormFile file) {
            if(file != null && file.Length > 0) {
                var imagePath = @"\Upload\Images\";
                var uploadPath = _hostingEnvironment.WebRootPath + imagePath;

                // Cria diretório
                if(!Directory.Exists(uploadPath)) {
                    Directory.CreateDirectory(uploadPath);
                }

                // Cria nome do arquivo
                var uniqFileName = Guid.NewGuid().ToString();
                var fileName = Path.GetFileName(uniqFileName + "." + file.FileName.Split(".")[1].ToLower());
                string fullPath = uploadPath + fileName;

                imagePath = imagePath + @"\";
                var filePath = @".." + Path.Combine(imagePath, fileName);

                using (var fileStream = new FileStream(fullPath, FileMode.Create)) {
                    await file.CopyToAsync(fileStream);
                }

                return filePath;
            } 
            return string.Empty;
        }
/*-------------------SALVAR DO NICOLAS-----------------------------------
    [HttpPost]
        public async Task<IActionResult> Salvar(CategoriaDTO categoriaTemp) {
            if(ModelState.IsValid) {
                Categoria categoria = new Categoria();
                categoria.Imagem = await ImageUpload(categoriaTemp.Imagem);
                categoria.Estilo = categoriaTemp.Estilo;
                database.SaveChanges();
                return RedirectToAction("Categoria", "Categoria");
            } else {
                return View("Categorias","Gestao");
            }
        }*/   


        public IActionResult Cadastrar(){
         return View();
         }
        public IActionResult Editar(int id)
        {
            Categoria categoria = database.Categorias.First(registro => registro.Id == id);
            return View("Editar", categoria);
        }

        public IActionResult Index(){
            var categorias = database.Categorias.ToList();
            return View(categorias);
        }

        /*[HttpPost]
        public IActionResult Deletar(int id) {
                var categoria = database.Categorias.First(categoria => categoria.Id == id);
                database.Categorias.Remove(categoria);
                database.SaveChanges();
                return RedirectToAction("Categoria", "Categoria");
        }*/

        /*public IActionResult Deletar(int Id){
            if(Id > 0){
                var categoria = database.Categorias.First(cat => cat.Id == Id);
                categoria.Status = false;
                database.SaveChanges();
            }
            return RedirectToAction("Categorias","Gestao");
        } */

        public IActionResult Deletar(int id){
            Categoria categoria = database.Categorias.First(registro => registro.Id == id);
            System.IO.File.Delete(Path.Combine(_hostingEnvironment.WebRootPath + categoria.Imagem));
            database.Categorias.Remove(categoria);
            database.SaveChanges();
            return RedirectToAction("Categorias","Gestao");
        }

        /*[HttpPost]
        public IActionResult Salvar(Categoria categoria, IFormFile files, int id)
        {
            if (categoria.Id == 0)
            {
                categoria.Status = true;
                database.Categorias.Add(categoria);
                database.SaveChanges();

                var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                if (files != null && files.Length > 0)
                {
                    var extensao = Path.GetExtension(files.FileName).ToLower();
                    var filePath = Path.Combine(uploads, categoria.Id + extensao);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        files.CopyTo(fileStream);
                    }
                    categoria.Imagem = "/uploads/" + categoria.Id + extensao;
                }
            }
            else
            {
                var categoriaDoBanco = database.Categorias.First(registro => registro.Id == categoria.Id);
                if (files != null)
                {
                    var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                    var extensao = Path.GetExtension(files.FileName).ToLower();
                    System.IO.File.Delete(Path.Combine(_hostingEnvironment.WebRootPath + categoriaDoBanco.Imagem));
                    var filePath = Path.Combine(uploads, categoria.Id + extensao);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        files.CopyTo(fileStream);
                    }
                    categoriaDoBanco.Imagem = "/uploads/" + categoria.Id + extensao;
                    categoriaDoBanco.Estilo = categoria.Estilo;
                }
                else
                {
                    categoriaDoBanco.Estilo = categoria.Estilo;

                }
            }
            database.SaveChanges();
            return RedirectToAction("Categorias","Gestao");
        }*/


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

        public IActionResult Atualizar(CategoriaDTO categoriaTemporaria){
            if(ModelState.IsValid){
                var categoria = database.Categorias.First(cat => cat.Id == categoriaTemporaria.Id);
                categoria.Estilo = categoriaTemporaria.Estilo;
                categoria.Imagem = categoriaTemporaria.Imagem;
                database.SaveChanges();
                return RedirectToAction("Categorias","Gestao");
            }else{
                return View("Categorias","Gestao");
            }
        }
     
    }
}

       