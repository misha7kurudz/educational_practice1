using System;
using System.IO;


namespace class_1
{
    internal class Program
    {
        static Cars cars = new Cars();

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the file name: ");

            var appRoot = Directory.GetCurrentDirectory();
            while (true)
            {
                cars.filename = Console.ReadLine();
                var fullPath = Path.Combine(appRoot, cars.filename);
                if (File.Exists(fullPath))
                {
                    ReadFromFile(fullPath);
                    break;
                }

                Console.WriteLine("Data is incorrect Please recheck the data...");
            }

            while (true)
            {
                int choose = 0;
                Console.WriteLine("___Menu___");
                Console.WriteLine("1. Sort by name");
                Console.WriteLine("2. Sort by age");
                Console.WriteLine("3. Sort by price");
                Console.WriteLine("4. Search by name");
                Console.WriteLine("5. Add element");
                Console.WriteLine("6. Remove element");
                Console.WriteLine("7. Edit element");
                Console.WriteLine("8. Show list");
                choose = Convert.ToInt32(Console.ReadLine());
                if (choose == 1)
                {
                    cars.Sort("Name");
                }
                else if (choose == 2)
                {
                    cars.Sort("Age");
                }
                else if (choose == 3)
                {
                    cars.Sort("Price");
                }
                else if (choose == 4)
                {
                    Console.WriteLine("Input word: ");
                    cars.SearchElement();
                }
                else if (choose == 5)
                {
                    cars.Add();
                }
                
                else if (choose == 6)
                {
                    cars.Remove();
                }
                else if (choose == 7)
                { 
                    cars.Edit();
                }
                else if (choose == 8)
                { 
                    cars.Print();
                }
                else
                {
                    Console.WriteLine("you input wrong number");
                }
            }
        }
        static void ReadFromFile(string fullPath)
        {
            using (StreamReader file = new StreamReader(fullPath))
            {
                string ln;
                while ((ln = file.ReadLine()) != null)
                {
                    if (Cars.ValidateElem(ln))
                    {
                        var car = new Car(ln);
                        cars.cars.Add(car);
                    }
                }

                file.Close();
            }
        }
    }
}