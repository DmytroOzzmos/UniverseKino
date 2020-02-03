using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniverseKino.WEB.Services
{
    public interface IReservationServie
    {
        void ToBook(ReservationRequestModel reservation);
    }

    public class ReservationService
    {
    }
}
