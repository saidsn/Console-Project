using Domain.Models;
using Service.Helpers;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyApp.Controllers
{
    public class StudentController
    {
        StudentService studentService = new StudentService();
        GroupService groupService = new GroupService();


        public void Create()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add Group id :");
            GroupId: string groupId = Console.ReadLine();

            int selectedgroupId;

            bool isSelectedId = int.TryParse(groupId, out selectedgroupId);

            var data = groupService.GetById(selectedgroupId);

            if (data != null)
            {
                if (isSelectedId)
                {
                    Helper.WriteConsole(ConsoleColor.Blue, "Add student name :");
                    inputname: string studentName = Console.ReadLine();

                    foreach (var item in studentName)
                    {
                        for (int i = 0; i <= 9; i++)
                        {
                            if (item.ToString() == i.ToString())
                            {
                                Helper.WriteConsole(ConsoleColor.Red, "Please add correct studentName type:");
                                goto inputname;
                            }
                        }
                    }

                    Helper.WriteConsole(ConsoleColor.Blue, "Add student surname :");
                    inputname1: string studentSurName = Console.ReadLine();

                    foreach (var item in studentSurName)
                    {
                        for (int i = 0; i <= 9; i++)
                        {
                            if (item.ToString() == i.ToString())
                            {
                                Helper.WriteConsole(ConsoleColor.Red, "Please add correct studentSurName type:");
                                goto inputname1;
                            }
                        }
                    }

                    Helper.WriteConsole(ConsoleColor.Blue, "Add student Age :");
                    Age: string studentAge = Console.ReadLine();

                    int Age;

                    bool isAge = int.TryParse(studentAge, out Age);

                    if (isAge)
                    {
                        Student student = new Student
                        {
                            Name = studentName,
                            Surname = studentSurName,
                            Age = Age
                        };

                        var result = studentService.Create(selectedgroupId, student);
                        if (result != null)
                        {
                            Helper.WriteConsole(ConsoleColor.Green, $" Student id: {result.Id}, studentName: {result.Name}, studentSurName: {result.Surname}, studentAge: {result.Age}");
                        }
                        else
                        {
                            Helper.WriteConsole(ConsoleColor.Red, "Not found Group, Add correct group id :");
                            goto GroupId;
                        }
                    }
                    else
                    {
                        Helper.WriteConsole(ConsoleColor.Red, "Add correct Age Type :");
                        goto Age;
                    }
                   
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Add correct Group id type :");
                    goto GroupId;
                }

            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Add correct Group id type :");
                goto GroupId;
            }
        
        }

        public void Delete()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add Student id :");
            StudentId: string studentId = Console.ReadLine();
            int id;

            bool isStudenttId = int.TryParse(studentId, out id);

            if (isStudenttId)
            {
                var result = studentService.Delete(id);

                if (result == null)
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Student not found :");
                    goto StudentId;

                }
                else
                {
                    
                    Helper.WriteConsole(ConsoleColor.Green, "Student Deleted :");
                }
            }

            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Select correct id type :");
                goto StudentId;
            }
        }

        //public void GetAllStudentByGroupId()
        //{
        //    List<Student> students = studentService.GetAllById();

           

        //    foreach (var item in students)
        //    {
               
        //        Helper.WriteConsole(ConsoleColor.Green, $"Student id: {item.Id}, StudentName: {item.Name}, StudentSurName: {item.Surname}, StudentAge: {item.Age}");
        //    }
        //}
        public void GetStudentById()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add Student id :");
        studentId: string studentId = Console.ReadLine();
            int id;

            bool isstudentId = int.TryParse(studentId, out id);

            if (isstudentId)
            {
                Student student = studentService.GetById(id);
                if (student != null)
                {
                    Helper.WriteConsole(ConsoleColor.Green, $"Student id: {student.Id}, Student Name: {student.Name}, Student SurName: {student.Surname}, Student Age: {student.Age}");
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Student not Found :");
                    goto studentId;
                }
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Select correct id type :");
                goto studentId;
            }
        }
    }
}
