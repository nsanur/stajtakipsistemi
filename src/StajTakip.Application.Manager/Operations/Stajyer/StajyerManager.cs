using Microsoft.EntityFrameworkCore;
using StajTakip.Application.Contracts.Operations;
using StajTakip.Data.Contexts;
using StajTakip.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajTakip.Application.Manager.Operations
{
    public class StajyerManager : IStajyerService
    {
        private readonly StajyerModelContext _dbContext;
        public StajyerManager(StajyerModelContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Stajyer Get(string id)
        {
            return _dbContext.Stajyers.Where(s => s.Id.Equals(id)).FirstOrDefault();
        }

        public List<Stajyer> GetAll()
        {
            return _dbContext.Stajyers.ToList();
        }

        public void Guncelle(Stajyer stajyer)
        {
            var find = Get(stajyer.Id);
            find.Telefon = stajyer.Telefon;
            find.Departman = stajyer.Departman;
            find.Ad = stajyer.Ad;
            find.Soyad= stajyer.Soyad;
            find.BaslamaTarihi = stajyer.BaslamaTarihi;
            _dbContext.Update(find);
            _dbContext.SaveChanges();
        }

        public void Kaydet(Stajyer stajyer)
        {
            _dbContext.Stajyers.Add(stajyer);
            throw new NotImplementedException();
        }

        public void Sil(string id)
        {
            var find = _dbContext.Stajyers.Where(s => s.Id.Equals(id)).FirstOrDefault();
            if (find != null)
            {
                _dbContext.Remove(find);
            }
        }

        
    }
}
