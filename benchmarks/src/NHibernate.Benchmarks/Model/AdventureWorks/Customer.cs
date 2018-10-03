// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace NHibernate.Benchmarks.Models.AdventureWorks
{
    public class Customer
    {
        public Customer()
        {
            SalesOrderHeader = new HashSet<SalesOrderHeader>();
        }

        public virtual int CustomerID { get; set; }
        public virtual string AccountNumber { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual int? PersonID { get; set; }
#pragma warning disable IDE1006 // Naming Styles
        public virtual Guid rowguid { get; set; }
#pragma warning restore IDE1006 // Naming Styles
        public virtual int? StoreID { get; set; }
        public virtual int? TerritoryID { get; set; }

        public virtual ICollection<SalesOrderHeader> SalesOrderHeader { get; set; }
        public virtual Person Person { get; set; }
        public virtual Store Store { get; set; }
        public virtual SalesTerritory Territory { get; set; }
    }
}
