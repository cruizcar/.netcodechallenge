using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ApiREST
{
	public class Order
	{
		public long Id { get; set; }
		public DateTime OrderDate { get; set; }
		public Costumer Costumer { get; set; }
		public List<OrderLine> OrderLines { get; set; }
		public Decimal TotalPrice { get; set; }

		public Order()
		{
			Id = 0;
			OrderLines = new List<OrderLine>();
			TotalPrice = 0; 
		}

		public int Validate(){
			PhoneController phoneController = new PhoneController();

			if (this.OrderDate.CompareTo(DateTime.Now) > 0)
				return -1;
			if (this.Costumer == null || this.Costumer.Id == 0)
				return -2;
			
			foreach (OrderLine p in OrderLines){
				bool equals = false;

				ActionResult<Phone> actionResult = phoneController.GetById(p.Phone.Id);

				Phone phone = actionResult.Value;
				if (phone == null)
					equals = false;
				else
					equals = phone.CompareTo(p.Phone);

				if (!equals)
					return -3;
			}
			return 0;
		}

		public Decimal CalculateTotal(){
			foreach (OrderLine o in OrderLines)
				TotalPrice = TotalPrice + o.Phone.Price;
			return TotalPrice;
		}

		public override string ToString()
		{
			Console.WriteLine("***********************************");
			Console.WriteLine("New Order" + "\t\t\t" + "Order Id:\t" + Id);
			Console.WriteLine();
			Console.WriteLine("Order Date:\t" + OrderDate.ToString("dd/MM/yyyy hh:mm"));
			Console.WriteLine();
			Costumer.ToString();
			Console.WriteLine("-------------------- Order lines --------------------");
			Console.WriteLine("Line" + "\t" + "ID" + "\t" + "Name" + "\t" + "Price");
			foreach(OrderLine o in OrderLines)
				o.ToString();
			Console.WriteLine("-------------------- ----------- --------------------");
			Console.WriteLine("TOTAL PRICE: " + TotalPrice.ToString());
			return base.ToString();
		}
	}
}
