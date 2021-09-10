using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace MyFinance.Core.Handlers
{
    public class HandlerFactory : IDisposable
    {
        public static IWebHostEnvironment Environment;
        private IOptions<Config> _config;
        private ApplicationDbContext _context;
        public ApplicationDbContext DBContext
        {
            get
            {
                return _context;
            }
        }
        private string _userIP;
        public string UserIP
        {
            get
            {
                if (!string.IsNullOrEmpty(_userIP))
                    return _userIP;
                else
                {
                    return _userIP;
                }
            }
            set
            {
                if (_config != null)
                    _config.Value.UserIP = value;

                _userIP = value;
            }
        }

        public HandlerFactory(ApplicationDbContext dbContext, IOptions<Config> config)
        {
            _context = dbContext;
            _config = config;
        }

        private UsuarioHandler _usuario;
        public UsuarioHandler Usuario => _usuario ?? (_usuario = new UsuarioHandler(_context, _config, this));

        public void Detached(object entity)
        {
            _context.Entry(entity).State = EntityState.Detached;
        }

        public void Dispose()
        {

        }
    }
}
