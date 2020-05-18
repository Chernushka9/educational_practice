using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Vika_lab_2
{
    class Note
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string phone { get; set; }
        public double age { get; set; }
        public double weight { get; set; }

        public Note(string name, string surname, string phone, double age, double weight)
        {
            this.name = name;
            this.surname = surname;
            this.phone = phone;
            this.age = age;
            this.weight = weight;
        }

        public Note(string ln)
        {
            var line1 = ln.Split();
            this.name = line1[0].ToString();
            this.surname = line1[1].ToString();
            this.phone = line1[2].ToString();
            this.age = Convert.ToDouble(Convert.ToString(line1[3]));
            this.weight = Convert.ToDouble(Convert.ToString(line1[4]));
        }

        public void PrintNote()
        {
            Console.WriteLine($"Name: {name}, Surname: {surname}, Phone: {phone}, Age: {age}, Weight: {weight}");
        }

        public override string ToString() => $"{name} {surname} {phone} {age} {weight}";

        public static Note ReadNote()
        {
            Console.WriteLine("Enter name: ");
            string s1 = Console.ReadLine();
            Console.WriteLine("Enter surname: ");
            string s2 = Console.ReadLine();
            Console.WriteLine("Enter phone: ");
            string s3 = Console.ReadLine();
            Console.WriteLine("Enter age: ");
            string s4 = Console.ReadLine();
            Console.WriteLine("Enter weight: ");
            string s5 = Console.ReadLine();
            string full_line = s1 + " " + s2 + " " + s3 + " " + s4 + " " + s5;
            Note note = null;

            if (ValidateData(full_line))
            {
                note = new Note(full_line);
            }

            return note;
        }

        public static Note EditElement()
        {
            Console.WriteLine("Enter new string text: ");
            string newText = Console.ReadLine();
            Note note = null;

            if (ValidateData(newText))
                note = new Note(newText);

            return note;
        }

        public static bool ValidateData(string line)
        {
            string[] line1 = line.Split();

            if (!CheckLetters(line1[0]))
            {
                return false;
            }
            if (!CheckLetters(line1[1]))
            {
                return false;
            }
            if (!CheckPhone(line1[2]))
            {
                return false;
            }
            if (!CheckNumbers(line1[3]))
            {
                return false;
            }
            if (!CheckNumbers(line1[4]))
            {
                return false;
            }
            else
                return true;
        }

        public static bool CheckLetters(string letters)
        {
            if (Regex.IsMatch(letters, @"^[a-zA-Z]+$"))
            {
                return true;
            }
            else
                return false;
        }

        public static bool CheckPhone(string phones)
        {
            if (Regex.IsMatch(phones, @"^[0-9]*$"))
            {
                return true;
            }
            else
                return false;
        }

        public static bool CheckNumbers(string numbers)
        {
            if (Regex.IsMatch(numbers, @"^\d+(?:[\.\,]\d+)?$"))
            {
                return true;
            }
            else
                return false;
        }
    }
}
