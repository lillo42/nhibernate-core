// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace NHibernate.Benchmarks.Models.Orders
{
	public class OrderLine
	{
		public virtual int OrderLineId { get; set; }
		public virtual int Quantity { get; set; }
		public virtual decimal Price { get; set; }
		public virtual bool IsSubjectToTax { get; set; }
		public virtual string SpecialRequests { get; set; }
		public virtual bool IsShipped { get; set; }

		public virtual int OrderId { get; set; }
		public virtual Order Order { get; set; }

		public virtual int ProductId { get; set; }
		public virtual Product Product { get; set; }
	}
}
