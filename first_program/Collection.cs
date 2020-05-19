using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;


namespace class_1
{

    class Cars
    {
        public List<Car> cars = new List<Car>();
        public string filename { get; set; }
        public static bool validString(string word)
        {
            foreach (char c in word)
                if (Char.IsNumber(c) || Char.IsSymbol(c))
                {
                    return false;
                }
            return true;
        }
        public static bool validDigit(string number)
        {
            foreach (char c in number)
                if (Char.IsLetter(c) || Char.IsSymbol(c))
                {
                    return false;
                }
            if (Convert.ToInt32(number) < 0)
            { 
                return false;
            }
            return true;
        }
        public static bool validAge(string number)
        {
            foreach (char c in number)
                if (Convert.ToInt32(number) > 2020 || Convert.ToInt32(number) < 1970)
                {
                    return false;
                }
            return true;
        }
        public static bool ValidateElem(string line)
        {
            string[] line1 = line.Split();
            
            if (!validString(line1[0]) || !validDigit(line1[1]) || !validAge(line1[1]) ||!validDigit(line1[2])||!validString(line1[3])||!validDigit(line1[4]))
            {
                return false;
            }
            else
                return true;
            
        }
        public void Sort(string item)
        {
            try
            {
                cars = cars.OrderBy(r => r.GetType().GetProperty(item).GetValue(r, null)).ToList();
                Print();
            }
            catch (Exception e)
            {
                Console.WriteLine("Enter existing field!");
            }
        }
        public void SearchElement()
        {
            string key = Console.ReadLine();
            foreach (var car in cars)
            {
                if (car.ToString().ToLower().Contains(key.ToLower()))
                {
                    Console.WriteLine(car);
                }
            }
        }
        public void Add()
        {
            List<string> strings = new List<string>();
            var appRoot = Directory.GetCurrentDirectory();
            var fullPath = Path.Combine(appRoot, filename);
            strings.AddRange(File.ReadAllLines(fullPath));
            Console.WriteLine("Input name: "); 
            string name1 = Console.ReadLine();
            Console.WriteLine("input age: ");
            string age1 = Console.ReadLine();
            Console.WriteLine("input price: ");
            string price1 = Console.ReadLine();
            Console.WriteLine("input color: ");
            string color1 = Console.ReadLine();
            Console.WriteLine("input horse power: ");
            string horsePower1 = Console.ReadLine();
            string fullLine  = name1 + " " + age1 + " " + price1 + " " + color1 + " " + horsePower1;
            strings.Add(fullLine);
            string[] stringsArray = strings.ToArray();
            if (ValidateElem(fullLine))
            {
                File.WriteAllLines(fullPath, stringsArray);
                var car = new Car(fullLine);
                cars.Add(car);
            }
            else
            {
                Console.WriteLine("Something wrong");
            }
        }
        public void Remove()
        {
            Console.WriteLine("Enter an index of line to delete: ");
            int index = int.Parse(Console.ReadLine());
            var temp = cars[index];
            cars.Remove(temp);
            var appRoot = Directory.GetCurrentDirectory();
            var fullPath = Path.Combine(appRoot, filename);
            string[] temp_array = new string[cars.Count];
            for (var i = 0; i < cars.Count; i++)
                temp_array[i] = cars[i].ToString();
            File.WriteAllLines(fullPath, temp_array);
            Console.WriteLine("Line successfully deleted!");
        }
        public void Edit()
        {
            Console.WriteLine("Enter new string text: ");
            string newText = Console.ReadLine();
            if (ValidateElem(newText))
            {
                Console.WriteLine("Enter an index of line to edit: ");
                int indexLine = Convert.ToInt32(Console.ReadLine());
                var appRoot = Directory.GetCurrentDirectory();
                var fullPath = Path.Combine(appRoot, filename);
                string[] arrLine = File.ReadAllLines(fullPath);
                arrLine[indexLine - 1] = newText;
                File.WriteAllLines(fullPath, arrLine);
                var note = new Car(newText);
                cars[indexLine - 1] = note;
                Console.WriteLine("Edit completed.");
            }
            else { Console.WriteLine("Data is incorrect."); }
        }
        
        public void Print()
        {
            foreach (var car in cars)
            {
                car.Print();
            }
        }
    }
}