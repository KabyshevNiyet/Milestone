using AutoService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoService.Abstractions
{
    public interface IAutopartsRepo
    {
        void Add(Autoparts autoparts);
        void Update(Autoparts autoparts);
        void Delete(Autoparts autoparts);
        Task Save();
        Task<List<Autoparts>> GetAll();
        Task<Autoparts> GetDetail(int? id);
        bool Exist(int id);
        DbSet<Cars> GetCars();
        DbSet<TypesAutopart> GetTypesAutoparts();

    }
}
