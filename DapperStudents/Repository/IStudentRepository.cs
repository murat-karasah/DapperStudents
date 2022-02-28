using DapperStudents.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperStudents.Repository
{
   public interface IStudentRepository
    {
        List<Student> GetAll();
        List<Student> GetFilter(string name = null, int? age1 = null, int? age2 = null);

        Student Find(int id);
        Student Add(Student student);
        Student Update(Student student);
        void Remove(int id);

    }
}
