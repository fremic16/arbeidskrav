using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar {
	class Computer : Item, IComputer {

		private readonly int _ram;
		private readonly string _cpu;
		private readonly float _ghz;
		private readonly int _cores;
		private readonly float _price;
		private readonly string _name;
		public Computer() {
			_price = 1000.0f;
			_name = "Acer";
			_ram = 4;
			_cpu = "i7";
			_ghz = 1.5f;
			_cores = 2;
		}
		public Computer(float price, string name,int id, int ram, string cpu, float ghz, int cores){
			_price = price;
			_name = name;
			_ram = ram;
			_cpu = cpu;
			_ghz = ghz;
			_cores = cores;
		}
		public float GetPrice() {
			return _price;
		}
		public string GetName() {
			return _name;
		}

		public string GetInfo() {
			return "Price: " + GetPrice() + "\nName: " + GetName() + "\n" + GetSpecs();
		}

		public string GetCpu() {
			string cpu = "CPU: " + GetCpuName() + " " + GetGhzFloat() + "GHz" + " " + GetNrCores() + " Cores";

			return cpu;
		}

		public string GetRam() {
			string ram = "Ram: " + GetRamInt()+ "Gb";;

			return ram;
		}

		public string GetSpecs() {
			string specs = GetCpu() + "\n" + GetRam();

			return specs;
		}

		public int GetRamInt() {
			return _ram;
		}

		public string GetCpuName() {
			return _cpu;
		}

		public float GetGhzFloat() {
			return _ghz;
		}

		public int GetNrCores() {
			return _cores;
		}
	}
}
