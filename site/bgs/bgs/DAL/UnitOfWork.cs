using bgs.Models;
using System;

namespace bgs.DAL
{
    /// <summary>
    /// This class is part of the separation of concerns. 
    /// All the controllers only need to use this class for 
    /// any access to the repositories and the data from the database.
    /// </summary>
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

        private CategoryRepository categoryRepository;
        public CategoryRepository CategoryRepository
        {
            get
            {
                if (categoryRepository == null)
                {
                    categoryRepository = new CategoryRepository(_context);
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

        private ProductRepository productRepository;

        public ProductRepository ProductRepository
        {
            get
            {
                if (productRepository == null)
                {
                    productRepository = new ProductRepository(_context);
                }
                return productRepository;
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

        private Repository<SleeveSize> sleeveSizeRepository;
        public Repository<SleeveSize> SleeveSizeRepository
        {
            get
            {
                if (sleeveSizeRepository == null)
                {
                    sleeveSizeRepository = new Repository<SleeveSize>(_context);
                }
                return sleeveSizeRepository;
            }
        }


        /// <summary>
        /// Default constructor.
        /// </summary>
        public UnitOfWork() : this(new BgsContext())
        {
        }

        /// <summary>
        /// A constructor that takes a parameter 
        /// specifying the context to be used.
        /// </summary>
        /// <param name="context"></param>
        public UnitOfWork(BgsContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Method that handles the saving of changes 
        /// through the apropriate call to the context.
        /// </summary>
        public void Save()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
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

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}