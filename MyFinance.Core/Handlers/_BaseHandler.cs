using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinance.Core.Handlers
{
    public abstract class BaseHandler<TEntity> where TEntity : class
    {
        readonly protected DbSet<TEntity> _entity;

        protected readonly ApplicationDbContext _context;
        protected readonly IOptions<Config> _config;
        protected readonly HandlerFactory _handlerFactory;

        public BaseHandler(ApplicationDbContext context, IOptions<Config> config, HandlerFactory handlerFactory, DbSet<TEntity> entity)
        {
            _context = context;
            _config = config;
            _entity = entity;
            _handlerFactory = handlerFactory;

            if (_config == null)
                _config = new Config();
        }

        public IEnumerable<TEntity> GetList()
        {
            return _entity.Take(1000);
        }

        public TEntity Criar(TEntity obj)
        {
            var im = _entity.Add(obj);

            Commit();

            _context.Detached(im.Entity);

            return im.Entity;
        }

        public TEntity Update(TEntity obj)
        {
            var im = _entity.Update(obj);

            Commit();

            _context.Detached(im.Entity);

            return im.Entity;
        }

        public void Delete(TEntity obj)
        {
            _entity.Remove(obj);
            Commit();
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }
    }
}
