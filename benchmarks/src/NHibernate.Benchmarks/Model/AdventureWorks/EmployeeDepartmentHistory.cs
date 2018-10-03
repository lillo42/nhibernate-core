// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace NHibernate.Benchmarks.Models.AdventureWorks
{
    public class EmployeeDepartmentHistory
    {
        public virtual int BusinessEntityID { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual short DepartmentID { get; set; }
        public virtual byte ShiftID { get; set; }
        public virtual DateTime? EndDate { get; set; }
        public virtual DateTime ModifiedDate { get; set; }

        public virtual Employee BusinessEntity { get; set; }
        public virtual Department Department { get; set; }
        public virtual Shift Shift { get; set; }
    }
}
