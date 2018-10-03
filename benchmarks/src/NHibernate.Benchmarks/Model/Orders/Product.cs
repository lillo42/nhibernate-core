// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace NHibernate.Benchmarks.Models.Orders
{
    public class Product
    {
        public virtual int ProductId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string SKU { get; set; }
        public virtual decimal Retail { get; set; }
        public virtual decimal CurrentPrice { get; set; }
        public virtual int TargetStockLevel { get; set; }
        public virtual int ActualStockLevel { get; set; }
        public virtual int? ReorderStockLevel { get; set; }
        public virtual int QuantityOnOrder { get; set; }
        public virtual DateTime? NextShipmentExpected { get; set; }
        public virtual bool IsDiscontinued { get; set; }

        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
