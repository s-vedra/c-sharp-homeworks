using System;

namespace Model
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long CardNumber { get; set; }
        private decimal Balance { get; set; }
        private int Pin { get; set; }


        public Customer(string firstName, string lastName, long cardNumber, decimal balance, int pin)
        {
            FirstName = firstName;
            LastName = lastName;
            CardNumber = cardNumber;
            Balance = balance;
            Pin = pin;
        }

        public decimal ReturnAccountBalance()
        {
            return Balance;
        }

        public bool PinMatch(long pinUser)
        {
            if (Pin == pinUser)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string AddMoney(int amount)
        {

            return $"You added {amount:C}$, your new balance is {Balance += amount:C}$";
        }

        public bool WithdrawMoney(int amount)
        {
            if (Balance < amount)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
