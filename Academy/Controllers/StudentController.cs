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

            if (string.IsNullOrWhiteSpace(groupId))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Group id cant be empty :");
                goto GroupId;
            }

            int selectedgroupId;

            bool isSelectedId = int.TryParse(groupId, out selectedgroupId);

            var data = groupService.GetById(selectedgroupId);

            if (data != null)
            {
                if (isSelectedId)
                {
                    Helper.WriteConsole(ConsoleColor.Blue, "Add student name :");
                    inputname: string studentName = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(studentName))
                    {
                        Helper.WriteConsole(ConsoleColor.Red, "Student name cant be empty :");
                        goto inputname;
                    }

                    for (int i = 0; i <= 9; i++)
                    {
                        if (studentName.Contains(i.ToString()))
                        {
                            Helper.WriteConsole(ConsoleColor.Red, "Please add correct studentName type:");
                            goto inputname;
                        }
                        else if (string.IsNullOrWhiteSpace(studentName))
                        {
                            Helper.WriteConsole(ConsoleColor.Red, "Student name cant be empty :");
                            goto inputname;
                        }
                    }

                    Helper.WriteConsole(ConsoleColor.Blue, "Add student surname :");
                    inputname1: string studentSurName = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(studentSurName))
                    {
                        Helper.WriteConsole(ConsoleColor.Red, "Student surname cant be empty :");
                        goto inputname1;
                    }

                    for (int i = 0; i <= 9; i++)
                    {
                        if (studentSurName.Contains(i.ToString()))
                        {
                            Helper.WriteConsole(ConsoleColor.Red, "Please add correct student surname type:");
                            goto inputname1;
                        }
                        else if (string.IsNullOrWhiteSpace(studentSurName))
                        {
                            Helper.WriteConsole(ConsoleColor.Red, "Student surname cant be empty :");
                            goto inputname1;
                        }
                    }

                    Helper.WriteConsole(ConsoleColor.Blue, "Add student Age :");
                    Age: string studentAge = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(studentAge))
                    {
                        Helper.WriteConsole(ConsoleColor.Red, "Student age cant be empty :");
                        goto Age;
                    }

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

            if (string.IsNullOrWhiteSpace(studentId))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Student id cant be empty :");
                goto StudentId;
            }

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

        public void Search()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add Student search text :");
            SerchText: string search = Console.ReadLine();


            if (string.IsNullOrWhiteSpace(search))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Student search text cant be empty :");
                goto SerchText;
            }


            List<Student> resultStudents = studentService.Search(search);

            if (resultStudents.Count != 0)
            {
                foreach (var item in resultStudents)
                {
                    Helper.WriteConsole(ConsoleColor.Green, $" Student id: {item.Id}, Student Name: {item.Name}, Student SurName : {item.Surname}, Student Age: {item.Age}");
                   
                }

            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Student name not Found :");
                goto SerchText;
            }

           


        }

        public void GetAllStudentByGroupId()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add Group id :");
            SerchText: string groupId = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(groupId))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Group id cant be empty :");
                goto SerchText;
            }

            int id;
            bool isGroupId = int.TryParse(groupId, out id);

            if (isGroupId)
            {
                List<Student> students = studentService.GetStudentsByGroupId(id);

                foreach (var item in students)
                {

                    Helper.WriteConsole(ConsoleColor.Green, $"Student id: {item.Id}, Student Name: {item.Name}, Student SurName: {item.Surname}, Student Age: {item.Age}");
                }
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, " Add correct group id :");
            }
            
        }

        public void GetStudentById()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add Student id :");
        studentId: string studentId = Console.ReadLine();


            if (string.IsNullOrWhiteSpace(studentId))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Student id cant be empty :");
                goto studentId;
            }

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

        public void GetStudentByAge()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add Students :");
            studentId: string studentAge = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(studentAge))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Students age cant be empty :");
                goto studentId;
            }

            int age;
            bool isAge = int.TryParse(studentAge, out age);

            List<Student> resultStudents = studentService.GetStudentByAge(age);
            if (resultStudents.Count != 0)
            {
                foreach (var item in resultStudents)
                {
                    Helper.WriteConsole(ConsoleColor.Green, $"Students id: {item.Id}, Students Name: {item.Name}, Students SurName: {item.Surname}, Students Age: {item.Age}");
                }
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Students not found :");
            }

        }

        public void Update()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add Student id :");
            StudentId: string updateStudentId = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(updateStudentId))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Student id cant be empty :");
                goto StudentId;
            }

            int studentId;
            bool isStudentId = int.TryParse(updateStudentId, out studentId);

            var data = studentService.GetById(studentId);

            if (data != null)
            {
                if (isStudentId)
                {
                    Helper.WriteConsole(ConsoleColor.Blue, "Add student new name :");
                NewStudentName: string studentNewName = Console.ReadLine();

                    for (int i = 0; i <= 9; i++)
                    {
                        if (studentNewName.Contains(i.ToString()))
                        {
                            Helper.WriteConsole(ConsoleColor.Red, "Please add correct studentname type:");
                            goto NewStudentName;
                        }
                        else if (string.IsNullOrWhiteSpace(studentNewName))
                        {
                            Helper.WriteConsole(ConsoleColor.Red, "Student new name cant be empty :");
                            goto NewStudentName;
                        }
                    }


                    Helper.WriteConsole(ConsoleColor.Blue, "Add student new surname :");
                NewStudentSurname: string studentNewSurname = Console.ReadLine();

                    for (int i = 0; i <= 9; i++)
                    {
                        if (studentNewSurname.Contains(i.ToString()))
                        {
                            Helper.WriteConsole(ConsoleColor.Red, "Please add correct studentname type:");
                            goto NewStudentSurname;
                        }
                        else if (string.IsNullOrWhiteSpace(studentNewSurname))
                        {
                            Helper.WriteConsole(ConsoleColor.Red, "Student new surname cant be empty :");
                            goto NewStudentSurname;
                        }
                    }


                    Helper.WriteConsole(ConsoleColor.Blue, "Add student new age :");
                NewStudentAge: string studentNewAge = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(studentNewAge))
                    {
                        Helper.WriteConsole(ConsoleColor.Red, " Student new age cant be empty :");
                        goto NewStudentAge;
                    }

                    int newAge;
                    bool isNewAge = int.TryParse(studentNewAge, out newAge);
                    

                    if (isNewAge || studentNewAge == "")
                    {
                        bool isNewAgeEmpty = string.IsNullOrEmpty(studentNewAge);
                        int? age = null;

                        if (isNewAge)
                        {
                            age = null;
                        }
                        else
                        {
                            age = newAge;
                        }

                        Student student = new Student()
                        {
                            Name = studentNewName,
                            Surname = studentNewSurname,
                            Age = newAge
                        };

                        var resultStudent = studentService.Update(studentId, student);

                        if (resultStudent != null)   
                        {
                            Helper.WriteConsole(ConsoleColor.Green, $"Student id: {resultStudent.Id}, Student Name: {resultStudent.Name}, Student SurName: {resultStudent.Surname}, Student Age: {resultStudent.Age}");
                        }
                        else
                        {
                            Helper.WriteConsole(ConsoleColor.Red, "Student not fount,try again :");
                            goto StudentId;
                        }
                    }
                    else
                    {
                        Helper.WriteConsole(ConsoleColor.Red, "Add correct age type :");
                        goto NewStudentAge;
                    }
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Add correct student id type :");
                    goto StudentId;
                }
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Add correct student id :");
                goto StudentId;
            }


        }
    }
}
