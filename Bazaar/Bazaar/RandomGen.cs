using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Bazaar {
	static class RandomGen {

		private static readonly RNGCryptoServiceProvider _randomGenerator = new RNGCryptoServiceProvider();

		public static int GetRandom(int min, int max) {
			byte[] randomValue = new byte[1];
			_randomGenerator.GetBytes(randomValue);

			double asciiValueOfRandomChar = Convert.ToDouble(randomValue[0]);

			double multiplier = Math.Max(0, (asciiValueOfRandomChar / 255d) - 0.00000000001d);

			int range = max - min + 1;
			double randomValueInRange = Math.Floor(multiplier * range);

			return (int)(min + randomValueInRange);
		}
	}
}
