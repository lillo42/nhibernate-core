using System.Collections.Generic;

namespace NHibernate.Test.NHSpecificTest.GH1079
{
	public class Order
	{
		public virtual ICollection<OrderLine> OrderLines { get; set; } = new HashSet<OrderLine>();
	}

	public class OrderLine
	{
		public virtual int LineNumber { get; set; }
	}
}
