using System;
using System.Collections.Generic;
using System.Text;
using LivePass.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LivePass.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<Categoria> Categorias {get;set;}
        public DbSet<CasaShow> CasaShows {get;set;}
        public DbSet<Evento> Eventos {get;set;}
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){ }
    }
}
