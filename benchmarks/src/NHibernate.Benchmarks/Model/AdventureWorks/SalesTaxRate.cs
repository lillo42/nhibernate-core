// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace NHibernate.Benchmarks.Models.AdventureWorks
{
    public class SalesTaxRate
    {
        public virtual int SalesTaxRateID { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual string Name { get; set; }
#pragma warning disable IDE1006 // Naming Styles
        public virtual Guid rowguid { get; set; }
#pragma warning restore IDE1006 // Naming Styles
        public virtual int StateProvinceID { get; set; }
        public virtual decimal TaxRate { get; set; }
        public virtual byte TaxType { get; set; }

        public virtual StateProvince StateProvince { get; set; }
    }
}
