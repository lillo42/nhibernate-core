// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace NHibernate.Benchmarks.Models.AdventureWorks
{
    public class StateProvince
    {
        public StateProvince()
        {
            Address = new HashSet<Address>();
            SalesTaxRate = new HashSet<SalesTaxRate>();
        }

        public virtual int StateProvinceID { get; set; }
        public virtual string CountryRegionCode { get; set; }
        public virtual bool IsOnlyStateProvinceFlag { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual string Name { get; set; }
#pragma warning disable IDE1006 // Naming Styles
        public virtual Guid rowguid { get; set; }
#pragma warning restore IDE1006 // Naming Styles
        public virtual string StateProvinceCode { get; set; }
        public virtual int TerritoryID { get; set; }

        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<SalesTaxRate> SalesTaxRate { get; set; }
        public virtual CountryRegion CountryRegionCodeNavigation { get; set; }
        public virtual SalesTerritory Territory { get; set; }
    }
}
