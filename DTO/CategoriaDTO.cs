using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace LivePass.DTO
{
    public class CategoriaDTO
    {
        [Required]
        public int Id {get;set;}
                
        [Required(ErrorMessage="Nome de Categoria é Obrigatório")]
        [StringLength(100,ErrorMessage="Nome de Categoria muito grande!!")]
        [MinLength(4,ErrorMessage="Nome de Categoria muito pequeno!!")]
        public string Estilo{get;set;}           
        public string Imagem{get;set;}


    }
}