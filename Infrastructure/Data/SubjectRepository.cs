using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
// using ResearchAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class SubjectRepository : ISubjectRepository
    {

        ResearchStudyContext _context;

        public SubjectRepository(ResearchStudyContext context)
        {
            _context = context;
            // FH 6/22/2018 set notraking ?
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task Add(Subject subject)
        {
            await _context.AddAsync(subject);
            await _context.SaveChangesAsync();
        }

        public async Task<Subject> Find(int id)
        {
            var subject = new Subject();
            
            subject = await _context.Subject.Where(s => s.SubjectId == id)
               .Include(s => s.Address)
               .Include(s => s.Phone).ThenInclude(s => s.PhoneType)
               .SingleOrDefaultAsync();

            if (subject != null)
            {
                // order by phone type (can't do it in above)
                subject.Phone = subject.Phone.OrderBy(x => x.PhoneType.PhoneType1).ToList();
            }
           
            return subject;
        }

        public async Task<IEnumerable<Subject>> GetAll()
        {
            return await _context.Subject.ToListAsync();
        }

        public async Task<Subject> Delete(int id)
        {
            var subject = await _context.Subject.SingleOrDefaultAsync(m => m.SubjectId == id);
            if (subject != null)
            {
                _context.Subject.Remove(subject);
                await _context.SaveChangesAsync();
            }

            return subject;
            // what to do if not found !!!!!!!!!!!!!!!!
        }

            public async Task Update(Subject subject)
        {
            
            // remove deleted phones
            var originalPhone = _context.Phone.Where(p => p.SubjectId == subject.SubjectId);
            foreach (var ph in originalPhone)
            {
                var phoneExists = subject.Phone.Where(p => p.PhoneId == ph.PhoneId);
                if ( !phoneExists.Any() )
                {
                    _context.Entry(ph).State = EntityState.Deleted;
                }
            }

            _context.Update(subject);
       
            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<PhoneType>> GetPhoneTypes()
        {
            //return await _context.PhoneType.Select(x => new
            //{
            //    x.PhoneTypeId,
            //    x.PhoneType1
            //}).ToListAsync();

            return await _context.PhoneType.OrderBy(p => p.PhoneType1).ToListAsync();
        }

        // check for duplicate SSN
        public async Task<bool> SSNExists(string ssn)
        {
            return await _context.Subject.AnyAsync(s => s.Ssn == ssn);
        }

    }
}
