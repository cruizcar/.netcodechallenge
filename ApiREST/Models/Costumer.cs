using System;
namespace ApiREST
{
	public class Costumer
	{
		public long Id { get; set; }
		public String Name { get; set; }
		public String Surname { get; set; }
		public String Email { get; set; }

		public Costumer()
		{
		}

		public override string ToString()
		{
			Console.WriteLine("----------------   Costumer info   ----------------");
			Console.WriteLine("Email: " + Email);
			Console.WriteLine("Name: " + Name + "\t" + Surname);
			Console.WriteLine();
			return base.ToString();
		}
	}
}
