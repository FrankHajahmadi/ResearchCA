using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public async Task<Subject> Find(int id)
        {
            return await _subjectRepository.Find(id);
        }

        public async Task<IEnumerable<Subject>> GetAll()
        {
            return await _subjectRepository.GetAll();
        }

        public async Task<Subject> Delete(int id)
        {
            return await _subjectRepository.Delete(id);
        }

        public async Task Update(Subject subject)
        {
            foreach (var phone in subject.Phone)
            {
                phone.PhoneNumber = Utility.RemoveNonDigits(phone.PhoneNumber);
            }

            await _subjectRepository.Update(subject);
        }
        
        public async Task Add(Subject subject)
        {
            await _subjectRepository.Add(subject);
        }
    }
}
