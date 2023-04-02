﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

namespace FinalTask
{
    [Serializable]
    public class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    static class BinaryFileIO
    {
        private static List<Student> studentsList = new List<Student>();
        private static List<String> groupsList = new List<String>();
        public static void ReadStudentsDataFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                List<String> groups = new List<String>();
                Console.WriteLine("Чтение данных из файла:");
                var formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    Student[] students = (Student[])formatter.Deserialize(fs);
                    int i = 0;
                    foreach (Student student in students)
                    {
                        i++;
                        Console.WriteLine($"{i} Имя: {student.Name} Группа: {student.Group} Дата рождения: {student.DateOfBirth}");
                        groups.Add(student.Group);
                        studentsList.Add(student);
                    }
                }
                //Определяем список групп
                groupsList = groups.Distinct().ToList();
            }
            else
            {
                Console.WriteLine("Ошибка. По заданному пути файла не существует.");
            }
        }
        public static void WriteStudentsData(string directoryPath)
        {
            Console.WriteLine("\nЗапись данных студентов с сортировкой по группам:");
            try
            {
                foreach (String group in groupsList)
                {
                    String fileName = group + ".txt";
                    String filePath = Path.Combine(directoryPath, fileName);
                    Console.WriteLine($"Группа: {group} Файл: {fileName}");
                    FileInfo fileInfo = new FileInfo(filePath);
                    using (StreamWriter sw = fileInfo.CreateText())
                    {
                        foreach (Student student in studentsList)
                        {
                            if (student.Group == group)
                            {
                                sw.WriteLine($"{student.Name}, {student.DateOfBirth}");
                            }
                        }
                    }
                }
                Console.WriteLine($"\nДанные студентов записаны в директорию: {directoryPath}");
                Console.WriteLine("\nОперация завершена.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex}");
            }
        }
    }
}
