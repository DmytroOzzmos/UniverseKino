using System;
using System.Collections.Generic;
using System.Text;
using UniverseKino.Data.Entities;
using UniverseKino.Services.Dto;

namespace UniverseKino.Services.Interfaces
{
    public interface IManageSessionsService
    {
        void Add(SessionDTO session);
        void Update(SessionDTO session);
        bool Remove(int id);
    }
}
