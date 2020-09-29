using PeaceOfMind.Data;
using PeaceOfMind.Models.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaceOfMind.Services
{
    public class JobService
    {
        private readonly Guid _userId;

        public JobService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateJob(JobCreate model)
        {
            var entity =
                new Job()
                {
                    ClientId = model.ClientId,
                    ServiceId = model.ServiceId,
                    StartTime = model.StartTime,
                    Note = model.Note
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Jobs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<JobListItem> GetJobs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Jobs
                        .Select(
                            e =>
                                new JobListItem
                                {
                                    JobId = e.JobId,
                                    ClientId = e.ClientId,
                                    ServiceId = e.ServiceId,
                                    StartTime = e.StartTime,
                                    EndTime = e.EndTime
                                }
                        );

                return query.ToArray();
            }
        }

        public JobDetail GetJobById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Jobs
                        .Single(e => e.JobId == id);
                return
                    new JobDetail
                    {
                        JobId = entity.JobId,
                        ServiceId = entity.ServiceId,
                        StartTime = entity.StartTime,
                        EndTime = entity.EndTime,
                        Note = entity.Note
                    };
            }
        }

        public bool UpdateNote(JobEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Jobs
                        .Single(e => e.JobId == model.JobId);

                entity.ClientId = model.ClientId;
                entity.ServiceId = model.ServiceId;
                entity.StartTime = model.StartTime;
                entity.Note = model.Note;


                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteNote(int serviceId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Jobs
                        .Single(e => e.JobId == serviceId);

                ctx.Jobs.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
