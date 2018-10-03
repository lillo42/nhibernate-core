// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace NHibernate.Benchmarks.Models.AdventureWorks
{
    public class Person
    {
        public Person()
        {
            BusinessEntityContact = new HashSet<BusinessEntityContact>();
            Customer = new HashSet<Customer>();
            EmailAddress = new HashSet<EmailAddress>();
            PersonCreditCard = new HashSet<PersonCreditCard>();
            PersonPhone = new HashSet<PersonPhone>();
        }

        public virtual int BusinessEntityID { get; set; }
        public virtual int EmailPromotion { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual bool NameStyle { get; set; }
        public virtual string PersonType { get; set; }
#pragma warning disable IDE1006 // Naming Styles
        public virtual Guid rowguid { get; set; }
#pragma warning restore IDE1006 // Naming Styles
        public virtual string Suffix { get; set; }
        public virtual string Title { get; set; }
        public virtual string AdditionalContactInfo { get; set; }
        public virtual string Demographics { get; set; }

        public virtual ICollection<BusinessEntityContact> BusinessEntityContact { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<EmailAddress> EmailAddress { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Password Password { get; set; }
        public virtual ICollection<PersonCreditCard> PersonCreditCard { get; set; }
        public virtual ICollection<PersonPhone> PersonPhone { get; set; }
        public virtual BusinessEntity BusinessEntity { get; set; }
    }
}
