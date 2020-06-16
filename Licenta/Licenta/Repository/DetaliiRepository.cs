using Licenta.Data;
using Licenta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Licenta.Repository
{
    public class DetaliiRepository : IDetaliiRepository
    {
        private ApplicationDbContext _context;

        public DetaliiRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(Detalii detalii)
        {
            float inaltimea = detalii.Inaltimea;
            var greutate = detalii.Greutate;
            inaltimea = inaltimea / 100f;
            string rezultat2;
            var rezultat1 = greutate / (inaltimea * inaltimea);
            if (rezultat1 > 30)
                rezultat2 = "Obez";
            else
                if (rezultat1 < 30 && rezultat1 > 20)
                rezultat2 = "Normal";
            else
                rezultat2 = "Ok";
            detalii.Rezultat1 = rezultat1;
            detalii.Rezultat2 = rezultat2;
            _context.Detaliis.Add(detalii);
            _context.SaveChanges();
        }

        public void Delete(Detalii detalii)
        {
            _context.Detaliis.Remove(detalii);
            _context.SaveChanges();
        }

        public void Edit(Detalii detalii)
        {
            float inaltimea = detalii.Inaltimea;
            var greutate = detalii.Greutate;
            inaltimea = inaltimea / 100f;
            string rezultat2;                        
            var rezultat1 = greutate / (inaltimea * inaltimea);
            if (rezultat1 > 30)
                rezultat2 = "Obez";
            else
                if (rezultat1 < 30 && rezultat1 > 20)
                rezultat2 = "Normal";
            else
                rezultat2 = "Ok";
            detalii.Rezultat1 = rezultat1;
            detalii.Rezultat2 = rezultat2;
            _context.Detaliis.Update(detalii);
            _context.SaveChanges();
        }

        public List<Detalii> GetAllDetalii()
        {
            return _context.Detaliis.ToList();
        }

        public List<Detalii> GetDetaliiByUserId(string userId)
        {
            return _context.Detaliis.Where(d => d.UserId.Equals(userId)).ToList();
        }

        public Detalii GetSingleDetalii(int id)
        {
            var detalii = _context.Detaliis.FirstOrDefault(p => p.Id == id);
            return detalii;
        }
    }
}
