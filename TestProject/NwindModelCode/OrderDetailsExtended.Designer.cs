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
    public partial class OrderDetailsExtended : XPLiteObject
    {
        int fOrderid;
        [Persistent(@"OrderID")]
        public int Orderid
        {
            get { return fOrderid; }
            set { SetPropertyValue<int>(nameof(Orderid), ref fOrderid, value); }
        }
        int fProductid;
        [Persistent(@"ProductID")]
        public int Productid
        {
            get { return fProductid; }
            set { SetPropertyValue<int>(nameof(Productid), ref fProductid, value); }
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
        decimal fUnitprice;
        [Persistent(@"UnitPrice")]
        public decimal Unitprice
        {
            get { return fUnitprice; }
            set { SetPropertyValue<decimal>(nameof(Unitprice), ref fUnitprice, value); }
        }
        short fQuantity;
        public short Quantity
        {
            get { return fQuantity; }
            set { SetPropertyValue<short>(nameof(Quantity), ref fQuantity, value); }
        }
        float fDiscount;
        public float Discount
        {
            get { return fDiscount; }
            set { SetPropertyValue<float>(nameof(Discount), ref fDiscount, value); }
        }
        decimal? fExtendedprice;
        [Persistent(@"ExtendedPrice")]
        public decimal? Extendedprice
        {
            get { return fExtendedprice; }
            set { SetPropertyValue<decimal?>(nameof(Extendedprice), ref fExtendedprice, value); }
        }
    }

}
