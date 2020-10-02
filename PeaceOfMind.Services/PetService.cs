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

        public PetService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePet(PetCreate model)
        {
            var entity =
                new Pet()
                {
                    Name = model.Name,
                    PetType = model.Type,
                    ClientId = model.ClientId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Pets.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<Client> GetOwners()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Clients.ToList();
            }
        }

        public IEnumerable<PetListItem> GetPets()
        {
            using (var ctx = new ApplicationDbContext())
            {
                //var query =
                //    ctx
                //        .Pets
                //        .Select(
                //            e =>
                //                new PetListItem
                //                {
                //                    PetId = e.PetId,
                //                    Name = e.Name,
                //                    Owner = e.Owner.FirstName
                //                }
                //        );
                //return query.ToArray();

                var pets = ctx.Pets.ToList();
                var petList = new List<PetListItem>();

                foreach (var pet in pets)
                {
                    var newPet = new PetListItem
                    {
                        PetId = pet.PetId,
                        Name = pet.Name,
                        Owner = pet.Owner.FullName
                    };
                    petList.Add(newPet);
                }

                return petList;

            }
        }

        // Why can I access Owner.FullName below but not above?

        public PetDetail GetPetById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Pets
                        .Single(e => e.PetId == id);
                return
                    new PetDetail
                    {
                        PetId = entity.PetId,
                        Name = entity.Name,
                        Owner = entity.Owner.FullName,
                        Type = entity.PetType
                    };
            }
        }

        public bool UpdatePet(PetEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Pets
                        .Single(e => e.PetId == model.PetId);

                entity.Name = model.Name;
                entity.ClientId = model.ClientId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePet(int serviceId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Pets
                        .Single(e => e.PetId == serviceId);

                ctx.Pets.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }

}
