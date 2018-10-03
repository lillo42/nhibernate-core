// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace NHibernate.Benchmarks.Models.AdventureWorks
{
    public class PersonCreditCard
    {
        public virtual int BusinessEntityID { get; set; }
        public virtual int CreditCardID { get; set; }
        public virtual DateTime ModifiedDate { get; set; }

        public virtual Person BusinessEntity { get; set; }
        public virtual CreditCard CreditCard { get; set; }
    }
}
