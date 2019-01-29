using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface ISubjectService
    {

        Task<Subject> Find(int id);
        Task<IEnumerable<Subject>> GetAll();
        Task<Subject> Delete(int id);
        Task Update(Subject subject);
        Task Add(Subject subject);

    }
}
