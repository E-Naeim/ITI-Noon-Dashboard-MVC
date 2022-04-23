using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext Context;
        public IMainRepository<Address> Addresses { get; private set; }
        public IMainRepository<Card> Cards { get; private set; }
        public IMainRepository<Category> Categories { get; private set; }
        public IMainRepository<User> Users { get; private set; }
        public IMainRepository<Image> Images { get; private set; }
        public IMainRepository<Likes> Likes { get; private set; }
        public IMainRepository<Order> Orders { get; private set; }
        public IMainRepository<OrderItem> OrderItems { get; private set; }
        public IMainRepository<Phone> Phones { get; private set; }
        public IMainRepository<Product> Products { get; private set; }
        public IMainRepository<Review> Reviews { get; private set; }
        public IMainRepository<Wishlist> Wishlists { get; private set; }
        public IMainRepository<Cart> Carts { get; private set; }

        // Constructor
        public UnitOfWork(ApplicationDbContext _Context)
        {
            Context = _Context;
            Addresses = new MainRepository<Address>(Context);
            Cards = new MainRepository<Card>(Context);
            Categories = new MainRepository<Category>(Context);
            Users = new MainRepository<User>(Context);
            Images = new MainRepository<Image>(Context);
            Likes = new MainRepository<Likes>(Context);
            Orders = new MainRepository<Order>(Context);
            OrderItems = new MainRepository<OrderItem>(Context);
            Phones = new MainRepository<Phone>(Context);
            Products = new MainRepository<Product>(Context);
            Reviews = new MainRepository<Review>(Context);
            Wishlists = new MainRepository<Wishlist>(Context);
            Carts = new MainRepository<Cart>(Context);
        }

        // Save changes in database
        public void Save()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
