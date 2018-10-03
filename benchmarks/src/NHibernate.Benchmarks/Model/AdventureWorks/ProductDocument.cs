// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace NHibernate.Benchmarks.Models.AdventureWorks
{
    public class ProductDocument
    {
        public virtual int ProductID { get; set; }
        public virtual int DocumentNode { get; set; }
        public virtual DateTime ModifiedDate { get; set; }

        public virtual Product Product { get; set; }
    }
}
