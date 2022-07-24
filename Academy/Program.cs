using Service.Helpers;
using Service.Services;
using System;
using Domain.Models;
using System.Collections.Generic;
using AcademyApp.Controllers;

namespace AcademyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            

            GroupController groupController = new GroupController();

            StudentController studentController = new StudentController();

            Helper.WriteConsole(ConsoleColor.Blue, "Select one Option :");

            GetMenues();


            while (true)
            {
                SelectOption: string selectOption = Console.ReadLine();

                int selectTrueOption;

                bool isselectOption = int.TryParse(selectOption, out selectTrueOption);

                if (isselectOption)
                {
                    switch (selectTrueOption)
                    {




                        case (int)Menues.CreateGroup:
                            groupController.Create();
                            break;






                        case (int)Menues.GetGroupById:
                            groupController.GetById();
                            break;





                        case (int)Menues.UpdateGroup:
                            groupController.Update();
                            break;





                        case (int)Menues.DeleteGroup:
                            groupController.Delete();
                            break;





                        case (int)Menues.GetAllGroups:
                            groupController.GetAll();
                            break;





                        case (int)Menues.SearchGroupsByName:
                            groupController.Search();
                            break;





                        case (int)Menues.CreateStudent:
                            studentController.Create();
                            break;





                        case (int)Menues.GetAllStudentsByGroupId:
                            studentController.GetAllStudentByGroupId();
                            break;





                        case (int)Menues.DeleteStudent:
                            studentController.Delete();
                            break;





                        case (int)Menues.GetAllGroupsByTeacher:
                            groupController.GetByTeacher();
                            break;





                        case (int)Menues.GetAllGroupsByRoom:
                            groupController.GetByRoom();
                            break;





                        case (int)Menues.GetStudentById:
                            studentController.GetStudentById();
                            break;





                        case (int)Menues.SearchStudentsByNameOrSurname:
                            studentController.Search();
                            break;





                        case (int)Menues.UpdateStudent:
                            studentController.Update();
                            break;





                        case (int)Menues.GetStudentsByAge:
                            studentController.GetStudentByAge();
                            break;





                        default:
                            Helper.WriteConsole(ConsoleColor.Red, "Select correct option number :");
                            break;

                    }

                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Select correct option :");
                    goto SelectOption;
                }
            }
        }
        private static void GetMenues()
        {
            Helper.WriteConsole(ConsoleColor.Green, "1 - Greate Group\n2 - Get Group By Id\n3 - Update Group\n4 - Delete Group\n5" +
                " - Get All Groups\n6 - Search Group By Name\n7 - Create Student\n8 - GetAll Student By Group Id\n9" +
                " - Delete Student\n10 - Get All Groups by Teacher\n11 - Get All Groups by Room\n12 - Get Student By id\n13 " +
                " - Search Students By Name Or Surname\n14 - Update Student\n15 - GetStudentsByAge");
                
        }
    }
}
