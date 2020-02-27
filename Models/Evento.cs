using System;

namespace LivePass.Models
{
    public class Evento
    {
        public int Id{get;set;}
        public string Nome{get;set;}
        public int Capacidade{get;set;}
        public DateTime Data{get;set;}
        public float Valor{get;set;}
        public CasaShow CasaShow {get;set;}
        public Categoria Categoria {get;set;}
        public bool Status {get;set;}
    }
}