// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace NHibernate.Benchmarks.Models.AdventureWorks
{
    public class CurrencyRate
    {
        public CurrencyRate()
        {
            SalesOrderHeader = new HashSet<SalesOrderHeader>();
        }

        public virtual int CurrencyRateID { get; set; }
        public virtual decimal AverageRate { get; set; }
        public virtual DateTime CurrencyRateDate { get; set; }
        public virtual decimal EndOfDayRate { get; set; }
        public virtual string FromCurrencyCode { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual string ToCurrencyCode { get; set; }

        public virtual ICollection<SalesOrderHeader> SalesOrderHeader { get; set; }
        public virtual Currency FromCurrencyCodeNavigation { get; set; }
        public virtual Currency ToCurrencyCodeNavigation { get; set; }
    }
}
