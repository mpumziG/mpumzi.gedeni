using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeBank
{
	class Program
	{
		static void Main(string[] args)
		{


		var	accService = new Services.Repository.AccountService();

			//.openCurrentAccount(1);
			Console.WriteLine("Press anny Key to start");
			accService.withdraw(2, 4900);
			//accService.openSavingsAccount(3,500);



			Console.ReadLine();

		}
	}
}
