using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services.Interface
{
    public interface IStudentService
    {
        Student Create(int GroupId, Student student);

        Student Update(int id, Student student);

        Student Delete(int id);

        Student GetById(int id);

        List<Student> GetAll();

        List<Student> Search(string name);




    }
}
