using Final_IS.Models;
using System.Threading.Tasks;

namespace Final_IS.Repositories
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetCarsAsync();
        Task<Car> GetCarAsync(int id);
        Task<Car> AddCarAsync(Car car);
        Task<Car> UpdateCarAsync(Car car);
        Task<bool> DeleteCarAsync(int id);
        Task<bool> CarExistsAsync(int id);
    }
}
