using System.Runtime.CompilerServices;
using Resources;

namespace Currencies {
    public class Money {
        public string currency;
        protected int amount;
        private static int protectedAmount;
        public Money(int amount) {
            this.amount = amount;
        }

        public Money Times(int factor) {
            return Times(protectedAmount * factor);
        }

        public override string ToString() {
            return $"{this.amount} {GetType().Name}";
        }

        public override bool Equals(object obj) {
            if (GetType() != obj?.GetType()) {
                return false;
            }

            var money = (Money) obj;
            return money.amount == this.amount;
        }


        public static Money Dollar(int amount) {
            var money = Dollar(amount);
            return money;
        }

        public static Money SEK(int amount) {
            var money = SEK(amount);
            return money;
        }
    }
}