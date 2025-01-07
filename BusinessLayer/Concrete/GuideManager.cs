
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
    public class GuideManager : IGuideService
    {
        IGuideDal _guideDal;

        public GuideManager(IGuideDal guideDal)
        {
            _guideDal = guideDal;
        }

        public Guide GetById(int id)
        {
            return _guideDal.GetById(id);
        }

        public List<Guide> GetList()
        {
           return _guideDal.GetList();
        }

        public void TAdd(Guide t)
        {
            _guideDal.Insert(t);
        }

        public void TChangToFalseByGuide(int id)
        {
            _guideDal.ChangToFalseByGuide(id);
        }

        public void TChangToTrueByGuide(int id)
        {
            _guideDal.ChangToTrueByGuide(id);
        }

        public void TDelete(Guide t)
        {
            _guideDal.Delete(t);
        }

        public void TUpdate(Guide t)
        {
            _guideDal.Update(t);
        }
    }
}
