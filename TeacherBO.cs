using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DoverConsoleApp
{
    class TeacherBO
    {
        public List<TeacherModel> Teachers { get; set; }
        static string filepath = @"C:\teacherdetails.txt";
        public void CreateFile()
        {
            File.Create(filepath);
        }
        public void AddTeacher(int Id, string Name, string Class, string Section)
        {
            Teachers = new List<TeacherModel>()
            {
                new TeacherModel { TeacherId = Id, TeacherName = Name , Class = Class, Section = Section}
            };
            List<string> output = File.ReadAllLines(filepath).ToList();
            foreach (var teacher in Teachers)
            {
                output.Add($"{teacher.TeacherId},{teacher.TeacherName},{teacher.Class},{teacher.Section}");
                output.Sort();
            }
            File.WriteAllLines(filepath, output);
        }
        public void GetAllTeachers()
        {
            List<string> lines = File.ReadAllLines(filepath).ToList();
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
        }
        public TeacherModel GetTeacherByid(int id)
        {
            List<string> lines = File.ReadAllLines(filepath).ToList();
            List<TeacherModel> teachers = new List<TeacherModel>();
            foreach (var line in lines)
            {
                string[] entries = line.Split(',');
                TeacherModel teacher = new TeacherModel();
                teacher.TeacherId = Convert.ToInt32(entries[0]);
                teacher.TeacherName = entries[1];
                teacher.Class = entries[2];
                teacher.Section = entries[3];
                teachers.Add(teacher);
            }
            return teachers.Single(x => x.TeacherId == id);
        }
        public TeacherModel UpdateTeacher(int id)
        {
            List<string> lines = File.ReadAllLines(filepath).ToList();
            List<TeacherModel> teachers = new List<TeacherModel>();
            foreach (var line in lines)
            {
                string[] entries = line.Split(',');
                TeacherModel teacher = new TeacherModel();
                teacher.TeacherId = Convert.ToInt32(entries[0]);
                teacher.TeacherName = entries[1];
                teacher.Class = entries[2];
                teacher.Section = entries[3];
                teachers.Add(teacher);
            }
            int index = teachers.FindIndex(x => x.TeacherId == id);
            if (index > -1)
            {
                Console.WriteLine("Enter choice of what you want to update");
                Console.WriteLine("1. Teacher Name 2. Allocation of class 3. Allocation of section 4. Allocation of both class and section");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter new name");
                        string name = Console.ReadLine();
                        teachers[index].TeacherName = name;
                        break;
                    case 2:
                        Console.WriteLine("Enter new class");
                        string Class = Console.ReadLine();
                        teachers[index].Class = Class;
                        break;
                    case 3:
                        Console.WriteLine("Enter new Section");
                        string Section = Console.ReadLine();
                        teachers[index].Section = Section;
                        break;
                    case 4:
                        Console.WriteLine("Enter new Class and Section");
                        string Class1 = Console.ReadLine();
                        string Section1 = Console.ReadLine();
                        teachers[index].Class = Class1;
                        teachers[index].Section = Section1;
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
            List<string> output = File.ReadAllLines(filepath).ToList();
            output.RemoveAt(index);
            output.Add($"{teachers[index].TeacherId},{teachers[index].TeacherName},{teachers[index].Class},{teachers[index].Section}");
            output.Sort();
            File.WriteAllLines(filepath, output);
            return teachers.Single(x => x.TeacherId == id);
        }
        public void DeleteTeacher(int id)
        {
            List<string> lines = File.ReadAllLines(filepath).ToList();
            List<TeacherModel> teachers = new List<TeacherModel>();
            foreach (var line in lines)
            {
                string[] entries = line.Split(',');
                TeacherModel teacher = new TeacherModel();
                teacher.TeacherId = Convert.ToInt32(entries[0]);
                teacher.TeacherName = entries[1];
                teacher.Class = entries[2];
                teacher.Section = entries[3];
                teachers.Add(teacher);
            }
            int index = teachers.FindIndex(x => x.TeacherId == id);
            teachers.RemoveAt(index);
            List<string> output = new List<string>();
            if (teachers.Count != 0)
                output.Add($"{teachers[index].TeacherId},{teachers[index].TeacherName},{teachers[index].Class},{teachers[index].Section}");
            else
                File.WriteAllLines(filepath, new string[0]);
            output.Sort();
            File.WriteAllLines(filepath, output);
        }
    }
}
