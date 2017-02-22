/*
 *  Author: Troy Davis
 *  Project: Module05_Practice - Console (examples: inheritance, switch, exception handling - miles-per-gallon)
 *  Class: IN 2017 (Advanced C#)
 *  Date: Feb 16, 2017 
 *  Revision: Original
 */
 
 using System;

namespace Module05_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            // greeting
            Console.WriteLine("Hello from the Module 05 Main Method");

            // EXAMPLE 1: inheritance (see Animal, Dog, & Cat classes below)
            Dog dog = new Dog();
            dog.Name = "Bowser";
            dog.Weight = 100;
            dog.Bark();

            Cat cat = new Cat();
            cat.Name = "Frisky";
            cat.Weight = 15;
            cat.Meow();

            // EXAMPLE 2: switch (see Month enum below)
            Month mo = Month.February;
            string moName;
            switch (mo)
            {
                case Month.January:
                    moName = "January";
                    break;
                case Month.February:
                    moName = "February";
                    break;
                case Month.March:
                    moName = "March";
                    break;
                case Month.April:
                    moName = "April";
                    break;
                case Month.May:
                    moName = "May";
                    break;
                case Month.June:
                    moName = "June";
                    break;
                case Month.July:
                    moName = "July";
                    break;
                case Month.August:
                    moName = "August";
                    break;
                case Month.September:
                    moName = "September";
                    break;
                case Month.October:
                    moName = "October";
                    break;
                case Month.November:
                    moName = "November";
                    break;
                case Month.December:
                    moName = "December";
                    break;
                default:
                    moName = "Unknown";
                    break;
            }
            Console.WriteLine("\nThe variable 'mo' represents, {0}, the #{1} month of the year.", moName, ((int)mo).ToString());

            // EXAMPLE 3: exception handling
            int milesDriven;
            int gallonsOfGas;
            int mpg = 0;
            try
            {
                Console.Write("\nEnter miles driven: "); milesDriven = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nEnter gallons of gas used: "); gallonsOfGas = Convert.ToInt32(Console.ReadLine());
                mpg = milesDriven / gallonsOfGas;
            }
            catch ( FormatException )
            {
                Console.WriteLine("\nYour entry was not in the correct format ... only whole numbers permitted.");
            }
            catch ( DivideByZeroException )
            {
                Console.WriteLine("\nYou attempted to divide by zero.");
            }
            catch (Exception e)
            {
                //Console.WriteLine("\nYou attempted to divide by zero"); // not always the case, could have entered a character rather than a number or a decimal number
                Console.WriteLine("\nerror: {0}", e.Message); // general case
            }
            finally
            {
                Console.WriteLine("\nYou got {0} miles per gallon.", mpg);
            }
            

            // wait on user to close console
            Console.Write("\nPress 'Enter' to exit: "); Console.ReadLine();
        }
    }
    class Animal
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public void Hello()
        {
            Console.WriteLine("\nHello from the Animal Class.");
        }
    }
    class Dog : Animal
    {
        public void Bark()
        {
            Hello();
            Console.WriteLine("\n\tI'm a {0} pound Dog named {1} ... Woof, Woof!", Weight, Name);
        }
    }
    class Cat : Animal
    {
        public void Meow()
        {
            Hello();
            Console.WriteLine("\n\tI'm a {0} pound Cat named {1} ... Meow, Meow!", Weight, Name);
        }
    }
    enum Month
    {
        January = 1,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }
}
