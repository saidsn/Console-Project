using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Helpers
{
    public static class Helper
    {
        public static void WriteConsole(ConsoleColor color,string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }

    public enum Menues
    {
        CreateGroup = 1,
        GetGroupById = 2,
        UpdateGroup = 3,
        DeleteGroup = 4,
        GetAllGroups = 5,
        SearchGroupsByName = 6,
        CreateStudent = 7,
        GetAllStudentsByGroupId = 8,
        DeleteStudent = 9,
        GetAllGroupsByTeacher = 10,
        GetAllGroupsByRoom = 11,
        GetStudentById = 12,
        SearchStudentsByNameOrSurname = 13,
        UpdateStudent = 14,
        GetStudentsByAge = 15

    }
}
