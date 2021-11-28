using desafioBackend.Data;
using desafioBackend.Entities;
using desafioBackend.InterfaceServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace desafioBackend.Controllers
{
    [ApiController]
    [Route("api/cep")]
    public class AddressController : ControllerBase
    {
        
        private readonly IAddressService _addressService;
        public AddressController(DataContext context, IAddressService addressService)
        {
            _addressService = addressService;
        }
        [HttpGet]
        [Route("")]
        public async Task<Response> GetAddress([FromQuery] string cep)
        {
            var response = new Response();
            response.Data = await _addressService.GetAddress(cep);
            return response;
        }
        [HttpPost]
        [Route("")]
        public async Task<Response> CreateAddress([FromQuery] string cep)
        {
            var response = new Response();
            response.Data = await _addressService.CreateAddress(cep);
            return response;
        }
    }
}
