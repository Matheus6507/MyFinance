using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Data.Common;
using System.IO;
using MySql.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using MyFinance.Core.Models;

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
                return _conn;
            }
        }

        public ApplicationDbContext()
        {
            if (_connectionString == null)
                _connectionString = File.ReadAllText(Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory.ToString()), "_conn.txt"));
        }

        internal virtual DbSet<Usuario> Usuarios { get; set; }

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
