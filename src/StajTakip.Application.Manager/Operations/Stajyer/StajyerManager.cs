using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        public List<Stajyer> GetAll()
        {
            return _dbContext.Stajyers.OrderByDescending(p => p.BaslamaTarihi).ToList();
            //return _dbContext.Stajyers.ToList();
        }

        public Stajyer Get(int id)
        {
            return _dbContext.Stajyers.Where(s => s.Id.Equals(id)).FirstOrDefault();
        }

        public void Guncelle(Stajyer stajyer)
        {
            
            var find = Get(stajyer.Id);
            find.TcNo = stajyer.TcNo;
            find.Departman = stajyer.Departman;
            find.Ad = stajyer.Ad;
            find.Soyad= stajyer.Soyad;
            find.Telefon = stajyer.Telefon;
            find.BaslamaTarihi = stajyer.BaslamaTarihi;
            _dbContext.Update(find);
            _dbContext.SaveChanges();
        }

        public void Kaydet(Stajyer stajyer)
        {

            /*if (string.IsNullOrEmpty(stajyer.Id))//Ekle
            {
                _dbContext.Stajyers.Add(stajyer);

            }
            else//Güncelle
            {
                _dbContext.Stajyers.Update(stajyer);
            }*/
            _dbContext.Stajyers.Add(stajyer);
            _dbContext.SaveChanges();
            //throw new NotImplementedException();
        }

        public void Sil(int id)
        {
            var find = _dbContext.Stajyers.Where(s => s.Id.Equals(id)).FirstOrDefault();
            if (find != null)
            {
                _dbContext.Remove(find);
            }
            _dbContext.SaveChanges();
        }


    }
}
