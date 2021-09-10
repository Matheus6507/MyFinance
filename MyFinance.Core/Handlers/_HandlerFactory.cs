using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinance.Core.Handlers
{
    public class _HandlerFactory : IDisposable
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

        public void Detached(object entity)
        {
            _context.Entry(entity).State = EntityState.Detached;
        }
    }
}
