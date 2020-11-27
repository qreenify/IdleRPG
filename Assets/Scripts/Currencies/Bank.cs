namespace Currencies {
	public class Bank {
		public Bank(float exchangeRate) {
		}

		public Money ExchangeToDollar(IMoney money) {
			return money.ConvertToDollar(this);
		}

		// TODO 1 easy version:
		public float GetDollarExchangeRate(string from) {
			throw new System.NotImplementedException();
		}
		
		// TODO 3 extended version:
		public float GetExchangeRate(string from, string to) {
			throw new System.NotImplementedException();
		}
	}
}