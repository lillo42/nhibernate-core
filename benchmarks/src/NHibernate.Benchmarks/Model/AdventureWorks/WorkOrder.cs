// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace NHibernate.Benchmarks.Models.AdventureWorks
{
    public class WorkOrder
    {
        public WorkOrder()
        {
            WorkOrderRouting = new HashSet<WorkOrderRouting>();
        }

        public virtual int WorkOrderID { get; set; }
        public virtual DateTime DueDate { get; set; }
        public virtual DateTime? EndDate { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual int OrderQty { get; set; }
        public virtual int ProductID { get; set; }
        public virtual short ScrappedQty { get; set; }
        public virtual short? ScrapReasonID { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual int StockedQty { get; set; }

        public virtual ICollection<WorkOrderRouting> WorkOrderRouting { get; set; }
        public virtual Product Product { get; set; }
        public virtual ScrapReason ScrapReason { get; set; }
    }
}
