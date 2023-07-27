using StajTakip.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajTakip.Application.Contracts.Operations
{
    public interface IStajyerService
    {
        List<Stajyer> GetAll();
        Stajyer Get(int id);
        void Sil(int id);
        void Kaydet(Stajyer stajyer);
        void Guncelle(Stajyer stajyer);
        

    }
}
