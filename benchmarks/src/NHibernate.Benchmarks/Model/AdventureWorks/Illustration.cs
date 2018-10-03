// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace NHibernate.Benchmarks.Models.AdventureWorks
{
    public class Illustration
    {
        public Illustration()
        {
            ProductModelIllustration = new HashSet<ProductModelIllustration>();
        }

        public virtual int IllustrationID { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual string Diagram { get; set; }

        public virtual ICollection<ProductModelIllustration> ProductModelIllustration { get; set; }
    }
}
