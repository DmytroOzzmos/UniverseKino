using System;
using UniverseKino.Data.Entities;

namespace UniverseKino.Data.Interfaces
{
    public interface IClientManager : IDisposable
    {
        void Create(ClientProfile item);
    }
}