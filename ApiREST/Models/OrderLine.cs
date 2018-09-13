using System;
namespace ApiREST
{
	public class OrderLine
	{
		public long IdOrder { get; set; }
		public long IdLine { get; set; }
		public Phone Phone { get; set; }

		public OrderLine()
		{
			IdOrder = 0;
			IdLine = 0;
		}

		public override string ToString()
		{
			Console.WriteLine(IdLine + "\t" + Phone.Id + "\t" + Phone.Name + "\t" + Phone.Price);
			return base.ToString();
		}
	}
}
