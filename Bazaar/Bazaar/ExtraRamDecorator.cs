using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar {
	class ExtraRamDecorator : ComputerDecorator {

		public ExtraRamDecorator(IComputer computer) : base(computer){
		}
		public override string GetInfo() {
			return "Price: " + GetPrice() + "\nName: " + base.GetName() + "\n" + "CPU: " + base.GetCpuName() + " " + base.GetGhzFloat() + "GHz " + base.GetNrCores() + " Cores" + "\n" + "RAM: " + GetRamInt() + "Gb";
		}
		public override int GetRamInt() {

			return base.GetRamInt() * 2;
		}

		public override float GetPrice() {
			return base.GetPrice() + 800f;
		}
	}
}
