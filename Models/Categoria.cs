using System.ComponentModel.DataAnnotations;

namespace LivePass.Models
{
    public class Categoria
    {
         public int Id{get;set;}
        public string Estilo{get;set;}
        public string Imagem{get;set;}
        public bool Status {get;set;}

    }
}