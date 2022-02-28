using DapperStudents.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperStudents.ViewsModels
{
    public class StudentModel
    {
        public Student Student{ get; set; }
        public List<Student> sList{ get; set; }

    }
}
