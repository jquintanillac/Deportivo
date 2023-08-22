using Deportivo.Web.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Deportivo.Web.Data
{
    public class DataContext : IdentityDbContext<User>
	{
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Accesorios> accesorios { get; set; }
        public DbSet<Adicionales> adicionales { get; set; } 
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<DeportivoAccesorio> deportivoAccesorios { get; set; }
        public DbSet<EspacioDeportivo> espacioDeportivos { get; set; }
        public DbSet<Horario> horarios { get; set; }
        public DbSet<PagoCabecera> pagoCabeceras { get; set; }
        public DbSet<PagoDetalle> pagoDetalles { get; set; }
        public DbSet<TipoDeportivo> tipoDeportivos { get; set; }
        public DbSet<TipoDocumento> tipoDocumentos { get; set; }
        public DbSet<Eventos> eventos { get; set; }
		public DbSet<Egresos> egresos { get; set; }
		public DbSet<Inicial> iniciales { get; set; }
        public DbSet<Numeracion> numeraciones { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Accesorios>()
                .HasIndex(t => t.id_acce)
                .IsUnique(); 
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Adicionales>()
                .HasIndex(t => t.id_adicio)
                .IsUnique();
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cliente>()
                .HasIndex(t => t.id_client)
                .IsUnique();
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DeportivoAccesorio>()
                .HasIndex(t => t.id_depacce)
                .IsUnique();
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<EspacioDeportivo>()
                .HasIndex(t => t.id_espdep)
                .IsUnique();
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Horario>()
                .HasIndex(t => t.id_hordep)
                .IsUnique();
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PagoCabecera>()
                .HasIndex(t => t.id_pagcab)
                .IsUnique();
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PagoDetalle>()
                .HasIndex(t => t.id_pagdet)
                .IsUnique();
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TipoDeportivo>()
                .HasIndex(t => t.id_tipdep)
                .IsUnique();
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TipoDocumento>()
                .HasIndex(t => t.id_tipdoc)
                .IsUnique();
        }

    }
}
