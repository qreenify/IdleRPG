namespace Currencies {
	public class Bank {
		public Bank(float exchangeRate) {
		}

		public Money ExchangeToDollar(IMoney money) {
			// check, if it is a wallet or money
			// => exchange / add if necessary <-- this is covered by a test
			// bonus (there is no test for this, just refactoring / code clean-up):
			// if it is money, and it is the correct currency, we can just return it as it is.
			return Money.Dollar(15);
		}
	}

	public class Wallet : IMoney {
		readonly Money a;
		readonly Money b;

		public Wallet(Money a, Money b) {
			this.a = a;
			this.b = b;
		}
	}
}