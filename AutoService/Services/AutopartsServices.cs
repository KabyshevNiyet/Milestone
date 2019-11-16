using AutoService.Abstractions;
using AutoService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoService.Services
{
    public class AutopartsServices
    {
        private readonly IAutopartsRepo _autopartsRepo;
        public AutopartsServices(IAutopartsRepo autopartsRepo)
        {
            _autopartsRepo = autopartsRepo;
        }

        // GET: Roles
        public async Task<List<Autoparts>> GetAutoparts()
        {
            return await _autopartsRepo.GetAll();
            //return await _context.Roles.ToListAsync();
        }

        // GET: Roles/Details/5 and For Edit Get Role
        public async Task<Autoparts> DetailsAutoparts(int? id)
        {
            return await _autopartsRepo.GetDetail(id);
            //return await _context.Roles.FirstOrDefaultAsync(m => m.Id == id);
        }
        // For last method
        public bool AutopartsExis(int id)
        {
            return _autopartsRepo.Exist(id);
            //return _context.Roles.Any(m => m.Id == id);
        }
        // POST: Roles/Create
        public async Task AddAndSave(Autoparts autoparts)
        {
            _autopartsRepo.Add(autoparts);
            await _autopartsRepo.Save();
            //_context.Roles.Add(role);
            //await _context.SaveChangesAsync();
        }

        // POST: Roles/Edit/5
        public async Task Update(Autoparts autoparts)
        {
            _autopartsRepo.Update(autoparts);
            await _autopartsRepo.Save();
            //_context.Roles.Update(role);
            //await _context.SaveChangesAsync();
        }

        // POST: Roles/Delete/5
        public async Task Delete(Autoparts autoparts)
        {
            _autopartsRepo.Delete(autoparts);
            await _autopartsRepo.Save();
            //_context.Roles.Remove(role);
            //await _context.SaveChangesAsync();
        }

        public DbSet<Cars> getCars()
        {
            return _autopartsRepo.GetCars();
        }
        public DbSet<TypesAutopart> getTypesAutoparts()
        {
            return _autopartsRepo.GetTypesAutoparts();
        }
    }
}
