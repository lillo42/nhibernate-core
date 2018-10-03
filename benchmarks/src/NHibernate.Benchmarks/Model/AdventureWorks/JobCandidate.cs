// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace NHibernate.Benchmarks.Models.AdventureWorks
{
    public class JobCandidate
    {
        public virtual int JobCandidateID { get; set; }
        public virtual int? BusinessEntityID { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual string Resume { get; set; }

        public virtual Employee BusinessEntity { get; set; }
    }
}
