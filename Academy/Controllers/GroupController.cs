using Service.Helpers;
using Service.Services;
using System;
using Domain.Models;
using System.Collections.Generic;

namespace AcademyApp.Controllers
{
    public class GroupController
    {
        GroupService groupService = new GroupService();
        
        public void Create()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add Group Name :");
            string groupName = Console.ReadLine();
            inputname:

            Helper.WriteConsole(ConsoleColor.Blue, "Add GroupTeacher Name :");
            string groupTeacherName = Console.ReadLine();

            foreach (var item in groupTeacherName)
            {
                for (int i = 0; i <= 9; i++)
                {
                    if (item.ToString() == i.ToString())
                    {
                        Helper.WriteConsole(ConsoleColor.Red, "Please add correct GroupTeacherName :");
                        goto inputname;
                    }
                }
            }

            Helper.WriteConsole(ConsoleColor.Blue, "Add Room Name :");
            string groupRoomName = Console.ReadLine();

            Group group = new Group
            {
                Name = groupName,
                Teacher = groupTeacherName,
                Room = groupRoomName
            };
            var result = groupService.Create(group);
            Helper.WriteConsole(ConsoleColor.Green, $"Group id: {result.Id}, GroupName: {result.Name}, GroupTeacherName: {result.Teacher}, GroupRoomName: {result.Room}");
        }
        public void GetById()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add Group id :");
        groupId: string groupId = Console.ReadLine();
            int id;

            bool isgroupId = int.TryParse(groupId, out id);

            if (isgroupId)
            {
                Group group1 = groupService.GetById(id);
                if (group1 != null)
                {
                    Helper.WriteConsole(ConsoleColor.Green, $"Group id: {group1.Id}, GroupName: {group1.Name}, GroupTeacherName: {group1.Teacher}, GroupRoomName: {group1.Room}");
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Group not Found :");
                    goto groupId;
                }
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Select correct id type :");
                goto groupId;
            }
        }
        public void GetAll()
        {
            List<Group> groups = groupService.GetAll();

            foreach (var item in groups)
            {
                Helper.WriteConsole(ConsoleColor.Green, $"Group id: {item.Id}, GroupName: {item.Name}, GroupTeacherName: {item.Teacher}, GroupRoomName: {item.Room}");
            }
        }
        public void Search()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add Group search text :");
        SerchText: string search = Console.ReadLine();

            List<Group> resultGroups = groupService.Search(search);

            if (resultGroups.Count != 0)
            {
                foreach (var item in resultGroups)
                {
                    Helper.WriteConsole(ConsoleColor.Green, $"Group id: {item.Id}, GroupName: {item.Name}, GroupTeacherName: {item.Teacher}, GroupRoomName: {item.Room}");
                }
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Group not Found :");
                goto SerchText;
            }
        }
        public void Delete()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add Group id :");
        GroupId: string groupId = Console.ReadLine();
            int id;

            bool isGrouptId = int.TryParse(groupId, out id);

            if (isGrouptId)
            {
                var result = groupService.Delete(id);

                if (result == null)
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Group not found :");
                }
                else
                {
                    groupService.Delete(id);
                    Helper.WriteConsole(ConsoleColor.Green, "Group Deleted :");
                }
            }
            
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Select correct id type :");
                goto GroupId;
            }
        }
        public void GetByTeacher()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add Teacher Name :");
        TeacherName: string teacherName = Console.ReadLine();

            foreach (var item in teacherName)
            {
                for (int i = 0; i <= 9; i++)
                {
                    if (item.ToString() == i.ToString())
                    {
                        Helper.WriteConsole(ConsoleColor.Red, "Please add correct GroupTeacherName :");
                        goto TeacherName;
                    }
                }
                
            }
            List<Group> teachers = groupService.GetByTeacher(teacherName);
            if(teachers.Count != 0)
            {
                foreach (var item in teachers)
                {
                    Helper.WriteConsole(ConsoleColor.Green, $"Group id: {item.Id}, GroupName: {item.Name}, GroupTeacherName: {item.Teacher}, GroupRoomName: {item.Room}");
                }
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Teacher not Found :");
                goto TeacherName;
            }


        }
        public void GetByRoom()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add Room Name :");
        RoomName: string roomName = Console.ReadLine();


            List<Group> rooms = groupService.GetByRoom(roomName);
            if (rooms.Count != 0)
            {
                foreach (var item in rooms)
                {
                    Helper.WriteConsole(ConsoleColor.Green, $"Group id: {item.Id}, GroupName: {item.Name}, GroupTeacherName: {item.Teacher}, GroupRoomName: {item.Room}");
                }
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Room not Found :");
                goto RoomName;
            }


        }



    }
}
