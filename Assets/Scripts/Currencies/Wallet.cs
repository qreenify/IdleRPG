namespace Currencies {
	public class Wallet : IMoney {
		readonly Money a;
		readonly Money b;

		public Wallet(Money a, Money b) {
			this.a = a;
			this.b = b;
		}

		public Money ConvertToDollar(Bank bank) {
			var aDollar = bank.ExchangeToDollar(a);
			var bDollar = bank.ExchangeToDollar(b);
			return bank.ExchangeToDollar(aDollar.Add(bDollar));
		}
	}
}