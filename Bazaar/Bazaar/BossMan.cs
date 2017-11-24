using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar {
	class BossMan
	{
		public ArrayList SalesMenList;
		public ArrayList CustomersList;

		public BossMan(int iSalesMen,int iCustomers)
		{
			HireSalesMen(iSalesMen);
			GetCustomers(iCustomers);

			foreach (Merchant m in SalesMenList)
			{
				Console.WriteLine("Merchant " + m.Name + " is advertising");
				m.Advertise();
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
	}
}
