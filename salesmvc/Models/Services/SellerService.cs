using NuGet.Protocol.Plugins;
using salesmvc.Data;
using Microsoft.EntityFrameworkCore;

namespace salesmvc.Models.Services
{
    public class SellerService
    {
        private readonly salesmvcContext _context;

        public SellerService(salesmvcContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        { 
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Seller FindById(int id) 
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(s => s.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }
    }
}
