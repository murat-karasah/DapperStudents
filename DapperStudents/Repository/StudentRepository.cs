using Dapper;
using DapperStudents.Context;
using DapperStudents.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DapperStudents.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private IDbConnection db;
        

        public StudentRepository(IConfiguration configuration)
        {
            this.db = new SqlConnection(configuration.GetConnectionString("SqlConnection"));
        }
        

        public Student Add(Student student)
        {
            var sql = "INSERT INTO Student(Name,Age) VALUES (@Name,@Age);" + "SELECT CAST(SCOPE_IDENTITY() as int)";
            var id = db.Query<int>(sql, student).Single();
            student.Id = id;
            return student;
        }

        public Student Find(int id)
        {
            var sql = "SELECT * FROM Student WHERE id=@Studentid";
            return db.Query<Student>(sql, new { Studentid = id }).Single();
        }

        public List<Student> GetAll()
        {
            var sql = "SELECT * FROM Student";
            return db.Query<Student>(sql).ToList();
        }

        public List<Student> GetFilter(string name , int? age1 , int? age2 = null)
        {
           
                if (name!=null || age1 != null && age2 != null)
                {
                    if (name!=null)
                    {
                        var a = "SELECT * FROM Student WHERE Name LIKE CONCAT('%',@name,'%')";
                        return db.Query<Student>(a, new { @name = name }).ToList();
                    }
                    else
                    {
                        var a = "SELECT * FROM Student WHERE Age BETWEEN @age1 AND @age2";
                        return db.Query<Student>(a, new {@age1=age1,@age2=age2 }).ToList();
                        
                    }
                }

            else if (name != null && age1 != null && age2 != null)
            {
                var a = "SELECT * FROM Student WHERE Name LIKE CONCAT('%',@name,'%') AND Age BETWEEN @age1 AND @age2";
                return db.Query<Student>(a, new { @name = name, @age1 = age1, @age2 = age2 }).ToList();
               
            }
           
                var sql = "SELECT * FROM Student";
                return db.Query<Student>(sql).ToList();
            

           
            
            

        }

        public void Remove(int id)
        {
            var sql = "DELETE FROM Student WHERE ID=@Studentid";
            db.Query(sql, new { @Studentid = id });
        }

        public Student Update(Student student)
        {
            var sql = "UPDATE Student SET Name=@Name,Age=@Age WHERE id=@id";
            db.Execute(sql, student);
            return student;
        }
    }
}
