using System;
using Task1.Classes;

namespace Task1
{
    internal class Program
    {

        //method to return the car that the user chose
        public static Car CarSelector(Car[] cars)
        {

            while (true)
            {
                
                if (!int.TryParse(Console.ReadLine(), out int selectCar) || selectCar > cars.Length || selectCar < 1)
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }
                if (cars[selectCar - 1].Selected)
                {
                    Console.WriteLine("Car already picked");
                    continue;
                }

                foreach (Car car in cars)
                {
                    if (selectCar == Array.IndexOf(cars, car) + 1)
                    {
                        car.Selected = true;
                        return car;
                    }

                }

            }
        }   
        //method to return the driver that the user chose
        public static Driver DriverSelector(Driver[] drivers)
        {
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out int selectDriver) || selectDriver > drivers.Length || selectDriver < 1)
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }
                if (drivers[selectDriver - 1].Selected)
                {
                    Console.WriteLine("Car already picked");
                    continue;
                }

                foreach (Driver driver in drivers)
                {
                    if (selectDriver == Array.IndexOf(drivers, driver) + 1)
                    {
                        driver.Selected = true;
                        return driver;
                    }

                }
            }
        }
        //method to return which car one 
        public static Car RaceCars(Car carOne, Car carTwo)
        {
            if (carOne.CalculateSpeed() > carTwo.CalculateSpeed())
            {
                return carOne;
            }
            return carTwo;
        }
        static void Main(string[] args)
        {
     
            Car[] cars = {new Car("hyundai", 160), new Car("mazda", 200), new Car("ferrari", 260), new Car("porsche", 210) };
            Driver[] drivers = { new Driver("bob", 2.5M), new Driver("greg", 4.5M), new Driver("jill", 5.00M), new Driver("anne", 3.9M) };
            
            RaceCarGame(cars,drivers);
            
            while (true)
            {
               
                Console.WriteLine("Do you want to play again?");
                string answer = Console.ReadLine().ToLower();
                if (answer == "yes")
                {
                    RaceCarGame(cars, drivers);
                    continue;
                }
                Console.WriteLine("Game Over");
                break;
            }
        }
        public static void RaceCarGame(Car[] cars, Driver[] drivers)
        {
            Console.Clear();
            //given options for the cars
            Console.WriteLine("Choose your first car");
                Console.WriteLine("Options:");
                for (int i = 0; i < cars.Length; i++)
                {
                    Console.WriteLine($"{i + 1}.{cars[i].Model}", Console.ForegroundColor = ConsoleColor.Red);
                }
                Car carOne = CarSelector(cars);
                Console.Clear();
               
            //given options for the drivers
                Console.WriteLine("Choose your driver for the first car");
                Console.WriteLine("Options:");
                for (int i = 0; i < drivers.Length; i++)
                {
                    Console.WriteLine($"{i + 1}.{drivers[i].Name}", Console.ForegroundColor = ConsoleColor.Green);
                }
                Driver driverCarOne = carOne.Driver = DriverSelector(drivers);
                Console.Clear();

            //given option for the second car, but here the first car will be in a different color 
                Console.WriteLine("Choose your second car");
                Console.WriteLine("Options:");
                for (int i = 0; i < cars.Length; i++)
                {
                    if (cars[i].Selected)
                    {
                        Console.WriteLine($"{i + 1}.{cars[i].Model} - First Car", Console.ForegroundColor = ConsoleColor.Yellow);
                    }
                    else { Console.WriteLine($"{i + 1}.{cars[i].Model}", Console.ForegroundColor = ConsoleColor.Blue); }
                }
                Car carTwo = CarSelector(cars);
                Console.Clear();

            //option for the second driver, but here the first driver will be in a different color
                Console.WriteLine("Choose your driver for the second car");
                Console.WriteLine("Options:");
                for (int i = 0; i < drivers.Length; i++)
                {
                    if (drivers[i].Selected)
                    {
                        Console.WriteLine($"{i + 1}.{drivers[i].Name} - First Driver", Console.ForegroundColor = ConsoleColor.Blue);
                    }
                    else { Console.WriteLine($"{i + 1}.{drivers[i].Name}", Console.ForegroundColor = ConsoleColor.Red); }
                }
                Driver driverCarTwo = carTwo.Driver = DriverSelector(drivers);
                Car winner = RaceCars(carOne, carTwo);
            //reseting the selected value if the player chooses to play again
                carOne.Selected = false;
                carTwo.Selected = false;
                driverCarOne.Selected = false;
                driverCarTwo.Selected = false;

                Console.WriteLine( $"The car that won was {winner.Model.ToString().ToUpper()}, with the speed of {winner.Speed}km/h and the driver was {winner.Driver.Name.ToString().ToUpper()}");
                 
        }

    }
}
