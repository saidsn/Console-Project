﻿using Domain.Models;
using Repository.Repositories;
using Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class StudentService : IStudentService
    {

        private StudentRepository _studentRepository;
        private GroupRepository _groupRepository;
        private int _count;

        public StudentService()
        {
            _studentRepository = new StudentRepository();
            _groupRepository = new GroupRepository();
        }
       

        public Student Create(int groupId, Student student)
        {
           
            var group = _groupRepository.Get(m => m.Id == groupId);
            if (group is null) return null;
            student.Id = _count;
            student.Group = group;
            _studentRepository.Create(student);
            _count++;
            return student;
        }


        public Student Delete(int id)
        {
            Student student = GetById(id);
            if (student == null) return null;
            _studentRepository.Delete(student);
            return student;
        }




        public List<Student> GetAll()
        {
            return _studentRepository.GetAll();
        }

        

        public Student GetById(int id)
        {
            var student = _studentRepository.Get(m => m.Id == id);
            if (student == null) return null;
            return student;
        }

        public List<Student> Search(string name)
        {
            return _studentRepository.GetAll(m => m.Name.Trim().ToLower().StartsWith(name.ToLower().Trim()));
        }

        public Student Update(int id, Student student)
        {
            throw new NotImplementedException();
        }
    }
}
