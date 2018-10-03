// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace NHibernate.Benchmarks.Models.AdventureWorks
{
    public class WorkOrderRouting
    {
        public virtual int WorkOrderID { get; set; }
        public virtual int ProductID { get; set; }
        public virtual short OperationSequence { get; set; }
        public virtual decimal? ActualCost { get; set; }
        public virtual DateTime? ActualEndDate { get; set; }
        public virtual decimal? ActualResourceHrs { get; set; }
        public virtual DateTime? ActualStartDate { get; set; }
        public virtual short LocationID { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual decimal PlannedCost { get; set; }
        public virtual DateTime ScheduledEndDate { get; set; }
        public virtual DateTime ScheduledStartDate { get; set; }

        public virtual Location Location { get; set; }
        public virtual WorkOrder WorkOrder { get; set; }
    }
}
