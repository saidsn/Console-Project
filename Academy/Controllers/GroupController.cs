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
        inputname: string groupName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(groupName))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Group name cant be empty :");
                goto inputname;
            }
           

            Helper.WriteConsole(ConsoleColor.Blue, "Add Group Teacher Name :");
            inputname1: string groupTeacherName = Console.ReadLine();

            for (int i = 0; i <= 9; i++)
            {
                if (groupTeacherName.Contains(i.ToString()))
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Please add correct Group TeacherName :");
                    goto inputname1;
                }
                else if (string.IsNullOrWhiteSpace(groupTeacherName))
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Group teacher name cant be empty :");
                    goto inputname1;
                }
            }

            Helper.WriteConsole(ConsoleColor.Blue, "Add Room Name :");
            RoomName: string groupRoomName = Console.ReadLine();


            if (string.IsNullOrWhiteSpace(groupRoomName))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Group room name cant be empty :");
                goto RoomName;
            }

            if (string.IsNullOrWhiteSpace(groupRoomName))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Group room name cant be empty :");
                goto RoomName;
            }

            Group group = new Group
            {
                Name = groupName,
                Teacher = groupTeacherName,
                Room = groupRoomName
            };
            var result = groupService.Create(group);
            Helper.WriteConsole(ConsoleColor.Green, $"Group id: {result.Id}, GroupName: {result.Name}, Group TeacherName: {result.Teacher}, Group RoomName: {result.Room}");
        }

        public void GetById()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add Group id :");
        groupId: string groupId = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(groupId))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Group id cant be empty :");
                goto groupId;
            }
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

            if (string.IsNullOrWhiteSpace(search))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Group search text cant be empty :");
                goto SerchText;
            }

            List<Group> resultGroups = groupService.Search(search);

            if (resultGroups.Count != 0)
            {
                foreach (var item in resultGroups)
                {
                    Helper.WriteConsole(ConsoleColor.Green, $" Group id: {item.Id}, GroupName: {item.Name}, GroupTeacherName: {item.Teacher}, GroupRoomName: {item.Room}");
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

            if (string.IsNullOrWhiteSpace(groupId))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Group id cant be empty :");
                goto GroupId;
            }

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

            if (string.IsNullOrWhiteSpace(teacherName))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Teacher name cant be empty :");
                goto TeacherName;
            }


            for (int i = 0; i <= 9; i++)
            {
                if (teacherName.Contains(i.ToString()))
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Please add correct GroupTeacherName :");
                    goto TeacherName;
                }
                else if (string.IsNullOrWhiteSpace(teacherName))
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Teacher name cant be empty :");
                    goto TeacherName;
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

            if (string.IsNullOrWhiteSpace(roomName))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Room name cant be empty :");
                goto RoomName;
            }


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

        public void Update()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add Group id :");
            string updateGroupId = Console.ReadLine();
            
            int groupId;
            bool isGroupId = int.TryParse(updateGroupId, out groupId);

            if (isGroupId)
            {
                Helper.WriteConsole(ConsoleColor.Blue, "Add Group new name :");
                GroupNewName: string groupNewName = Console.ReadLine();


                if (string.IsNullOrWhiteSpace(groupNewName))
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Group new name cant be empty :");
                    goto GroupNewName;
                }

                Helper.WriteConsole(ConsoleColor.Blue, "Add Group new teacher name :");
                NewTeachername: string groupNewTeacherName = Console.ReadLine();

                for (int i = 0; i <= 9; i++)
                {
                    if (groupNewTeacherName.Contains(i.ToString()))
                    {
                        Helper.WriteConsole(ConsoleColor.Red, "Group new teacher name is not correct :");
                        goto NewTeachername;
                    }
                    else if (string.IsNullOrWhiteSpace(groupNewTeacherName))
                    {
                        Helper.WriteConsole(ConsoleColor.Red, "Teacher new name cant be empty :");
                        goto NewTeachername;
                    }
                }

                Helper.WriteConsole(ConsoleColor.Blue, "Add Group new room name :");
                GroupId: string groupNewRoomName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(groupNewRoomName))
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Group new room name cant be empty :");
                    goto GroupId;
                }

                Group group = new Group()
                {
                    Name = groupNewName,
                    Teacher = groupNewTeacherName,
                    Room = groupNewRoomName
                };

                var resultGroup = groupService.Update(groupId, group);

                if (resultGroup == null)
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Group can not be found, try again :");
                    goto GroupId;
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Green, $"Group id: {resultGroup.Id}, Group Name: {resultGroup.Name}, Group Teacher Name: {resultGroup.Teacher}, Group Room Name: {resultGroup.Room}");
                }
            }


        }


    }
}
