using Final_IS.DTOs;


namespace Final_IS.Repositories
{
    public class ClientRepository
    {
        private readonly List<ClientDTO> _clients;

        public ClientRepository()
        {
           
            _clients = new List<ClientDTO>();
        }

        public void Add(ClientDTO client)
        {
         
            client.Id = _clients.Count + 1;
            _clients.Add(client);
        }

        public IEnumerable<ClientDTO> GetAll()
        {
      
            return _clients;
        }

        public ClientDTO GetById(int id)
        {
           
            return _clients.FirstOrDefault(c => c.Id == id);
        }

        public void Update(ClientDTO client)
        {
            var existingClient = _clients.FirstOrDefault(c => c.Id == client.Id);
            if (existingClient != null)
            {
                existingClient.FirstName = client.FirstName;
                existingClient.LastName = client.LastName;
                existingClient.DOB = client.DOB;
                existingClient.Address = client.Address;
                existingClient.Nationality = client.Nationality;
                existingClient.RentalStartDate = client.RentalStartDate;
                existingClient.RentalEndDate = client.RentalEndDate;
                existingClient.CarId = client.CarId;
            }
        }

        public void Delete(int id)
        {
          
            var clientToRemove = _clients.FirstOrDefault(c => c.Id == id);
            if (clientToRemove != null)
            {
                _clients.Remove(clientToRemove);
            }
        }
    }
}
