using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Bazaar
{
	class Merchant
	{

		public string Name { get; private set; }
		public float Income { get; private set; }
		public static ArrayList Items = new ArrayList();

		public event EventHandler ItemForSale;
		private readonly Object _salesLock = new Object();

		public Merchant(string name)
		{
			Name = name;
			Income = 0f;
		}

		public void Advertise()
		{
			if (Items.Count == 0)
			{
				Items.Add(Factory.CreateComputer());
				OnItemForSale(EventArgs.Empty);
			}
			OnItemForSale(EventArgs.Empty);
		}

		protected virtual void OnItemForSale(EventArgs e)
		{
			EventHandler handler = ItemForSale;
			if (handler != null)
			{
				handler(this, e);
			}
		}
		public ArrayList Sale(ArrayList pocket, string name)
		{
			lock (_salesLock)
			{
				if (Items.Count != 0)
				{
					pocket.Add(Items[0]);
					Items.RemoveAt(0);
					Console.WriteLine(name + " bought the item");
				}
				
			}
			return pocket;
		}
	}
}
