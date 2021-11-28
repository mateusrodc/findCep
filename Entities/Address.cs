using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace desafioBackend.Entities
{
    public class Address
    {
        public long Id { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string UF { get; set; }
        public int IBGE { get; set; }
        public string Gia { get; set; }
        public int DDD { get; set; }
        public int Siafi { get; set; }
        public Address()
        {

        }
        public Address(string cep, string logradouro, string complemento, string bairro, string localidade, string uf, int ibge, string gia, int ddd, int siafi)
        {
            Cep = cep;
            Logradouro = logradouro;
            Complemento = complemento;
            Bairro = bairro;
            Localidade = localidade;
            UF = uf;
            IBGE = ibge;
            Gia = gia;
            DDD = ddd;
            Siafi = siafi;
        }
    }
}
