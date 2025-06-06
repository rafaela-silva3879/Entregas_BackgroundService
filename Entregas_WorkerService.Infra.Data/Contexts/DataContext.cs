using Entregas_WorkerService.Domain.Entities;
using Entregas_WorkerService.Infra.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entregas_WorkerService.Infra.Data.Contexts
{
    public class DataContext : DbContext
    {
        // Construtor para injeção de dependência
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.ApplyConfiguration(new PedidoConfiguration());
        }

        // DbSets para representar as tabelas no banco de dados
        public DbSet<Pedido>? Pedidos { get; set; }
    }
}
