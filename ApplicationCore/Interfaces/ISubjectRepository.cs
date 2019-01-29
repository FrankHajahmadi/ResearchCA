using ApplicationCore.Entities;
// using ResearchAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface ISubjectRepository
    {
        Task<IEnumerable<Subject>> GetAll();
        Task<Subject> Find(int id);
        Task Add(Subject subject);
        Task Update(Subject subject);
        Task<Subject> Delete(int id);
        Task<IEnumerable<PhoneType>> GetPhoneTypes();
        Task<Boolean> SSNExists(string ssn);

    }
}
