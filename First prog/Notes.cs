using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Vika_lab_1
{
    class Notes
    {
        public List<Note> notes = new List<Note>();
        public string filename { get; set; }
        public void PrintNotes()
        {
            foreach (var note in notes)
            {
                note.PrintNote();
            }
        }

        public bool CheckLetters(string letters)
        {
            if (Regex.IsMatch(letters, @"^[a-zA-Z]+$"))
            {
                return true;
            }
            else
                return false;
        }

        public bool CheckPhone(string phones)
        {
            if (Regex.IsMatch(phones, @"^[0-9]*$"))
            {
                return true;
            }
            else
                return false;
        }

        public bool CheckNumbers(string numbers)
        {
            if (Regex.IsMatch(numbers, @"^\d+(?:[\.\,]\d+)?$"))
            {
                return true;
            }
            else
                return false;
        }

        public bool ValidateData(string line)
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

        public void SortElements()
        {
            try
            {
                string sortBy = Console.ReadLine();
                notes = notes.OrderBy(r => r.GetType().GetProperty(sortBy).GetValue(r, null)).ToList();
                PrintNotes();
            }
            catch (Exception e)
            {
                Console.WriteLine("Enter existing field!");
            }
        }

        public void AddElement()
        {
            List<string> strings = new List<string>();
            var appRoot = Directory.GetCurrentDirectory();
            var fullPath = Path.Combine(appRoot, filename);
            strings.AddRange(File.ReadAllLines(fullPath));
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
            strings.Add(full_line);
            string[] stringsArray = strings.ToArray();

            if (ValidateData(full_line))
            {
                File.WriteAllLines(fullPath, stringsArray);
                var note = new Note(full_line);
                notes.Add(note);
            }
        }

        public void EditElement()
        {
            Console.WriteLine("Enter new string text: ");
            string newText = Console.ReadLine();
            if (ValidateData(newText))
            {
                Console.WriteLine("Enter an index of line to edit: ");
                int indexLine = Convert.ToInt32(Console.ReadLine());
                var appRoot = Directory.GetCurrentDirectory();
                var fullPath = Path.Combine(appRoot, filename);
                string[] arrLine = File.ReadAllLines(fullPath);
                arrLine[indexLine - 1] = newText;
                File.WriteAllLines(fullPath, arrLine);
                var note = new Note(newText);
                notes[indexLine - 1] = note;
                Console.WriteLine("Edit completed.");
            }
            else { Console.WriteLine("Data is incorrect."); }
        }

        public void DeleteElement()
        {
            Console.WriteLine("Enter an index of line to delete: ");
            int index = int.Parse(Console.ReadLine());
            var temp = notes[index];
            notes.Remove(temp);
            var appRoot = Directory.GetCurrentDirectory();
            var fullPath = Path.Combine(appRoot, filename);
            string[] temp_array = new string[notes.Count];
            for (var i = 0; i < notes.Count; i++)
                temp_array[i] = notes[i].ToString();
            File.WriteAllLines(fullPath, temp_array);
            Console.WriteLine("Line successfully deleted!");
        }

        public void SearchElement()
        {
            string key = Console.ReadLine();
            foreach (var note in notes)
            {
                if (note.ToString().ToLower().Contains(key.ToLower()))
                {
                    Console.WriteLine(note);
                }
            }
        }
    }
}
