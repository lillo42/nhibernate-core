// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace NHibernate.Benchmarks.Models.AdventureWorks
{
    public class ProductModelProductDescriptionCulture
    {
        public virtual int ProductModelID { get; set; }
        public virtual int ProductDescriptionID { get; set; }
        public virtual string CultureID { get; set; }
        public virtual DateTime ModifiedDate { get; set; }

        public virtual Culture Culture { get; set; }
        public virtual ProductDescription ProductDescription { get; set; }
        public virtual ProductModel ProductModel { get; set; }
    }
}
