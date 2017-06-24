using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeBank.Services.ExceptionHandling
{
	[Serializable]
	class AccountNotFoundException : Exception
	{
		public AccountNotFoundException()
		{

		}

		public AccountNotFoundException(string name)
			: base(String.Format("The following account could not be found: {0}", name))
		{

		}

	}

	[Serializable]
	class WithdrawalAmountTooLargeException : Exception
	{
		public WithdrawalAmountTooLargeException()
		{

		}

		public WithdrawalAmountTooLargeException(string name)
			: base(String.Format("The withdrawal amount is too large for account: {0}", name))
		{

		}

	}




}

