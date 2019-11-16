using AutoService.Data;
using AutoService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoService.Abstractions
{
    public class AutopartsRepo
    {
        readonly MyContext _context;
        public AutopartsRepo(MyContext context)
        {
            _context = context;
        }

        public void Add(Autoparts autoparts)
        {
            _context.Add(autoparts);
        }

        public void Update(Autoparts autoparts)
        {
            _context.Update(autoparts);
        }

        public void Delete(Autoparts autoparts)
        {
            _context.Remove(autoparts);
        }

        public bool Exist(int id)
        {
            return _context.Users.Any(m => m.Id == id);
        }

        public Task<List<Autoparts>> GetAll()
        {
            return _context.Autoparts.ToListAsync();
        }

        public Task<Autoparts> GetDetail(int? id)
        {
            return _context.Autoparts.FirstOrDefaultAsync(m => m.Id == id);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }

        public DbSet<Cars> GetCars()
        {
            return _context.Cars;
        }
        public DbSet<TypesAutopart> GetAutoParts()
        {
            return _context.TypesAutopart;
        }
    }
}
