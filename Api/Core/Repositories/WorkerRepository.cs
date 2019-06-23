﻿using FirmaBudowlana.Core.Models;
using FirmaBudowlana.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirmaBudowlana.Core.Repositories
{
    public class WorkerRepository : IWorkerRepository
    {
        private readonly DBContext _context;

        public WorkerRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<Worker> GetAsync(Guid id)
        {
             var worker = await _context.Workers.AsNoTracking().SingleOrDefaultAsync(x => x.WorkerID == id);
             worker.WorkerTeam = await _context.WorkerTeam.Where(x => x.WorkerID == worker.WorkerID).ToListAsync();
             return worker;
        }


        public async Task<IEnumerable<Worker>> GetAllAsync()
        {
            var workers = await _context.Workers.ToListAsync();

            foreach (var worker in workers)
            {
                worker.WorkerTeam = await _context.WorkerTeam.Where(x => x.WorkerID == worker.WorkerID).ToListAsync();
            }

            return workers;

        }

        public async Task<IEnumerable<Worker>> GetAllActiveAsync()
        {
            var workers = await _context.Workers.Where(x => x.Active == true).ToListAsync();

            foreach (var worker in workers)
            {
                worker.WorkerTeam = await _context.WorkerTeam.Where(x => x.WorkerID == worker.WorkerID).ToListAsync();
            }

            return workers;
        }
       

        public async Task AddAsync(Worker Worker)
        {
            await _context.Workers.AddAsync(Worker);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Worker worker)
        {
            _context.Workers.Remove(worker);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Worker Worker)
        {
            _context.Workers.Update(Worker);
            await _context.SaveChangesAsync();
        }

      
    }
}
