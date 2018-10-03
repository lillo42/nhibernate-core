// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace NHibernate.Benchmarks.Models.AdventureWorks
{
    public class Location
    {
        public Location()
        {
            ProductInventory = new HashSet<ProductInventory>();
            WorkOrderRouting = new HashSet<WorkOrderRouting>();
        }

        public virtual short LocationID { get; set; }
        public virtual decimal Availability { get; set; }
        public virtual decimal CostRate { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual string Name { get; set; }

        public virtual ICollection<ProductInventory> ProductInventory { get; set; }
        public virtual ICollection<WorkOrderRouting> WorkOrderRouting { get; set; }
    }
}
