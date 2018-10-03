// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace NHibernate.Benchmarks.Models.AdventureWorks
{
    public class SalesOrderHeader
    {
        public SalesOrderHeader()
        {
            SalesOrderDetail = new HashSet<SalesOrderDetail>();
            SalesOrderHeaderSalesReason = new HashSet<SalesOrderHeaderSalesReason>();
        }

        public virtual int SalesOrderID { get; set; }
        public virtual string AccountNumber { get; set; }
        public virtual int BillToAddressID { get; set; }
        public virtual string Comment { get; set; }
        public virtual string CreditCardApprovalCode { get; set; }
        public virtual int? CreditCardID { get; set; }
        public virtual int? CurrencyRateID { get; set; }
        public virtual int CustomerID { get; set; }
        public virtual DateTime DueDate { get; set; }
        public virtual decimal Freight { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual bool OnlineOrderFlag { get; set; }
        public virtual DateTime OrderDate { get; set; }
        public virtual string PurchaseOrderNumber { get; set; }
        public virtual byte RevisionNumber { get; set; }
#pragma warning disable IDE1006 // Naming Styles
        public virtual Guid rowguid { get; set; }
#pragma warning restore IDE1006 // Naming Styles
        public virtual string SalesOrderNumber { get; set; }
        public virtual int? SalesPersonID { get; set; }
        public virtual DateTime? ShipDate { get; set; }
        public virtual int ShipMethodID { get; set; }
        public virtual int ShipToAddressID { get; set; }
        public virtual byte Status { get; set; }
        public virtual decimal SubTotal { get; set; }
        public virtual decimal TaxAmt { get; set; }
        public virtual int? TerritoryID { get; set; }
        public virtual decimal TotalDue { get; set; }

        public virtual ICollection<SalesOrderDetail> SalesOrderDetail { get; set; }
        public virtual ICollection<SalesOrderHeaderSalesReason> SalesOrderHeaderSalesReason { get; set; }
        public virtual Address BillToAddress { get; set; }
        public virtual CreditCard CreditCard { get; set; }
        public virtual CurrencyRate CurrencyRate { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual SalesPerson SalesPerson { get; set; }
        public virtual ShipMethod ShipMethod { get; set; }
        public virtual Address ShipToAddress { get; set; }
        public virtual SalesTerritory Territory { get; set; }
    }
}
