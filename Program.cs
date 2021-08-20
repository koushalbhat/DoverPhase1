using System;
using System.Collections.Generic;
using System.Linq;

namespace DoverConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int Id; string Name, Class, Section;
            List<TeacherModel> teachers = new List<TeacherModel>();
            TeacherBO context = new TeacherBO();
            Console.WriteLine("Welcome to Teacher Records!");
            Console.WriteLine("============================================================================================");
            Console.WriteLine("Please Select 0 option for the first time to create empty file. Then select other options.");
            Console.WriteLine("============================================================================================");
            Console.WriteLine("1. Add Teacher Details 2. Retrieve all Teacher Details 3. Retrieve Teacher by ID 4. Update Teacher 5. Delete Teacher");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 0:
                    context.CreateFile();
                    break;
                case 1:
                    Console.WriteLine("Enter number of records to enter");
                    int number = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < number; i++)
                    {
                        Console.WriteLine("Enter Teacher Details");
                        Console.WriteLine("Teacher Id");
                        Id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Teacher Name");
                        Name = Console.ReadLine();
                        Console.WriteLine("Teacher Class");
                        Class = Console.ReadLine();
                        Console.WriteLine("Teacher Section");
                        Section = Console.ReadLine();
                        context.AddTeacher(Id, Name, Class, Section);
                    }
                    break;

                case 2:
                    Console.WriteLine("Displaying Teacher Records");
                    context.GetAllTeachers();
                    break;

                case 3:
                    Console.WriteLine("Enter Id of teacher to display");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Displaying Teacher Record");
                    TeacherModel teacher = context.GetTeacherByid(id);
                    Console.WriteLine($"{teacher.TeacherId},{teacher.TeacherName},{teacher.Class},{teacher.Section}");
                    break;
                case 4:
                    Console.WriteLine("Enter Id of teacher you want to update");
                    int Idnum = Convert.ToInt32(Console.ReadLine());
                    teacher = context.UpdateTeacher(Idnum);
                    Console.WriteLine("Teacher records updated as follows");
                    Console.WriteLine($"{teacher.TeacherId},{teacher.TeacherName},{teacher.Class},{teacher.Section}");
                    break;
                case 5:
                    Console.WriteLine("Enter Id of teacher you want to delete");
                    int Idnumber = Convert.ToInt32(Console.ReadLine());
                    context.DeleteTeacher(Idnumber);
                    Console.WriteLine("Deleted record");
                    break;
                case 6:
                    Console.WriteLine("Exit");
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }
}
