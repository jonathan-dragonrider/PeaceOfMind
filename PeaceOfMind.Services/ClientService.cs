using PeaceOfMind.Data;
using PeaceOfMind.Models.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaceOfMind.Services
{
    public class ClientService
    {
        private readonly Guid _userId;
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public ClientService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateClient(ClientCreate model)
        {
            var entity = new Client
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address
            };

            _context.Clients.Add(entity);
            return _context.SaveChanges() == 1;
        }

        public IEnumerable<ClientListItem> GetClients()
        {
            return _context.Clients.Select(e => new ClientListItem
            {
                ClientId = e.ClientId,
                Name = e.FirstName + " " + e.LastName
            }).ToArray();
        }

        public ClientDetail GetClientById(int id)
        {
            var entity = _context.Clients.Find(id);

            return new ClientDetail
            {
                ClientId = entity.ClientId,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber,
                Address = entity.Address
            };
        }

        public bool UpdateClient(ClientEdit model)
        {
            var entity = _context.Clients.Find(model.ClientId);
        
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.Email = model.Email;
            entity.PhoneNumber = model.PhoneNumber;
            entity.Address = model.Address;

            return _context.SaveChanges() == 1;
        }

        public bool DeleteClient(int id)
        {
            _context.Clients.Remove(_context.Clients.Find(id));
            return _context.SaveChanges() == 1;
        }
    }
}
