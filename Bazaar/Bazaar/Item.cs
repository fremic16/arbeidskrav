using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar {
	abstract class Item {
		public float Price { get; set; }
		public string Name { get; set; }
		public int ID { get; set; }

		protected Item() {
			Price = 5000;
			Name = "Acer";
			ID = 1;
		}
		protected Item(float price, string name, int id) {
			Price = price;
			Name = name;
			ID = id;
		}

		public string PrintString() {
			string print = "Name: " + Name + "\nPrice: " + Price + "$";

			return print;
		}
	}
}
