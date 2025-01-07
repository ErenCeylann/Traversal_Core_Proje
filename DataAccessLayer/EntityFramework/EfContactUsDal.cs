using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfContactUsDal : GenericRepository<ContactUs>, IContactUsDal
    {
        public void ContactUsStatusChangToFalse(int id)
        {
            Context c= new Context();
            var values = c.ContactUses.Find(id);
            values.ContactUsStatus = false;
            c.Update(values);
            c.SaveChanges();
        }

        public List<ContactUs> GetListContactUsByFalse()
        {
            using (Context c = new Context())
            {
                var values = c.ContactUses.Where(x => x.ContactUsStatus == false).ToList();
                return values;
            }
        }

        public List<ContactUs> GetListContactUsByTrue()
        {
            using (Context c = new Context())
            {
                var values = c.ContactUses.Where(x => x.ContactUsStatus == true).ToList();
                return values;
            }
        }
    }
}
