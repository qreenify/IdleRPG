namespace Currencies {
	public class Wallet : IMoney {
		readonly Money a;
		readonly Money b;

		public Wallet(Money a, Money b) {
			this.a = a;
			this.b = b;
		}

		public Money ConvertToDollar(Bank bank) {
			// TODO 2 exchange our moneys to dollar, then add them (so we definitely get Money, and not another wallet)
			throw new System.NotImplementedException();
		}
	}
}