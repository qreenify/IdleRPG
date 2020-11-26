using NUnit.Framework;

namespace Currencies.Tests {
	// case 1: only one class in a namespace => make the namespace to a class
	/*
	 * before:
	 * namespace Multiply {
	 *    class Tests {
	 *    }
	 * }
	 */
	public class Multiply {
		[Test]
		public void Result() {
			var five = Money.Dollar(5);
			Assert.AreEqual(Money.Dollar(10), five.Times(2));
			Assert.AreEqual(Money.Dollar(15), five.Times(3));
		}

		[Test]
		public void ResultWithSEK() {
			var five = Money.SEK(5);
			Assert.AreEqual(Money.SEK(10), five.Times(2)); 
			Assert.AreEqual(Money.SEK(15), five.Times(3));
		}
	
		[Test]
		public void DoesNotAffectOriginalInstance() {
			var five = Money.Dollar(5);
			five.Times(2);
			Assert.AreEqual(Money.Dollar(5), five);
		}
	}
	
	// case 1: multiple classes in one namespace
	namespace Equal {
		public class SameType {
			[Test]
			public void SameCurrencyAmountsAreEqual() {
				Assert.AreEqual(Money.Dollar(1), Money.Dollar(1));
			}
		
			[Test]
			public void DifferentAmountsAreInEqual() {
				Assert.AreNotEqual(Money.Dollar(1), Money.Dollar(2));
			}
		
			[Test]
			public void DifferentCurrenciesAreUnEqual() {
				Assert.AreNotEqual(Money.Dollar(1), Money.SEK(1));
			}
		}
		public class DifferentType {
			[Test]
			public void OtherTypesAreUnEqual() {
				Assert.AreNotEqual(Money.Dollar(1), 1);
				Assert.False(Money.Dollar(1).Equals(null));
			}
		}
	}
	public class General {
		[Test]
		public void ToStringFormat() {
			Assert.AreEqual("5 Dollar", Money.Dollar(5).ToString());
			Assert.AreEqual("5 SEK", Money.SEK(5).ToString());
		}
	}
}