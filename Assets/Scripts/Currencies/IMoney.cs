namespace Currencies {
	public interface IMoney {
		// easy version (only Dollar):
		Money ConvertToDollar(Bank bank);
		
		// TODO 3 extended version:
		// Money ConvertTo(Bank bank, string currency);
	}
}