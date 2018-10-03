// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace NHibernate.Benchmarks.Models.AdventureWorks
{
    public class Address
    {
        public Address()
        {
            BusinessEntityAddress = new HashSet<BusinessEntityAddress>();
            SalesOrderHeader = new HashSet<SalesOrderHeader>();
            SalesOrderHeaderNavigation = new HashSet<SalesOrderHeader>();
        }

        public virtual int AddressID { get; set; }
        public virtual string AddressLine1 { get; set; }
        public virtual string AddressLine2 { get; set; }
        public virtual string City { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual string PostalCode { get; set; }
#pragma warning disable IDE1006 // Naming Styles
        public virtual Guid rowguid { get; set; } 
#pragma warning restore IDE1006 // Naming Styles
        public virtual int StateProvinceID { get; set; }

        public virtual ICollection<BusinessEntityAddress> BusinessEntityAddress { get; set; }
        public virtual ICollection<SalesOrderHeader> SalesOrderHeader { get; set; }
        public virtual ICollection<SalesOrderHeader> SalesOrderHeaderNavigation { get; set; }
        public virtual StateProvince StateProvince { get; set; }
    }
}
