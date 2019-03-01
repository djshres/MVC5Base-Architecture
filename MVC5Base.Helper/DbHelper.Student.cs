using MVC5Base.Entities;
using MVC5Base.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVC5Base.Helper
{
    public partial class DbHelper
    {
        public List<StudentViewModel> GetStudents()
        {
            var list = new List<StudentViewModel>();

            new Repository<Student>(_context).FindAll().ToList().ForEach(x => list.Add(x.ToVM()));

            return list;
        }

        public StudentViewModel GetStudentById(int id)
        {
            return new Repository<Student>(_context).FindById(id).ToVM();
        }

        public StudentViewModel GetStudentByUserId(int userId)
        {
            return new Repository<Student>(_context).Find(x => x.UserId == userId).FirstOrDefault().ToVM();
        }

        public bool AddStudent(string name, string address, int age, string email, string username, string password)
        {
            var objUser = new User
            {
                Username = username,
                Password = password,
                RoleId = 2
            };

            var objStudent = new Student
            {
                Name = name,
                Address = address,
                Age = age,
                Email = email,
                User = objUser
            };

            try
            {
                new Repository<Student>(_context).Add(objStudent);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EditStudent(int id, string name, string address, int age, string email)
        {
            var userRepo = new Repository<Student>(_context);

            var objStudent = userRepo.FindById(id);
            objStudent.Name = name;
            objStudent.Address = address;
            objStudent.Age = age;
            objStudent.Email = email;

            try
            {
                userRepo.Update(objStudent, id);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine((ex));
                return false;
            }
        }
        public bool DeleteStudent(int id)
        {
            var userRepo = new Repository<Student>(_context);

            var objClient = userRepo.FindById(id);

            try
            {
                userRepo.Remove(objClient, true);
                return true;
            }

            catch (Exception ex)
            {
                Console.WriteLine((ex));
                return false;
            }
        }
    }
}
