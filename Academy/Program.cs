using Service.Helpers;
using Service.Services;
using System;

namespace AcademyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            GroupService groupService = new GroupService();

            Helper.writeConsole(ConsoleColor.Blue, "Select one Option :");
            Helper.writeConsole(ConsoleColor.Yellow, "1 - Greate Group, 2 - Get Group by id, 3 - Update Group, 4 - Delete Group ");

            while (true)
            {
                SelectOption: string selectOption = Console.ReadLine();

                int selectTrueOption;

                bool isselectOption = int.TryParse(selectOption, out selectTrueOption);

                if (isselectOption)
                {
                    switch (selectTrueOption)
                    {
                        case 1:

                            Helper.writeConsole(ConsoleColor.Blue, "Add group name :");
                            string groupName = Console.ReadLine();
                            inputname:
                            Helper.writeConsole(ConsoleColor.Blue, "Add Teacher name :");
                            string groupTeacherName = Console.ReadLine();
                            foreach (var item in groupTeacherName)
                            {
                                for (int i = 0; i <= 9; i++)
                                {
                                    if (item.ToString() == i.ToString())
                                    {
                                        Helper.writeConsole(ConsoleColor.Red, "Please add correct name :");
                                        //Console.WriteLine("duzgun daxil edin!!");
                                        goto inputname;
                                    }
                                }
                            }










                            break;


                        case 2:
                            Console.WriteLine(selectTrueOption);
                            break;


                        case 3:
                            Console.WriteLine(selectTrueOption);
                            break;


                        case 4:
                            Console.WriteLine(selectTrueOption);
                            break;


                        default:
                            Helper.writeConsole(ConsoleColor.Red, "Select correct Option number :");
                            break;
                    }
                }
                else
                {
                    Helper.writeConsole(ConsoleColor.Red, "Select correct Option :");
                    goto SelectOption;
                }
            }
        }
    }
}
