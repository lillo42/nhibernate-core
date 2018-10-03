// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace NHibernate.Benchmarks.Models.AdventureWorks
{
    public class Product
    {
        public Product()
        {
            BillOfMaterials = new HashSet<BillOfMaterials>();
            BillOfMaterialsNavigation = new HashSet<BillOfMaterials>();
            ProductCostHistory = new HashSet<ProductCostHistory>();
            ProductDocument = new HashSet<ProductDocument>();
            ProductInventory = new HashSet<ProductInventory>();
            ProductListPriceHistory = new HashSet<ProductListPriceHistory>();
            ProductProductPhoto = new HashSet<ProductProductPhoto>();
            ProductReview = new HashSet<ProductReview>();
            ProductVendor = new HashSet<ProductVendor>();
            PurchaseOrderDetail = new HashSet<PurchaseOrderDetail>();
            ShoppingCartItem = new HashSet<ShoppingCartItem>();
            SpecialOfferProduct = new HashSet<SpecialOfferProduct>();
            TransactionHistory = new HashSet<TransactionHistory>();
            WorkOrder = new HashSet<WorkOrder>();
        }

        public virtual int ProductID { get; set; }
        public virtual string Class { get; set; }
        public virtual string Color { get; set; }
        public virtual int DaysToManufacture { get; set; }
        public virtual DateTime? DiscontinuedDate { get; set; }
        public virtual bool FinishedGoodsFlag { get; set; }
        public virtual decimal ListPrice { get; set; }
        public virtual bool MakeFlag { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual string Name { get; set; }
        public virtual string ProductLine { get; set; }
        public virtual int? ProductModelID { get; set; }
        public virtual string ProductNumber { get; set; }
        public virtual int? ProductSubcategoryID { get; set; }
        public virtual short ReorderPoint { get; set; }
#pragma warning disable IDE1006 // Naming Styles
        public virtual Guid rowguid { get; set; }
#pragma warning restore IDE1006 // Naming Styles
        public virtual short SafetyStockLevel { get; set; }
        public virtual DateTime? SellEndDate { get; set; }
        public virtual DateTime SellStartDate { get; set; }
        public virtual string Size { get; set; }
        public virtual string SizeUnitMeasureCode { get; set; }
        public virtual decimal StandardCost { get; set; }
        public virtual string Style { get; set; }
        public virtual decimal? Weight { get; set; }
        public virtual string WeightUnitMeasureCode { get; set; }

        public virtual ICollection<BillOfMaterials> BillOfMaterials { get; set; }
        public virtual ICollection<BillOfMaterials> BillOfMaterialsNavigation { get; set; }
        public virtual ICollection<ProductCostHistory> ProductCostHistory { get; set; }
        public virtual ICollection<ProductDocument> ProductDocument { get; set; }
        public virtual ICollection<ProductInventory> ProductInventory { get; set; }
        public virtual ICollection<ProductListPriceHistory> ProductListPriceHistory { get; set; }
        public virtual ICollection<ProductProductPhoto> ProductProductPhoto { get; set; }
        public virtual ICollection<ProductReview> ProductReview { get; set; }
        public virtual ICollection<ProductVendor> ProductVendor { get; set; }
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }
        public virtual ICollection<ShoppingCartItem> ShoppingCartItem { get; set; }
        public virtual ICollection<SpecialOfferProduct> SpecialOfferProduct { get; set; }
        public virtual ICollection<TransactionHistory> TransactionHistory { get; set; }
        public virtual ICollection<WorkOrder> WorkOrder { get; set; }
        public virtual ProductModel ProductModel { get; set; }
        public virtual ProductSubcategory ProductSubcategory { get; set; }
        public virtual UnitMeasure SizeUnitMeasureCodeNavigation { get; set; }
        public virtual UnitMeasure WeightUnitMeasureCodeNavigation { get; set; }
    }
}
