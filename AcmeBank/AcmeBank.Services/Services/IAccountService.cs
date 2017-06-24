namespace AcmeBank.Services.Services
{
	public interface IAccountService
	{
		 void openSavingsAccount(long customerId, int amountToDeposit);
		 void openCurrentAccount(long customerId);
		 void withdraw(long accountId, int amountToWithdraw);
		 void deposit(long accountId, int amountToDeposit);
	}
}
