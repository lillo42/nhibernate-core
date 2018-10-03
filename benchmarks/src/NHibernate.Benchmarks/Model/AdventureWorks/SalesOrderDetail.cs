// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace NHibernate.Benchmarks.Models.AdventureWorks
{
    public class SalesOrderDetail
    {
        public virtual int SalesOrderID { get; set; }
        public virtual int SalesOrderDetailID { get; set; }
        public virtual string CarrierTrackingNumber { get; set; }
        public virtual decimal LineTotal { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual short OrderQty { get; set; }
        public virtual int ProductID { get; set; }
#pragma warning disable IDE1006 // Naming Styles
        public virtual Guid rowguid { get; set; }
#pragma warning restore IDE1006 // Naming Styles
        public virtual int SpecialOfferID { get; set; }
        public virtual decimal UnitPrice { get; set; }
        public virtual decimal UnitPriceDiscount { get; set; }

        public virtual SalesOrderHeader SalesOrder { get; set; }
        public virtual SpecialOfferProduct SpecialOfferProduct { get; set; }
    }
}
