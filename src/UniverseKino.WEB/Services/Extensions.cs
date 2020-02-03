using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UniverseKino.Data.EF;
using UniverseKino.Data.Entities;

namespace UniverseKino.WEB.Services
{
    public static class Extensions
    {
        public static ApplicationUser GetUserFromToken(this UniverseKinoContext context, ClaimsPrincipal userClaims)
        {
            return context.ApplicationUsers.Where(u => u.Username == userClaims.Identity.Name).FirstOrDefault();
        }

        public static T GetEntities<T>(this UniverseKinoContext context,int? id = null, List<T> entites = null) where T : BaseEntity
        {
            if (entites != null)
            {
                entites = context.Set<T>().ToList();
                return null;
            }

            return context.Set<T>().Where(s => s.Id == id).FirstOrDefault();
        }

        public static bool IsBusySeat(this Session session, int seatId)//Generic method for rovnih pacikov
        {
            return session.Reservations.Where(x => x.Session.Id == session.Id && x.Seat.Id == seatId).FirstOrDefault() != null;
        }
    }
}
