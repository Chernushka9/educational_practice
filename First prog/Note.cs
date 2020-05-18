using System;
using System.Collections.Generic;
using System.Text;

namespace Vika_lab_1
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
    }
}
