using System;
using System.Collections.Generic;
using System.Text;
using UniverseKino.Services.Dto;

namespace UniverseKino.Services.Interfaces
{
    public interface IManageMoviesService
    {
        void Add(MovieDTO session);
        void Update(MovieDTO session);
        bool Remove(int id);
    }
}
