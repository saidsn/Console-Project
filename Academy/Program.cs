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
            GroupService groupService = new GroupService();

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




                            
                        //case (int)Menues.UpdateGroup:
                        //    groupController.Update();
                        //    break;







                        case (int)Menues.DeleteGroup:
                            groupController.Delete();
                            break;






                        case (int)Menues.GetAllGroups:
                            groupController.GetAll();
                            break;







                        case (int)Menues.SearchGroupByName:
                            groupController.Search();
                            break;





                        case (int)Menues.CreateStudent:
                            studentController.Create();
                            break;





                        case (int)Menues.GetAllStudentByGroupId:
                            studentController.GetAllStudentByGroupId();
                            break;




                        case (int)Menues.DeleteStudent:
                            studentController.Delete();
                            break;




                        case (int)Menues.GetAllGroupsbyTeacher:
                            groupController.GetByTeacher();
                            break;



                        case (int)Menues.GetAllGroupsbyRoom:
                            groupController.GetByRoom();
                            break;





                        case (int)Menues.GetStudentById:
                            studentController.GetStudentById();
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
            Helper.WriteConsole(ConsoleColor.Green, "1 - Greate Group\n2 - Get Group By Id\n3 - Update Group\n4 - Delete Group\n5 - GetAll Groups\n6 - Search Group By Name\n7 - Create Student\n8 - GetAll Student By Id\n9 - DeleteStudent\n10 - GetAllGroupsbyTeacher\n11 - GetAllGroupsbyRoom\n12 - GetStudentByid");
                
        }
    }
}
