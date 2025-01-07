using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDal _AboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _AboutDal = aboutDal;
        }

        public About GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<About> GetList()
        {
           return _AboutDal.GetList();
        }

        public void TAdd(About t)
        {
            _AboutDal.Insert(t);
        }

        public void TDelete(About t)
        {
            _AboutDal.Delete(t);
        }

        public void TUpdate(About t)
        {
            _AboutDal.Update(t);
        }
    }
}
