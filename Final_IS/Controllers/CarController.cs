using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Final_IS.Data;
using Final_IS.Models;
using Final_IS.DTO;

namespace Final_IS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public CarController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Car
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarDTO>>> GetCars()
        {
            return await _context.Cars
                .Select(c => new CarDTO
                {
                    Id = c.Id,
                    LicencePlate = c.LicencePlate,
                    Model = c.Model,
                    Manufacturer = c.Manufacturer,
                    Year = c.Year
                })
                .ToListAsync();
        }

        // GET: api/Car/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarDTO>> GetCar(int id)
        {
            var car = await _context.Cars.FindAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            var carDTO = new CarDTO
            {
                Id = car.Id,
                LicencePlate = car.LicencePlate,
                Model = car.Model,
                Manufacturer = car.Manufacturer,
                Year = car.Year
            };

            return carDTO;
        }

        // PUT: api/Car/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(int id, CarDTO carDTO)
        {
            if (id != carDTO.Id)
            {
                return BadRequest();
            }

            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            car.LicencePlate = carDTO.LicencePlate;
            car.Model = carDTO.Model;
            car.Manufacturer = carDTO.Manufacturer;
            car.Year = carDTO.Year;

            _context.Entry(car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(id))
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

        // POST: api/Car
        [HttpPost]
        public async Task<ActionResult<CarDTO>> PostCar(CarDTO carDTO)
        {
            var car = new Car
            {
                LicencePlate = carDTO.LicencePlate,
                Model = carDTO.Model,
                Manufacturer = carDTO.Manufacturer,
                Year = carDTO.Year
            };

            _context.Cars.Add(car);
            await _context.SaveChangesAsync();

            carDTO.Id = car.Id;

            return CreatedAtAction(nameof(GetCar), new { id = carDTO.Id }, carDTO);
        }

        // DELETE: api/Car/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.Id == id);
        }
    }
}
