// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace NHibernate.Benchmarks.Models.AdventureWorks
{
    public class CreditCard
    {
        public CreditCard()
        {
            PersonCreditCard = new HashSet<PersonCreditCard>();
            SalesOrderHeader = new HashSet<SalesOrderHeader>();
        }

		public virtual int CreditCardID { get; set; }
		public virtual string CardNumber { get; set; }
		public virtual string CardType { get; set; }
		public virtual byte ExpMonth { get; set; }
		public virtual short ExpYear { get; set; }
		public virtual DateTime ModifiedDate { get; set; }

        public virtual ICollection<PersonCreditCard> PersonCreditCard { get; set; }
        public virtual ICollection<SalesOrderHeader> SalesOrderHeader { get; set; }
    }
}
