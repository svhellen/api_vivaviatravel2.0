using api_vivaviatravel2.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace api_vivaviatravel2.Context
{
    public class ApiDbContext: DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        { }

        public DbSet<ClienteModel>? Clientes { get; set; }


        public DbSet<PassagemModel>? Passagens { get; set; }

        public DbSet<HospedagemModel>? Hospedagens { get; set; }

        public DbSet<PacoteModel>? Pacotes { get; set; }

        public DbSet<ReservaModel>? Reservas { get; set; }

        public DbSet<DestinoModel>? Destinos { get; set; }


        public ApiDbContext(DbSet<ClienteModel>? clientes)
        {
            Clientes = clientes;
        }
        public ApiDbContext(DbSet<PassagemModel>? passagens)
        {
            Passagens = passagens;
        }
        public ApiDbContext(DbSet<HospedagemModel>? hospedagens)
        {
            Hospedagens = hospedagens;
        }
        public ApiDbContext(DbSet<PacoteModel>? pacotes)
        {
            Pacotes = pacotes;
        }

        public ApiDbContext(DbSet<ReservaModel>? reservas)
        {
            Reservas = reservas;
        }
        public ApiDbContext(DbSet<DestinoModel>? destinos)
        {
            Destinos = destinos;
        }

    }
}
