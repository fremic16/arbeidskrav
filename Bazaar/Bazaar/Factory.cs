using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bazaar {
	class Factory
	{
		private static int _merchantCounter = 1;
		private static int _customerCounter = 1;
		Merchant mer = new Merchant("Test");

		private Factory() { }

		public static Merchant CreateMerchant()
		{
			Merchant m = new Merchant("Tomas" + _merchantCounter);
			_merchantCounter++;
			return m;
		}

		public static Customer CreateCustomer(ArrayList salesMenList)
		{
			Customer c = new Customer("Kunde" +_customerCounter,salesMenList);
			_customerCounter++;
			return c;
		}
		public static IComputer CreateComputer() {
			IComputer pc = new Computer();
			int i = RandomGen.GetRandom(0,4);

			while (i != 0) {
				switch (i) {
					case 1:
						pc = new MoreGHZ(pc);
						break;
					case 2:
						pc = new ExtraRamDecorator(pc);
						break;
					default :
						pc = new ExtraCores(pc);
						break;
				}
				i = RandomGen.GetRandom(0,4);
			}
			return pc;
		}

		public static Thread CreateThread(Customer c)
		{
			Thread t = new Thread(c.ShoppingSpree);
			return t;
		}
	}
}
