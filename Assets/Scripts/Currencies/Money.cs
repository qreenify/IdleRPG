using System.Runtime.InteropServices;

namespace Currencies {
    public class Money {
        public static string currency;
        protected int amount;
        private static int protectedAmount;

        public Money(int amount) {
            this.amount = amount;
        }

        public Money Times(int factor) {
            return new Money(amount * factor);
        }
        
        public override string ToString() {
            return $"{amount} {currency}";
        }

        public override bool Equals(object obj) {
            if (GetType() != obj?.GetType()) {
                return false;
            }
            var money = (Money) obj;
            return money.amount == amount;
        }

        public static Money Dollar(int amount) {
            var dollar = amount;
            currency = "Dollar";
            return new Money(dollar);
            
        }

        public static Money SEK(int amount) {
            var sek = amount;
            currency = "SEK";
            return new Money(sek);
        }
    }
}