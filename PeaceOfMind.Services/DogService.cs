using PeaceOfMind.Data;
using PeaceOfMind.Models.Dog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaceOfMind.Services
{
    public class DogService
    {
        private readonly Guid _userId;

        public DogService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateDog(DogCreate model)
        {
            var entity =
                new Dog()
                {
                    Name = model.Name,
                    ClientId = model.ClientId,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Dogs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<DogListItem> GetDogs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Dogs
                        .Select(
                            e =>
                                new DogListItem
                                {
                                    DogId = e.DogId,
                                    Name = e.Name,
                                }
                        );

                return query.ToArray();
            }
        }

        public DogDetail GetDogById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Dogs
                        .Single(e => e.DogId == id);
                return
                    new DogDetail
                    {
                        DogId = entity.DogId,
                        Name = entity.Name,
                        ClientId = entity.ClientId,
                    };
            }
        }

        public bool UpdateDog(DogEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Dogs
                        .Single(e => e.DogId == model.DogId);

                entity.Name = model.Name;
                entity.ClientId = model.ClientId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteDog(int serviceId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Dogs
                        .Single(e => e.DogId == serviceId);

                ctx.Dogs.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
