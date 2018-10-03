// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace NHibernate.Benchmarks.Models.Orders
{
    public class Customer
    {
        public virtual int CustomerId { get; set; }
        public virtual string Title { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual DateTime? DateOfBirth { get; set; }
        public virtual bool IsLoyaltyMember { get; set; }
        public virtual DateTime Joined { get; set; }
        public virtual bool OptedOutOfMarketing { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Email { get; set; }

        public virtual string AddressLineOne { get; set; }
        public virtual string AddressLineTwo { get; set; }
        public virtual string City { get; set; }
        public virtual string StateOrProvince { get; set; }
        public virtual string ZipOrPostalCode { get; set; }
        public virtual string Country { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
