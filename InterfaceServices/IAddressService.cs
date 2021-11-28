using desafioBackend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace desafioBackend.InterfaceServices
{
    public interface IAddressService
    {
        public Task<Address> GetAddress(string cep);
        public Task<bool> CreateAddress(string cep);
    }
}
