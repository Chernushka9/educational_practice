using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Vika_lab_2
{
    class Notes<T> where T : Note   
    {
        public List<T> notes = new List<T>();
        public string filename { get; set; }
        public void PrintNotes()
        {
            foreach (var note in notes)
            {
                note.PrintNote();
            }
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

        public string ReadElement()
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

            return full_line;
        }

        public void AddElement(T note)
        {
            List<string> strings = new List<string>();
            var appRoot = Directory.GetCurrentDirectory();
            var fullPath = Path.Combine(appRoot, filename);
            strings.AddRange(File.ReadAllLines(fullPath));

            if (note == null)
            {
                Console.WriteLine("Data is incorrect.");
                return;
            }

            string full_line = note.name + " " + note.surname + " " + note.phone + " " + note.age + " " + note.weight;
            strings.Add(full_line);
            string[] stringsArray = strings.ToArray();
            File.WriteAllLines(fullPath, stringsArray);
            notes.Add(note);
        }

        public void SaveEditedElement(T note)
        {
            if (note == null)
            {
                Console.WriteLine("Data is incorrect.");
                return;
            }

            string newText = note.name + " " + note.surname + " " + note.phone + " " + note.age + " " + note.weight;

             Console.WriteLine("Enter an index of line to edit: ");
             int indexLine = Convert.ToInt32(Console.ReadLine());
             var appRoot = Directory.GetCurrentDirectory();
             var fullPath = Path.Combine(appRoot, filename);
             string[] arrLine = File.ReadAllLines(fullPath);
             arrLine[indexLine - 1] = newText;
             File.WriteAllLines(fullPath, arrLine);
             notes[indexLine - 1] = note;
             Console.WriteLine("Edit completed.");
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
