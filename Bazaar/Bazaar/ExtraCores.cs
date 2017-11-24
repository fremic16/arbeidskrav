using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar {
	class ExtraCores : ComputerDecorator {

		public ExtraCores(IComputer computer) : base(computer) {

		}

		public override string GetInfo() {
			return "Price: " + GetPrice() + "\nName: " + base.GetName() + "\n" + "CPU: " + base.GetCpuName() + " " + base.GetGhzFloat() + "GHz " + GetNrCores() + " Cores" + "\nRAM: " + base.GetRamInt() + "Gb";
		}
		public override int GetNrCores() {
			return base.GetNrCores() + 2;
		}
 		public override float GetPrice() {
			return base.GetPrice() + 1800f;
		}
	}
}
