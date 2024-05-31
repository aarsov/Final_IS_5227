using Final_IS.DTO;


namespace Final_IS.Repositories
{
    public class CarRepository 
    {
        private readonly List<CarDTO> _cars;

        public CarRepository()
        {
            _cars = new List<CarDTO>();
        }

        public void Add(CarDTO car)
        {
            car.Id = _cars.Count + 1;
            _cars.Add(car);
        }

        public IEnumerable<CarDTO> GetAll()
        {
            return _cars;
        }

        public CarDTO GetById(int id)
        {
            return _cars.FirstOrDefault(c => c.Id == id);
        }

        public void Update(CarDTO car)
        {
            var existingCar = _cars.FirstOrDefault(c => c.Id == car.Id);
            if (existingCar != null)
            {
                existingCar.LicencePlate = car.LicencePlate;
                existingCar.Model = car.Model;
                existingCar.Manufacturer = car.Manufacturer;
                existingCar.Year = car.Year;
            }
        }

        public void Delete(int id)
        {
            var carToRemove = _cars.FirstOrDefault(c => c.Id == id);
            if (carToRemove != null)
            {
                _cars.Remove(carToRemove);
            }
        }
    }
}

