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

    public partial class Shippers : XPLiteObject
    {
        int fShipperid;
        [Key(true)]
        [Persistent(@"ShipperID")]
        public int Shipperid
        {
            get { return fShipperid; }
            set { SetPropertyValue<int>(nameof(Shipperid), ref fShipperid, value); }
        }
        string fCompanyname;
        [Size(40)]
        [Persistent(@"CompanyName")]
        [Nullable(false)]
        public string Companyname
        {
            get { return fCompanyname; }
            set { SetPropertyValue<string>(nameof(Companyname), ref fCompanyname, value); }
        }
        string fPhone;
        [Size(24)]
        public string Phone
        {
            get { return fPhone; }
            set { SetPropertyValue<string>(nameof(Phone), ref fPhone, value); }
        }
        [Association(@"OrdersReferencesShippers")]
        public XPCollection<Orders> OrdersCollection { get { return GetCollection<Orders>(nameof(OrdersCollection)); } }
    }

}
