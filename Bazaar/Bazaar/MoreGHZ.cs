using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar {
	class MoreGHZ : ComputerDecorator {

		public MoreGHZ(IComputer computer) : base(computer) {

		}
		public override string GetInfo() {
			return "Price: " + GetPrice() + "\nName: " + base.GetName() + "\n" +  "CPU: " +base.GetCpuName() + " " + GetGhzFloat() + "GHz " + base.GetNrCores() + " Cores" + "\nRAM: " + base.GetRamInt() + "Gb";
		}
		public override float GetGhzFloat() {
			return base.GetGhzFloat() + 0.5f;
		}
		public override float GetPrice() {
			return base.GetPrice() + 600f;
		}
	}
}
