namespace Currencies {
	public interface IMoney {
		// easy version (only Dollar):
		Money ConvertToDollar(Bank bank);
		
		// extended version:
		// Money ConvertTo(Bank bank, string currency);
	}
}