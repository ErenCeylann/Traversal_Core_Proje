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
    public class TestimonialManager:ITestimonialService
    {
        ITestimonialDal _Testimonialdal;

        public TestimonialManager(ITestimonialDal testimonialdal)
        {
            _Testimonialdal = testimonialdal;
        }

        public Testimonial GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Testimonial> GetList()
        {
           return _Testimonialdal.GetList();
        }

        public void TAdd(Testimonial t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Testimonial t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Testimonial t)
        {
            throw new NotImplementedException();
        }
    }
}
