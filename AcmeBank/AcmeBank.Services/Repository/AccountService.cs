using AcmeBank.Data;
using AcmeBank.Data.Enums;
using AcmeBank.Services.ExceptionHandling;
using AcmeBank.Services.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeBank.Services.Repository
{
	public class AccountService : IAccountService
	{
		public void deposit(long accountId, int amountToDeposit)
		{
			using (var db = new DBModel())
			{
				var acc = db.tblAccounts.Where(x => x.Id == accountId).FirstOrDefault();

				acc.Balance += amountToDeposit;

				db.Entry(acc).State = EntityState.Modified;

				db.SaveChanges();

			}
		}

		public void openCurrentAccount(long customerId)
		{
			using (var db = new DBModel())
			{
				var cust = db.tblCustomers.Where(x=>x.Id == customerId).FirstOrDefault();

				if (cust != null)
				{
					db.tblAccounts.Add(new tblAccount { fkLKAccountType = (long) AccountType.ChequeCurrent, Balance = 0 , fkCustomerId = cust.Id});
					db.SaveChanges();
				}
			}
		}

		public void openSavingsAccount(long customerId, int amountToDeposit)
		{
			if (amountToDeposit >= 1000)
			{
				using (var db = new DBModel())
				{
					var cust = db.tblCustomers.Where(x => x.Id == customerId).FirstOrDefault();

					if (cust != null)
					{
						db.tblAccounts.Add(new tblAccount { fkLKAccountType = (long)AccountType.Savings, Balance = amountToDeposit, fkCustomerId = cust.Id });
						db.SaveChanges();
					}
				}
			}
		}

		public void withdraw(long accountId, int amountToWithdraw)
		{
			
			using (var db = new DBModel())
			{
				bool transact = false;
				//Get customer type
				var acc = db.tblAccounts.Where(x => x.Id == accountId).FirstOrDefault();

				if (acc == null)
				{
					throw new AccountNotFoundException();
				}
				else
				{
					AccountType accType = (AccountType)acc.fkLKAccountType;

					switch (accType)
					{
						case AccountType.ChequeCurrent:
							if (acc.Balance > -100000)
							{

					
								if (acc.Balance >= amountToWithdraw)
								{
									transact = true;

								}
								else
								{

									throw new WithdrawalAmountTooLargeException();
								}
							}
							else
							{
								throw new WithdrawalAmountTooLargeException();
							}
							break;
						case AccountType.Credit:
							//TODO: Add Credit Card functionality
							break;
						case AccountType.Savings:
							if (acc.Balance > 1000) {
								
								var availBalance = acc.Balance - 1000;

								if (availBalance >= amountToWithdraw)
								{
									transact = true;

								}
								else {

									throw new WithdrawalAmountTooLargeException();
								}
							}else
							{
								throw new WithdrawalAmountTooLargeException();
							}
							break;
					}

				}
				if (transact) {

					acc.Balance -= amountToWithdraw;

					db.Entry(acc).State = EntityState.Modified;

					db.SaveChanges();
				}
			}

				
		}

	}

}
