using desafioBackend.Data;
using desafioBackend.Entities;
using desafioBackend.InterfaceRepository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace desafioBackend.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DataContext _context;
        static readonly HttpClient client = new HttpClient();
        public AddressRepository( DataContext context)
        {
            _context = context;
        }
        public async Task<Address> GetAddress(string cep)
        {
            var response = await FindAddress(cep);
            var validate = ValidateRequest(response);
            if(validate != null)
            {
                return _context.Address.Where(x => x.Cep == validate.Cep).FirstOrDefault();
            }
            
            return null;

        }
        static async Task<ActionResult<string>> FindAddress(string cep)
        {
            string url = "https://viacep.com.br/ws/" + cep + "/json/";
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            
            return responseBody;
        }
        private Address ValidateRequest(ActionResult<string> response)
        {
            if (!String.IsNullOrEmpty(response.Value) && !response.Value.Contains("{\n  \"erro\": true\n}"))
            {
                JObject json = JObject.Parse(response.Value);
                var address = new Address(
                    json["cep"].ToString(),
                    json["logradouro"].ToString(),
                    json["complemento"].ToString(),
                    json["bairro"].ToString(),
                    json["localidade"].ToString(),
                    json["uf"].ToString(),
                    Int32.Parse(json["ibge"].ToString()),
                    json["gia"].ToString(),
                    Int32.Parse(json["ddd"].ToString()),
                    Int32.Parse(json["siafi"].ToString()));
                return address;

            }
            else if (response.Value.Contains("{\n  \"erro\": true\n}"))
            {
                throw new Exception("CEP inexistente!");
            }
            return null;
        }
        public async Task<bool> CreateAddress(string cep)
        {
            var result = await FindAddress(cep);
            var validate = ValidateRequest(result);
            if (validate != null)
            {
                var address = new Address(validate.Cep, validate.Logradouro, validate.Complemento, validate.Bairro, validate.Localidade, validate.UF, validate.IBGE, validate.Gia, validate.DDD, validate.Siafi);
                _context.Address.Add(address);
                _context.SaveChanges();
            }
            return true;
        }
    }
}
