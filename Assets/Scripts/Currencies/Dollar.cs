using System;

namespace Currencies {
	public class Dollar : Money
	{
		public static int dollar;
		public Dollar(int amount)
		{
			this.amount = amount * dollar;
		}
	}
}