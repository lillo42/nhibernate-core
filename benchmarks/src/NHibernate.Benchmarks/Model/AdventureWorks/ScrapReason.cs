// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace NHibernate.Benchmarks.Models.AdventureWorks
{
    public class ScrapReason
    {
        public ScrapReason()
        {
            WorkOrder = new HashSet<WorkOrder>();
        }

        public virtual short ScrapReasonID { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual string Name { get; set; }

        public virtual ICollection<WorkOrder> WorkOrder { get; set; }
    }
}
