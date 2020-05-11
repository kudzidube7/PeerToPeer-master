using Microsoft.EntityFrameworkCore;
using PeerToPeer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace PeerToPeer.Repositories.Interface.Implementations
{
    public class StudentRepository : IStudentRepository
    {
        private PeerToPeerContext context;
        public StudentRepository(PeerToPeerContext context)
        {
            this.context = context;
        }

        public Student createStudent(Student student)
        {
           
            context.Students.Add(student);
            context.SaveChanges();
            return student;
        }
        public IEnumerable<Student> getAllStudents()
        {
            IEnumerable<Student> students = context.Students.Include(navigationPropertyPath: p => p.StudentDonations);
            return students;
        }
        public Student getStudent(int id)
        {
            Student student;
            IEnumerable<Student> students = context.Students
                .Where(x => x.Id == id)
                .Include(navigationPropertyPath: p => p.StudentDonations);
            student = students.FirstOrDefault();

            return student;

        }

        public Student updateStudent(Student student)
        {
            context.Entry(student).State = EntityState.Modified;
            context.SaveChanges();

            return student;
        }

        public Student deleteStudent(int id)
        {
            Student student;
            student = context.Students.Where(x => x.Id == id).FirstOrDefault();
            student.isDeleted = true;
            context.SaveChanges();

            return student;

        }
       
    }
}
