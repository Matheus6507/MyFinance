using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Data.Common;
using System.IO;
using MyFinance.Core.Models;
using MySql.Data.MySqlClient;

namespace MyFinance.Core
{
    public partial class ApplicationDbContext : DbContext
    {
        private IOptions<Config> _config;
        private string _connectionString;
        private MySqlConnection _conn;
        private DbConnection _dbconn;

        public MySqlConnection MySqlConnection
        {
            get
            {
                if (_conn == null)
                    _conn = new MySqlConnection(_connectionString);

                if (_conn.State != System.Data.ConnectionState.Open)
                    _conn.Open();

                return _conn;
            }
        }

        public ApplicationDbContext(IOptions<Config> config)
        {
            _config = config;
            if (_connectionString == null)
                _connectionString = File.ReadAllText(Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory.ToString()), "_conn.txt"));
        }

        public ApplicationDbContext()
        {
            if (_connectionString == null)
                _connectionString = File.ReadAllText(Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory.ToString()), "_conn.txt"));
        }

        internal virtual DbSet<Usuario> Usuarios { get; set; }
        internal virtual DbSet<Conta> Contas { get; set; }
        internal virtual DbSet<Categoria> Categorias { get; set; }
        internal virtual DbSet<Transacao> Transacoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(b =>
            {
                b.HasKey(x => x.Uid);
            });

            modelBuilder.Entity<Conta>(b =>
            {
                b.HasKey(x => x.Uid);
            });

            modelBuilder.Entity<Categoria>(b =>
            {
                b.HasKey(x => x.Uid);
            });

            modelBuilder.Entity<Transacao>(b =>
            {
                b.HasKey(x => x.Uid);
            });
        }

        internal void Detached(object entity)
        {
            Entry(entity).State = EntityState.Detached;
        }

        public override void Dispose()
        {
            base.Dispose();

            if (_conn != null)
                _conn.Dispose();
        }
    }
}
