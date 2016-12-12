using bgs.Models;
using System;

namespace bgs.DAL
{
    public class UnitOfWork : IDisposable
    {
        private readonly BgsContext _context;

        private bool disposed = false;

        // Properties for Repositories
        private Repository<Game> gameRepository;
        public Repository<Game> GameRepository
        {
            get
            {
                if (gameRepository == null)
                {
                    gameRepository = new Repository<Game>(_context);
                }
                return gameRepository;
            }

        }

        private Repository<Category> categoryRepository;
        public Repository<Category> CategoryRepository
        {
            get
            {
                if (categoryRepository == null)
                {
                    categoryRepository = new Repository<Category>(_context);
                }
                return categoryRepository;
            }
        }

        private Repository<Credential> credentialRepository;
        public Repository<Credential> CredentialRepository
        {
            get
            {
                if (credentialRepository == null)
                {
                    credentialRepository = new Repository<Credential>(_context);
                }
                return credentialRepository;
            }
        }

        private Repository<Dimensions> dimensionsRepository;
        public Repository<Dimensions> DimensionsRepository
        {
            get
            {
                if (dimensionsRepository == null)
                {
                    dimensionsRepository = new Repository<Dimensions>(_context);
                }
                return dimensionsRepository;
            }
        }

        private Repository<Person> personRepository;
        public Repository<Person> PersonRepository
        {
            get
            {
                if (personRepository == null)
                {
                    personRepository = new Repository<Person>(_context);
                }
                return personRepository;
            }
        }

        private Repository<OrderItem> orderItemRepository;
        public Repository<OrderItem> OrderItemRepository
        {
            get
            {
                if (orderItemRepository == null)
                {
                    orderItemRepository = new Repository<OrderItem>(_context);
                }
                return orderItemRepository;
            }
        }

        private Repository<Order> orderRepository;
        public Repository<Order> OrderRepository
        {
            get
            {
                if (orderRepository == null)
                {
                    orderRepository = new Repository<Order>(_context);
                }
                return orderRepository;
            }
        }

        private Repository<Product> productRepository;
        public Repository<Product> ProductRepository
        {
            get
            {
                if (productRepository == null)
                {
                    productRepository = new Repository<Product>(_context);
                }
                return productRepository;
            }
        }



        /**
         * Missing repositories for:
         *  Role - enum
         *  ProductGame - no single unique key
         *  Cart - no unique id
         **/

        public UnitOfWork()
        {
            _context = new BgsContext();
        }

        public UnitOfWork(BgsContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}