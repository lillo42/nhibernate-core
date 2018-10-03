// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace NHibernate.Benchmarks.Models.AdventureWorks
{
    public class Vendor
    {
        public Vendor()
        {
            ProductVendor = new HashSet<ProductVendor>();
            PurchaseOrderHeader = new HashSet<PurchaseOrderHeader>();
        }

        public virtual int BusinessEntityID { get; set; }
        public virtual string AccountNumber { get; set; }
        public virtual bool ActiveFlag { get; set; }
        public virtual byte CreditRating { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual string Name { get; set; }
        public virtual bool PreferredVendorStatus { get; set; }
        public virtual string PurchasingWebServiceURL { get; set; }

        public virtual ICollection<ProductVendor> ProductVendor { get; set; }
        public virtual ICollection<PurchaseOrderHeader> PurchaseOrderHeader { get; set; }
        public virtual BusinessEntity BusinessEntity { get; set; }
    }
}
