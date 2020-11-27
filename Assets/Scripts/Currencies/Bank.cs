using System;
using UnityEngine;

namespace Currencies {
	public class Bank
	{
		public float exchangeRateSEK = 0.1f;
		public float exchangeRateEuro = 0.5f;
		public Bank(float exchangeRate) {
		}

		public Money ExchangeToDollar(IMoney money) {
			Debug.Log("ExchangeToDollar");
			return money.ConvertToDollar(this);
		}
		public float GetDollarExchangeRate(string from)
		{
			Debug.Log("GetDollarExchangeRate");
			if (from == "SEK") {
				return exchangeRateSEK;
			}

			if (from == "Euro") {
				return exchangeRateEuro;
			}
			throw new SystemException($"{from} is not a valid currency.");
		}
		
		// TODO 3 extended version:
		public float GetExchangeRate(string from, string to) {
			throw new System.NotImplementedException();
		}
	}
}