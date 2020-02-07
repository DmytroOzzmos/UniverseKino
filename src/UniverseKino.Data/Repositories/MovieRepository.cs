using System.Threading.Tasks;
using UniverseKino.Data.EF;
using UniverseKino.Data.Entities;
using UniverseKino.Data.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace UniverseKino.Data.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(UniverseKinoContext dbContext)
            : base(dbContext) { }
    }
}
