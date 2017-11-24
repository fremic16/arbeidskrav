using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar {
	interface IComputer {

		float GetPrice();
		string GetName();
		string GetInfo();
		string GetCpu();
		string GetRam();
		int GetRamInt();
		string GetCpuName();
		float GetGhzFloat();
		int GetNrCores();
	}
}
