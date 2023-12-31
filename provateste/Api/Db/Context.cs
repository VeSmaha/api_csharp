
using Microsoft.EntityFrameworkCore;
using Api.Model;

namespace Api.Db;

public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            // Construtor da classe Context
        }

        // Classes que vão virar tabelas no banco

        // DbSet informa que deve virar tabela no banco
        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Category> Categorys { get; set; }
    }
