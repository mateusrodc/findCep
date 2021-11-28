using desafioBackend.Entities;
using desafioBackend.InterfaceRepository;
using desafioBackend.InterfaceServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace desafioBackend.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<Address> GetAddress(string cep)
        {
            var tratamentoCep = ValidaCEP(cep);
            if(tratamentoCep)
            {
                return await _addressRepository.GetAddress(cep);
            }
            else
            {
                throw new Exception("CEP em formato inválido!");
            }
        }
        public async Task<bool> CreateAddress(string cep)
        {
            var tratamentoCep = ValidaCEP(cep);
            if (tratamentoCep) 
            {
                var existeCep = await _addressRepository.GetAddress(cep);
                if (existeCep != null)
                {
                    throw new Exception("Endereço já existe na base de dados!");
                }
                return await _addressRepository.CreateAddress(cep);
            }
            else
            {
                throw new Exception("CEP em formato inválido!");
            }
            
        }
        public bool ValidaCEP(string cep)
        {
            Regex Rgx = new Regex(@"^\d{5}-\d{3}$");

            if (!Rgx.IsMatch(cep))
            {
                return false;
            } 
            else
            {
                return true;
            }  
        }
    }
}
