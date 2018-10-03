// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace NHibernate.Benchmarks.Models.AdventureWorks
{
    public class ProductCategory
    {
        public ProductCategory()
        {
            ProductSubcategory = new HashSet<ProductSubcategory>();
        }

        public virtual int ProductCategoryID { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual string Name { get; set; }
#pragma warning disable IDE1006 // Naming Styles
        public virtual Guid rowguid { get; set; }
#pragma warning restore IDE1006 // Naming Styles

        public virtual ICollection<ProductSubcategory> ProductSubcategory { get; set; }
    }
}
