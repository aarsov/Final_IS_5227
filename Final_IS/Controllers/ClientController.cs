using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Final_IS.DTOs;
using Final_IS.Models;
using Final_IS.Data;

namespace Final_IS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ClientController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Client
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDTO>>> GetClients()
        {
            return await _context.Clients
                .Select(c => new ClientDTO
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    DOB = c.DOB,
                    Address = c.Address,
                    Nationality = c.Nationality,
                    RentalStartDate = c.RentalStartDate,
                    CarId = c.CarId
                })
                .ToListAsync();
        }

        // GET: api/Client/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDTO>> GetClient(int id)
        {
            var client = await _context.Clients.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            var clientDTO = new ClientDTO
            {
                Id = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                DOB = client.DOB,
                Address = client.Address,
                Nationality = client.Nationality,
                RentalStartDate = client.RentalStartDate,
                CarId = client.CarId
            };

            return clientDTO;
        }

        // PUT: api/Client/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, ClientDTO clientDTO)
        {
            if (id != clientDTO.Id)
            {
                return BadRequest();
            }

            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            client.FirstName = clientDTO.FirstName;
            client.LastName = clientDTO.LastName;
            client.DOB = clientDTO.DOB;
            client.Address = clientDTO.Address;
            client.Nationality = clientDTO.Nationality;
            client.RentalStartDate = clientDTO.RentalStartDate;

            client.CarId = clientDTO.CarId;

            _context.Entry(client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Client
        [HttpPost]
        public async Task<ActionResult<ClientDTO>> PostClient(ClientDTO clientDTO)
        {
            var client = new Client
            {
                FirstName = clientDTO.FirstName,
                LastName = clientDTO.LastName,
                DOB = clientDTO.DOB,
                Address = clientDTO.Address,
                Nationality = clientDTO.Nationality,
                RentalStartDate = clientDTO.RentalStartDate,
                CarId = clientDTO.CarId
            };

            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            clientDTO.Id = client.Id;

            return CreatedAtAction(nameof(GetClient), new { id = clientDTO.Id }, clientDTO);
        }

        // DELETE: api/Client/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientExists(int id)
        {
            return _context.Clients.Any(e => e.Id == id);
        }
    }
}

