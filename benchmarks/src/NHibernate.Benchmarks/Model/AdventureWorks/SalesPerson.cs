// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace NHibernate.Benchmarks.Models.AdventureWorks
{
    public class SalesPerson
    {
        public SalesPerson()
        {
            SalesOrderHeader = new HashSet<SalesOrderHeader>();
            SalesPersonQuotaHistory = new HashSet<SalesPersonQuotaHistory>();
            SalesTerritoryHistory = new HashSet<SalesTerritoryHistory>();
            Store = new HashSet<Store>();
        }

        public virtual int BusinessEntityID { get; set; }
        public virtual decimal Bonus { get; set; }
        public virtual decimal CommissionPct { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
#pragma warning disable IDE1006 // Naming Styles
        public virtual Guid rowguid { get; set; }
#pragma warning restore IDE1006 // Naming Styles
        public virtual decimal SalesLastYear { get; set; }
        public virtual decimal? SalesQuota { get; set; }
        public virtual decimal SalesYTD { get; set; }
        public virtual int? TerritoryID { get; set; }

        public virtual ICollection<SalesOrderHeader> SalesOrderHeader { get; set; }
        public virtual ICollection<SalesPersonQuotaHistory> SalesPersonQuotaHistory { get; set; }
        public virtual ICollection<SalesTerritoryHistory> SalesTerritoryHistory { get; set; }
        public virtual ICollection<Store> Store { get; set; }
        public virtual Employee BusinessEntity { get; set; }
        public virtual SalesTerritory Territory { get; set; }
    }
}
