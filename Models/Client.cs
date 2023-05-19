using System.Globalization;

namespace AutoMapper.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

    }
}
