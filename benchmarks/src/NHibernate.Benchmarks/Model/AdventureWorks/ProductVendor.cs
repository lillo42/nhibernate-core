// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace NHibernate.Benchmarks.Models.AdventureWorks
{
    public class ProductVendor
    {
        public virtual int ProductID { get; set; }
        public virtual int BusinessEntityID { get; set; }
        public virtual int AverageLeadTime { get; set; }
        public virtual decimal? LastReceiptCost { get; set; }
        public virtual DateTime? LastReceiptDate { get; set; }
        public virtual int MaxOrderQty { get; set; }
        public virtual int MinOrderQty { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual int? OnOrderQty { get; set; }
        public virtual decimal StandardPrice { get; set; }
        public virtual string UnitMeasureCode { get; set; }

        public virtual Vendor BusinessEntity { get; set; }
        public virtual Product Product { get; set; }
        public virtual UnitMeasure UnitMeasureCodeNavigation { get; set; }
    }
}
