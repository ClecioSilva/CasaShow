using System;
using System.ComponentModel.DataAnnotations;
using LivePass.Models;

namespace LivePass.DTO
{
    public class EventoDTO
    {     
        [Required]
        public int Id{get;set;}
        [Required(ErrorMessage="Nome do Evento é Obrigatório")]
        public string Nome{get;set;}
        [Required(ErrorMessage="Capacidade é Obrigatório")]
        public int Capacidade{get;set;}
        [Required(ErrorMessage="Data é Obrigatório")]
        public DateTime Data{get;set;}
        [Required(ErrorMessage="Valor é Obrigatório")]
        public float Valor{get;set;}
        public CasaShow CasaShow {get;set;}
        public Categoria Categoria {get;set;}
    }
}