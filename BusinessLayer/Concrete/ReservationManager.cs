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
    public class ReservationManager : IReservationService
    {
        IReservationDal _reservationDal;

        public ReservationManager(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }

        public Reservation GetById(int id)
        {
           return _reservationDal.GetById(id);
        }

        public List<Reservation> GetList()
        {
           return _reservationDal.GetList();
        }

        public List<Reservation> GetListWithReservationByWaitAccepted(int id)
        {
            return _reservationDal.GetListWithReservationByWaitAccepted(id);
        }

        public List<Reservation> GetListWithReservationByWaitAprroval(int id)
        {
           return _reservationDal.GetListWithReservationByWaitAprroval(id);
        }

        public List<Reservation> GetListWithReservationByWaitPrevious(int id)
        {
            return _reservationDal.GetListWithReservationByWaitPrevious(id);
        }

        public void TAdd(Reservation t)
        {
            _reservationDal.Insert(t);
        }

        public void TDelete(Reservation t)
        {
            _reservationDal.Delete(t);
        }

        public void TUpdate(Reservation t)
        {
            _reservationDal.Update(t);
        }
    }
}
