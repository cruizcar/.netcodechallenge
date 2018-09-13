using System;
namespace ApiREST
{
	public class Phone
	{
		public int Id { get; set; }
		public String Name { get; set; }
		public String ImageUrl { get; set; }
		public String Description { get; set; }
		public Decimal Price { get; set; }

		public Phone()
		{
			Id = 0;
			Price = 0; 
		}

		public bool CompareTo(Phone obj)
		{
			if (this.Id.CompareTo(obj.Id)!= 0)
				return false; 
			else if (String.Compare(this.Name,obj.Name)!=0)
				return false; 
			else if (String.Compare(this.ImageUrl,obj.ImageUrl)!=0)
				return false; 
			else if (String.Compare(this.Description,obj.Description)!=0)
				return false; 
			else if (this.Price.CompareTo(obj.Price)!= 0)
				return false;
			else{
				return true;
			}
		}
	}
}
