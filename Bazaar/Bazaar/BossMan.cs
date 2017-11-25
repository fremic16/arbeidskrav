using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bazaar {
	class BossMan
	{
		public ArrayList SalesMenList;
		public ArrayList CustomersList;
		public ArrayList CustomerThreadList;

		public BossMan(int iSalesMen,int iCustomers)
		{
			HireSalesMen(iSalesMen);
			GetCustomers(iCustomers);
			ThreadGenerator();

			foreach (Merchant m in SalesMenList) {
				m.ItemForSale += I_ItemForSale;
			}

			foreach (Merchant m in SalesMenList)
			{
				Console.WriteLine("Merchant " + m.Name + " is advertising");
				m.Advertise();
				Thread.Sleep(2000);
			}
		}

		private ArrayList HireSalesMen(int iSalesMen)
		{
			SalesMenList = new ArrayList();

			for (int i = 0; i < iSalesMen; i++)
			{
				SalesMenList.Add(Factory.CreateMerchant());
			}
			return SalesMenList;
		}

		private ArrayList GetCustomers(int iCustomers)
		{
			CustomersList = new ArrayList();

			for (int i = 0; i < iCustomers; i++)
			{
				CustomersList.Add(Factory.CreateCustomer(SalesMenList));
			}

			return CustomersList;
		}

		private void ThreadGenerator()
		{
			if (SalesMenList.Count > 0 && CustomersList.Count > 0)
			{
				CustomerThreadList = new ArrayList();
				for (int i = 0; i < CustomersList.Count; i++)
				{
					CustomerThreadList.Add(Factory.CreateThread((Customer)CustomersList[i]));
				}
			}
		}

		void I_ItemForSale(Object sender, EventArgs e)
		{
			Merchant m = (Merchant) sender;

			foreach (Thread t in CustomerThreadList)
			{
				t.Start(m);
			}
			Pause();
		}

		void Pause()
		{
			Console.WriteLine("Press any key to continue...");
			Console.ReadKey(true);
		}
	}
}
