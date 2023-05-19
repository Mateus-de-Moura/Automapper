using AutoMapper.ClientDTO;
using AutoMapper.Models;
using Microsoft.EntityFrameworkCore;

namespace Automapperr.Context
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
            
        }
        public DbSet<Client> clients { get; set; }
        public DbSet<ClientDTO> clientsDTO { get; set; }    
    }
}
