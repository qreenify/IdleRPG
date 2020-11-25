using System.Runtime.CompilerServices;

namespace Currencies
{
    public class Money
    {
        public string currency;
        protected int amount;
        
        public Money Times(int factor) { 
            return Times(this.amount * factor);
        }

        public override string ToString()
        {
            return $"{this.amount} {GetType().Name}";
        }

        public override bool Equals(object obj)
        {
            if (GetType() != obj?.GetType())
            {
                return false;
            }

            var money = (Money) obj;
            return money.amount == this.amount;
        }
        
        
        
        public static Money Dollar(int amount)
        {
            var money = new Money {amount = amount};
            return money;
        }

        public static Money SEK(int amount)
        {
            var money = new Money {amount = amount};
            return money;
        }
    }
}