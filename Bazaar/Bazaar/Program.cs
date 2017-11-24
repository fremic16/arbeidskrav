using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar {
	class Program {
		static void Main(string[] args) {

			/*for (int i = 0; i < 10; i++) {
				var pc = Factory.CreateComputer();
				Console.WriteLine(pc.GetInfo());
				Console.WriteLine();
				pc = null;
			}*/

			BossMan boss = new BossMan(4,4);
			Console.ReadKey(true);
		}
	}
}
