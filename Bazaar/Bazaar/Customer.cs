using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar {
	class Customer {
		public string Name { get; set; }
		static ArrayList pocket = new ArrayList();
		public Customer(string name, ArrayList salesMenList)
		{
			Name = name;
			foreach (Merchant m in salesMenList)
			{
				m.ItemForSale += I_ItemForSale;
			}
			//Merchant.ItemForSale += I_ItemForSale;
		}

		void I_ItemForSale(Object sender, EventArgs e)
		{
			/*int size = pocket.Count;
			if (pocket.Count > size)
			{
				for (int i = 0; i < pocket.Count; i++)
				{
					Console.WriteLine(i);
				}
				Console.WriteLine();
			}*/
			Merchant m = (Merchant) sender;
			m.Sale(pocket, Name);
			Console.WriteLine("Event Handled by " + Name);
		}
	}
}
