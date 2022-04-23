using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IMainRepository<Address> Addresses { get; }
        IMainRepository<Card> Cards { get; }
        IMainRepository<Category> Categories { get; }
        IMainRepository<User> Users { get; }
        IMainRepository<Image> Images { get; }
        IMainRepository<Likes> Likes { get; }
        IMainRepository<Order> Orders { get; }
        IMainRepository<OrderItem> OrderItems { get; }
        IMainRepository<Phone> Phones { get; }
        IMainRepository<Product> Products { get; }
        IMainRepository<Review> Reviews { get; }
        IMainRepository<Wishlist> Wishlists { get; }
        IMainRepository<Cart> Carts { get; }
        public void Save();
    }
}
