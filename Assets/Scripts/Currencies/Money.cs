namespace Currencies {
	public class Money {
		protected int amount;
		protected string currency;

		public Money(int amount, string currency) {
			this.amount = amount;
			this.currency = currency;
		}
		
		public override string ToString() {
			return $"{this.amount} {this.currency}";
		}

		public override bool Equals(object obj) {
			if (GetType() != obj?.GetType()) {
				return false;
			}
			var money = (Money) obj;
			if (this.currency != money.currency)
				return false;
			return money.amount == this.amount;
		}

		public static Money Dollar(int amount) {
			return new Money(amount, "Dollar");
		}

		public static Money SEK(int amount) {
			return new Money(amount, "SEK");
		}
		
		public Money Times(int factor) {
			return new Money(this.amount * factor, this.currency);
		}
	}
}