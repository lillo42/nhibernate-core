// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace NHibernate.Benchmarks.Models.AdventureWorks
{
    public class TransactionHistoryArchive
    {
        public virtual int TransactionID { get; set; }
        public virtual decimal ActualCost { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual int ProductID { get; set; }
        public virtual int Quantity { get; set; }
        public virtual int ReferenceOrderID { get; set; }
        public virtual int ReferenceOrderLineID { get; set; }
        public virtual DateTime TransactionDate { get; set; }
        public virtual string TransactionType { get; set; }
    }
}
