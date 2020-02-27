using System.ComponentModel.DataAnnotations;

namespace LivePass.DTO
{
    public class CasaShowDTO
    {
        [Required]
         public int Id {get;set;}

        [Required(ErrorMessage="Nome de Casa de Show é Obrigatório")]
        [StringLength(100,ErrorMessage="Nome de Casa de Show muito grande!!")]
        [MinLength(4,ErrorMessage="Nome de Casa de Show muito pequeno!!")]
        public string Nome{get;set;}

        [Required(ErrorMessage="Endereço da Casa de Show é Obrigatório")]
        public string End{get;set;}        
    }
}