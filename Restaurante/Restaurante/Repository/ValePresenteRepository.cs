using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Restaurante.Repository
{
    public class ValePresenteRepository
    {
        Context db = new Context();

        public void DeleteConfirmedValePresente(int id)
        {
            CE_ValePresente ceValePresente = db.ValePresente.Find(id);
            db.ValePresente.Remove(ceValePresente);
            db.SaveChanges();
        }

        public void EditValePresente(CE_ValePresente ceValePresente)
        {
            db.Entry(ceValePresente).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void CreateValePresente(CE_ValePresente ceValePresente)
        {
            db.ValePresente.Add(ceValePresente);
            db.SaveChanges();
        }
    }
}