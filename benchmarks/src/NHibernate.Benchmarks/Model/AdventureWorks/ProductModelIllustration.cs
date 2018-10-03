// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace NHibernate.Benchmarks.Models.AdventureWorks
{
    public class ProductModelIllustration
    {
        public virtual int ProductModelID { get; set; }
        public virtual int IllustrationID { get; set; }
        public virtual DateTime ModifiedDate { get; set; }

        public virtual Illustration Illustration { get; set; }
        public virtual ProductModel ProductModel { get; set; }
    }
}
