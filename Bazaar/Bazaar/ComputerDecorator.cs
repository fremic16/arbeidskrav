using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar {

	abstract class ComputerDecorator : IComputer {

	private readonly IComputer _original;

	protected ComputerDecorator(IComputer computer) {
		_original = computer;
	}

		public virtual float GetPrice() {
			return _original.GetPrice();
		}
		public virtual string GetName() {
			return _original.GetName();
		}

		public virtual int GetNrCores() {
			return _original.GetNrCores();
		}
	
	public virtual string GetCpu() {
			return _original.GetCpu();
	}

		public virtual string GetCpuName() {
			return _original.GetCpuName();
		}

		public virtual float GetGhzFloat() {
			return _original.GetGhzFloat();
		}

		public virtual string GetInfo() {
		return _original.GetInfo();
	}

		public virtual string GetSpecs() {
			string specs = GetCpu() + "\n" + GetRam();

			return specs;
		}

		public virtual string GetRam() {
		return _original.GetRam();
	}

		public virtual int GetRamInt() {
			return _original.GetRamInt();
		}
	}

}
