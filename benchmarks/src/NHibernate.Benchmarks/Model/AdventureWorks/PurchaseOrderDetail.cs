// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace NHibernate.Benchmarks.Models.AdventureWorks
{
    public class PurchaseOrderDetail
    {
        public virtual int PurchaseOrderID { get; set; }
        public virtual int PurchaseOrderDetailID { get; set; }
        public virtual DateTime DueDate { get; set; }
        public virtual decimal LineTotal { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual short OrderQty { get; set; }
        public virtual int ProductID { get; set; }
        public virtual decimal ReceivedQty { get; set; }
        public virtual decimal RejectedQty { get; set; }
        public virtual decimal StockedQty { get; set; }
        public virtual decimal UnitPrice { get; set; }

        public virtual Product Product { get; set; }
        public virtual PurchaseOrderHeader PurchaseOrder { get; set; }
    }
}
