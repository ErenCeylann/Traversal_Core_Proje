﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IReservationService:IGenericService<Reservation>
    {
        //List<Reservation> GetListApprovalReservation(int id);
        List<Reservation> GetListWithReservationByWaitAprroval(int id);
        List<Reservation> GetListWithReservationByWaitPrevious(int id);
        List<Reservation> GetListWithReservationByWaitAccepted(int id);
    }
}
