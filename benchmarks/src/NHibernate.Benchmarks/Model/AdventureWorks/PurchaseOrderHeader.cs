// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace NHibernate.Benchmarks.Models.AdventureWorks
{
    public class PurchaseOrderHeader
    {
        public PurchaseOrderHeader()
        {
            PurchaseOrderDetail = new HashSet<PurchaseOrderDetail>();
        }

        public virtual int PurchaseOrderID { get; set; }
        public virtual int EmployeeID { get; set; }
        public virtual decimal Freight { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual DateTime OrderDate { get; set; }
        public virtual byte RevisionNumber { get; set; }
        public virtual DateTime? ShipDate { get; set; }
        public virtual int ShipMethodID { get; set; }
        public virtual byte Status { get; set; }
        public virtual decimal SubTotal { get; set; }
        public virtual decimal TaxAmt { get; set; }
        public virtual decimal TotalDue { get; set; }
        public virtual int VendorID { get; set; }

        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ShipMethod ShipMethod { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
