
using System;
using Model;

namespace ATMApp
{
    internal class Program
    {
        //method to parse all the inputs
        public static int Parsing(string input)
        {
            while (true)
            {
                if (!int.TryParse(input, out int number))
                {
                    return 0;
                }
                return number;
            }
        }

        //method to return the correct enum dependable on the choice
        public static Balance ReturnEnum(int choice)
        {
            Balance choices;
            if (choice == 1)
            {
               return choices = Balance.ReturnAccountBalance;

            } else if (choice == 2)
            {
                return choices = Balance.WithdrawMoney;

            } else if (choice == 3)
            {
                return choices = Balance.AddMoney;
            }
            return choices = 0;
        }

        //return the customer if the number card matches
        public static Customer FindCustomer(Customer[] customers, long cardNum)
        {
            foreach (Customer customer in customers)
            {
                if (customer.CardNumber == cardNum)
                {
                    return customer;
                }
            }
            return null;
        }

        //method to return the card number and clean it up
        public static long ReturnCardNumber()
        {
            while (true)
            {
                string input = Console.ReadLine().Replace("-", string.Empty);

                if (!long.TryParse(input, out long cardNum))
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }
                return cardNum;
            }
        }

        //method to return the choice the user inputed
        public static void ReturnChoice(Customer customer,string inputChoice)
        {
            while (true)
            { 
                if (ReturnEnum(Parsing(inputChoice)) == Balance.ReturnAccountBalance)
                {
                   Console.WriteLine($"Your balance is {customer.ReturnAccountBalance():C}$");
                    break;

                } else if (ReturnEnum(Parsing(inputChoice)) == Balance.WithdrawMoney)
                {
                    Console.WriteLine("Enter amount");
                    string amountInput = Console.ReadLine();
                    if (!customer.WithdrawMoney(Parsing(amountInput)))
                    {
                        Console.WriteLine("You don't have enough money on your card");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"You withdrew {Parsing(amountInput):C}, your new balance is {customer.ReturnAccountBalance() - Parsing(amountInput):C}$");
                        break;
                    }
                } else if (ReturnEnum(Parsing(inputChoice)) == Balance.AddMoney)
                {
                    Console.WriteLine("Enter amount");
                    string amountInput = Console.ReadLine();
                    Console.WriteLine(customer.AddMoney(Parsing(amountInput)));
                    break;
                } else
                {
                    Console.WriteLine("Invalid input, please only choose 1, 2 or 3");
                    break;
                }
            }
        }
        //check the pin the user inputs if it matches, give him an option to choose what he wants to do next, if not input the credit card num again
        public static void CheckPin(Customer customer)
        {
            int attempt = 3;
            while (true)
            {
                Console.WriteLine("Please enter your pin");
                string pin = Console.ReadLine();
      
                if (customer.PinMatch(Parsing(pin)))
                {
                    Console.Clear();
                    Console.WriteLine($"Hello {customer.FirstName} {customer.LastName}");
                    Console.WriteLine("What would you like to do? \n1.Check Balance \n2.Cash Withdrawal \n3.Cash Deposit");
                    break;
                }
                else if (attempt == 0)
                {
                    //if the user enters the pin incorrectly 3 times, ask for his credit card number again 
                    Console.Clear();
                    Console.WriteLine("Too many attempts");

                    Console.WriteLine("Please enter your card number");
                    ReturnCardNumber();
                    continue;
                }
                else
                {
                    Console.WriteLine($"Wrong pin. You have {attempt} attempts left");
                    attempt--;

                    continue;
                }
            }
        }
            static void Main(string[] args)
        {
            //array of customers
            Customer[] customers = {new Customer("Bob","Bobsky",1234123412341234 ,1550, 1234),
                                    new Customer("Jenn","Glenn",1235123512351235 ,2550, 2564),
                                    new Customer("Harry","Potter",1232123412341235 ,750, 1237),
                                    new Customer("John","Smith",1234123412341277 ,1000 , 1577) };

            Console.WriteLine("Welcome to the ATM app \nPlease enter your card number");



            while (true)
            {
                Customer customer = FindCustomer(customers, ReturnCardNumber());
                
                if (customer == null)
                {
                    Console.WriteLine("User not found");
                    continue;
                }
                else
                {
                    CheckPin(customer);
                    ReturnChoice(customer,Console.ReadLine());
                }
                while (true)
                {
                    Console.WriteLine("Do you want to do another action? Yes/No");
                    string answer = Console.ReadLine();
                    if (answer.ToLower() == "yes")
                    {
                        Console.WriteLine("Enter choice");
                        ReturnChoice(customer, Console.ReadLine());
                        continue;
                    }
                    else if (answer.ToLower() == "no")
                    {
                        Console.Clear();
                        Console.WriteLine("Goodbye!");
                        break;
                    }
                }
                break;
            }

        }

    }
}

