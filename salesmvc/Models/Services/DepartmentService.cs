using salesmvc.Data;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace salesmvc.Models.Services
{
    public class DepartmentService
    {
        private readonly salesmvcContext _context;

        public DepartmentService(salesmvcContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(d => d.Name).ToListAsync();
        }
    }
}
