// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace NHibernate.Benchmarks.Models.AdventureWorks
{
    public class ProductInventory
    {
        public virtual int ProductID { get; set; }
        public virtual short LocationID { get; set; }
        public virtual byte Bin { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual short Quantity { get; set; }
#pragma warning disable IDE1006 // Naming Styles
        public virtual Guid rowguid { get; set; }
#pragma warning restore IDE1006 // Naming Styles
        public virtual string Shelf { get; set; }

        public virtual Location Location { get; set; }
        public virtual Product Product { get; set; }
    }
}
