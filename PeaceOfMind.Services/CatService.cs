using PeaceOfMind.Data;
using PeaceOfMind.Models.Cat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaceOfMind.Services
{
    public class CatService
    {
        private readonly Guid _userId;

        public CatService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCat(CatCreate model)
        {
            var entity =
                new Cat()
                {
                    Name = model.Name,
                    ClientId = model.ClientId,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Cats.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CatListItem> GetCats()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Cats
                        .Select(
                            e =>
                                new CatListItem
                                {
                                    CatId = e.CatId,
                                    Name = e.Name,
                                }
                        );

                return query.ToArray();
            }
        }

        public CatDetail GetCatById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Cats
                        .Single(e => e.CatId == id);
                return
                    new CatDetail
                    {
                        CatId = entity.CatId,
                        Name = entity.Name,
                        ClientId = entity.ClientId,
                    };
            }
        }

        public bool UpdateNote(CatEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Cats
                        .Single(e => e.CatId == model.CatId);

                entity.Name = model.Name;
                entity.ClientId = model.ClientId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteNote(int serviceId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Cats
                        .Single(e => e.CatId == serviceId);

                ctx.Cats.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
