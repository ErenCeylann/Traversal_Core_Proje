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
    public class SubAbouManager:ISubAboutSerivce
    {
        ISubAboutDal _subAboutDal;

        public SubAbouManager(ISubAboutDal subAboutDal)
        {
            _subAboutDal = subAboutDal;
        }

        public SubAbout GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<SubAbout> GetList()
        {
            return _subAboutDal.GetList();
        }

        public void TAdd(SubAbout t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(SubAbout t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(SubAbout t)
        {
            throw new NotImplementedException();
        }
    }
}
