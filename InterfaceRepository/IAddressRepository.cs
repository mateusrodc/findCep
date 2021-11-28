using desafioBackend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace desafioBackend.InterfaceRepository
{
    public interface IAddressRepository
    {
        public Task<Address> GetAddress(string cep);
        public Task<bool> CreateAddress(string cep);
    }
}
