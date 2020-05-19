using System;

namespace class_1
{
    public class Car 
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Price { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }
        
        public Car()
        {
            this.Name = "";
            this.Age =  0;
            this.Price = 0;
            this.Color = "";
            this.HorsePower = 0;
            
        }
          
        public Car(string name, int age, int price, string color, int horsePower)
        {
            Name = name;
            Age = age;
            Price = price;
            Color = color;
            HorsePower = horsePower;
        }
        public Car(string ln)
        {
            var line1 = ln.Split();
            this.Name = line1[0].ToString();
            this.Age = Convert.ToInt32(line1[1].ToString());
            this.Price = Convert.ToInt32(line1[2].ToString());
            this.Color = Convert.ToString(line1[3]);
            this.HorsePower = Convert.ToInt32(Convert.ToString(line1[4]));
        }

        public void Print()
        {
            Console.WriteLine("car name: {0}, car age: {1}, car price: {2}, car color: {3}, horse power: {4}" ,Name,Age,Price,Color,HorsePower);
        }
        public override string ToString() => $"{Name} {Age} {Price} {Color} {HorsePower}";
            
            
    }
}