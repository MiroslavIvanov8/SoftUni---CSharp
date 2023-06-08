using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawData
{
    public class Engine
    {

		private int speed;
        private int power;
        public int Speed
		{
			get { return speed; }
			set { speed = value; }
		}

		public Engine (int speed, int power)
		{
			Speed= speed;
			Power= power;
		}
		public int Power
		{
			get { return power; }
			set { power = value; }
		}


	}
}
