﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace TestProject.NWind
{

    [NonPersistent]
    public partial class ProductSalesFor1997 : XPLiteObject
    {
        string fCategoryname;
        [Size(15)]
        [Persistent(@"CategoryName")]
        [Nullable(false)]
        public string Categoryname
        {
            get { return fCategoryname; }
            set { SetPropertyValue<string>(nameof(Categoryname), ref fCategoryname, value); }
        }
        string fProductname;
        [Size(40)]
        [Persistent(@"ProductName")]
        [Nullable(false)]
        public string Productname
        {
            get { return fProductname; }
            set { SetPropertyValue<string>(nameof(Productname), ref fProductname, value); }
        }
        decimal? fProductsales;
        [Persistent(@"ProductSales")]
        public decimal? Productsales
        {
            get { return fProductsales; }
            set { SetPropertyValue<decimal?>(nameof(Productsales), ref fProductsales, value); }
        }
    }

}