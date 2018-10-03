// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace NHibernate.Benchmarks.Models.AdventureWorks
{
    public class SalesReason
    {
        public SalesReason()
        {
            SalesOrderHeaderSalesReason = new HashSet<SalesOrderHeaderSalesReason>();
        }

        public virtual int SalesReasonID { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual string Name { get; set; }
        public virtual string ReasonType { get; set; }

        public virtual ICollection<SalesOrderHeaderSalesReason> SalesOrderHeaderSalesReason { get; set; }
    }
}
