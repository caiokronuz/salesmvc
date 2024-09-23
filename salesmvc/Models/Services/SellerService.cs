﻿using salesmvc.Data;

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
            
            obj.Department = _context.Department.First(); //Declarando departament default para teste
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
