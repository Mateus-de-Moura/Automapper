using AutoMapper;
using AutoMapper.ClientDTO;
using AutoMapper.Models;
using Automapperr.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Automapperr.Controllers
{
    [Route("api/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;

        public HomeController(IMapper Mapper, ApiContext context)
        {
            _context = context;
            _mapper = Mapper;
        }

        [HttpPost("Client")]
        public async Task<IActionResult> AddCliet(Client client)
        {
            Log.Information($" O USUÁRIO {Environment.UserName.ToUpper()} ENTROU NO METODO POST");

            if (client is null)
                return BadRequest(new ClientDTO());

            await _context.clients.AddAsync(client);
            await _context.SaveChangesAsync();

            var ClietMapDTO = _mapper.Map<ClientDTO>(client);

            return Ok(ClietMapDTO);
        }

        [HttpGet("Cliets")]
        public async Task<IActionResult> GetCliet()
        {
            try
            {
                var Clients = await _context.clients.ToListAsync();

                if (Clients.Any())
                {
                    Log.Information($"{Environment.UserName.ToUpper()} - ACESSOU O METODO GETCLIENTS");
                    return Ok(Clients);
                }

                return NotFound();

            }
            catch (Exception ex)
            {
                Log.Error("Erro" + ex.Message);

                return BadRequest();
            }

        }

        [HttpPut]
        public async Task<IActionResult> PutClient(Client Client)
        {
            if (Client is not null)
            {
                var ClientRegistred = _context.clients.FirstOrDefault(x => x.Id == Client.Id);

                if (ClientRegistred != null)
                {
                    ClientRegistred = Client;
                    await _context.SaveChangesAsync();

                    var cleintMapDTO = _mapper.Map<ClientDTO>(Client);

                    return Ok(cleintMapDTO);
                }
                else
                {
                    return NotFound();
                }
            }

            return BadRequest();        
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteClientAsync(int Id)
        {
            var ClientExist = _context.clients.FirstOrDefault(x => x.Id.Equals(Id));

            if (ClientExist != null)
            {
                _context.clients.Remove(ClientExist);
                await _context.SaveChangesAsync();

                Log.Information($"Client Deletado Id: {ClientExist.Id} for User {Environment.UserName.ToUpper()} ");
                return Ok("Usuário deletado");
            }
            return NotFound("User not found");
        }
    }
}
