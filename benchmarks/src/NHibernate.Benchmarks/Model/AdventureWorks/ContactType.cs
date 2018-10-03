// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace NHibernate.Benchmarks.Models.AdventureWorks
{
    public class ContactType
    {
        public ContactType()
        {
            BusinessEntityContact = new HashSet<BusinessEntityContact>();
        }

		public virtual int ContactTypeID { get; set; }
		public virtual DateTime ModifiedDate { get; set; }
		public virtual string Name { get; set; }

        public virtual ICollection<BusinessEntityContact> BusinessEntityContact { get; set; }
    }
}
