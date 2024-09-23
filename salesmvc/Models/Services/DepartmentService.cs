using salesmvc.Data;
using System.Linq;
using System.Collections.Generic;

namespace salesmvc.Models.Services
{
    public class DepartmentService
    {
        private readonly salesmvcContext _context;

        public DepartmentService(salesmvcContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(d => d.Name).ToList();
        }
    }
}
