using Licenta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Licenta.Repository
{
    public interface IDetaliiRepository
    {
        void Create(Detalii detalii);

        void Edit(Detalii detalii);

        Detalii GetSingleDetalii(int id);

        void Delete(Detalii detalii);

        List<Detalii> GetAllDetalii();

        List<Detalii> GetDetaliiByUserId(string userId);
    }
}
