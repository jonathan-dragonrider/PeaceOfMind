using PeaceOfMind.Data;
using PeaceOfMind.Models.Horse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaceOfMind.Services
{
    public class HorseService
    {
        private readonly Guid _userId;

        public HorseService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateHorse(HorseCreate model)
        {
            var entity =
                new Horse()
                {
                    Name = model.Name,
                    ClientId = model.ClientId,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Horses.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<HorseListItem> GetHorses()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Horses
                        .Select(
                            e =>
                                new HorseListItem
                                {
                                    HorseId = e.HorseId,
                                    Name = e.Name,
                                }
                        );

                return query.ToArray();
            }
        }

        public HorseDetail GetHorseById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Horses
                        .Single(e => e.HorseId == id);
                return
                    new HorseDetail
                    {
                        HorseId = entity.HorseId,
                        Name = entity.Name,
                        ClientId = entity.ClientId,
                    };
            }
        }

        public bool UpdateHorse(HorseEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Horses
                        .Single(e => e.HorseId == model.HorseId);

                entity.Name = model.Name;
                entity.ClientId = model.ClientId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteHorse(int serviceId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Horses
                        .Single(e => e.HorseId == serviceId);

                ctx.Horses.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
