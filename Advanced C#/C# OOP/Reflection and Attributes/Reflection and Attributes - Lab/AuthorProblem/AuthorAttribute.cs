using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorProblem
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class AuthorAttribute : Attribute
	{
		public AuthorAttribute(string name)
		{
			Name = name;
		}
		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

	}
}
