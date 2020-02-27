using System.ComponentModel.DataAnnotations;

namespace LivePass.Models
{
    public class CasaShow
    {
        
        public int Id {get;set;}
        public string Nome{get;set;}
        public string End{get;set;}
        public bool Status {get;set;}
    }
}