using PeaceOfMind.Data;
using PeaceOfMind.Models.Pet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaceOfMind.Services
{
    public class PetService
    {
        private readonly Guid _userId;
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public PetService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePet(PetCreate model)
        {
            var entity = new Pet
            {
                Name = model.Name,
                TypeOfPet = model.TypeOfPet,
                ClientId = model.ClientId
            };

            _context.Pets.Add(entity);
            return _context.SaveChanges() == 1;
        }

        public IEnumerable<PetListItem> GetPets()
        {
            return _context.Pets.Select(e => new PetListItem
            {
                PetId = e.PetId,
                Name = e.Name,
                Owner = e.Owner.FirstName + " " + e.Owner.LastName,
                TypeOfPet = e.TypeOfPet
            }).ToArray();
        }

        public PetDetail GetPetById(int id)
        {
            var entity = _context.Pets.Find(id);

            return new PetDetail
            {
                PetId = entity.PetId,
                ClientId = entity.Owner.ClientId,
                Name = entity.Name,
                Owner = entity.Owner.FirstName + " " + entity.Owner.LastName,
                TypeOfPet = entity.TypeOfPet
            };
        }

        public bool UpdatePet(PetEdit model)
        {
            var entity = _context.Pets.Find(model.PetId);

            entity.Name = model.Name;
            entity.ClientId = model.ClientId;
            entity.TypeOfPet = model.TypeOfPet;

            return _context.SaveChanges() == 1;
        }

        public bool DeletePet(int id)
        {
            _context.Pets.Remove(_context.Pets.Find(id));
            return _context.SaveChanges() == 1;
        }

        // Gets client ids and names for drop down list
        public List<ClientDropDown> GetOwners()
        {
            return _context.Clients.Select(e => new ClientDropDown
            {
                ClientId = e.ClientId,
                Name = e.FirstName + " " + e.LastName
            }).ToList();
        }
    }
}
