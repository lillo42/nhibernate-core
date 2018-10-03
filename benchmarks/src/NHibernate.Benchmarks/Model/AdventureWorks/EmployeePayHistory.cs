// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace NHibernate.Benchmarks.Models.AdventureWorks
{
    public class EmployeePayHistory
    {
        public virtual int BusinessEntityID { get; set; }
        public virtual DateTime RateChangeDate { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual byte PayFrequency { get; set; }
        public virtual decimal Rate { get; set; }

        public virtual Employee BusinessEntity { get; set; }
    }
}
