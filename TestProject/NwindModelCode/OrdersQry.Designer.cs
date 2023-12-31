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
    public partial class OrdersQry : XPLiteObject
    {
        int fOrderid;
        [Persistent(@"OrderID")]
        public int Orderid
        {
            get { return fOrderid; }
            set { SetPropertyValue<int>(nameof(Orderid), ref fOrderid, value); }
        }
        string fCustomerid;
        [Size(5)]
        [Persistent(@"CustomerID")]
        public string Customerid
        {
            get { return fCustomerid; }
            set { SetPropertyValue<string>(nameof(Customerid), ref fCustomerid, value); }
        }
        int? fEmployeeid;
        [Persistent(@"EmployeeID")]
        public int? Employeeid
        {
            get { return fEmployeeid; }
            set { SetPropertyValue<int?>(nameof(Employeeid), ref fEmployeeid, value); }
        }
        DateTime? fOrderdate;
        [Persistent(@"OrderDate")]
        public DateTime? Orderdate
        {
            get { return fOrderdate; }
            set { SetPropertyValue<DateTime?>(nameof(Orderdate), ref fOrderdate, value); }
        }
        DateTime? fRequireddate;
        [Persistent(@"RequiredDate")]
        public DateTime? Requireddate
        {
            get { return fRequireddate; }
            set { SetPropertyValue<DateTime?>(nameof(Requireddate), ref fRequireddate, value); }
        }
        DateTime? fShippeddate;
        [Persistent(@"ShippedDate")]
        public DateTime? Shippeddate
        {
            get { return fShippeddate; }
            set { SetPropertyValue<DateTime?>(nameof(Shippeddate), ref fShippeddate, value); }
        }
        int? fShipvia;
        [Persistent(@"ShipVia")]
        public int? Shipvia
        {
            get { return fShipvia; }
            set { SetPropertyValue<int?>(nameof(Shipvia), ref fShipvia, value); }
        }
        decimal? fFreight;
        public decimal? Freight
        {
            get { return fFreight; }
            set { SetPropertyValue<decimal?>(nameof(Freight), ref fFreight, value); }
        }
        string fShipname;
        [Size(40)]
        [Persistent(@"ShipName")]
        public string Shipname
        {
            get { return fShipname; }
            set { SetPropertyValue<string>(nameof(Shipname), ref fShipname, value); }
        }
        string fShipaddress;
        [Size(60)]
        [Persistent(@"ShipAddress")]
        public string Shipaddress
        {
            get { return fShipaddress; }
            set { SetPropertyValue<string>(nameof(Shipaddress), ref fShipaddress, value); }
        }
        string fShipcity;
        [Size(15)]
        [Persistent(@"ShipCity")]
        public string Shipcity
        {
            get { return fShipcity; }
            set { SetPropertyValue<string>(nameof(Shipcity), ref fShipcity, value); }
        }
        string fShipregion;
        [Size(15)]
        [Persistent(@"ShipRegion")]
        public string Shipregion
        {
            get { return fShipregion; }
            set { SetPropertyValue<string>(nameof(Shipregion), ref fShipregion, value); }
        }
        string fShippostalcode;
        [Size(10)]
        [Persistent(@"ShipPostalCode")]
        public string Shippostalcode
        {
            get { return fShippostalcode; }
            set { SetPropertyValue<string>(nameof(Shippostalcode), ref fShippostalcode, value); }
        }
        string fShipcountry;
        [Size(15)]
        [Persistent(@"ShipCountry")]
        public string Shipcountry
        {
            get { return fShipcountry; }
            set { SetPropertyValue<string>(nameof(Shipcountry), ref fShipcountry, value); }
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
        string fAddress;
        [Size(60)]
        public string Address
        {
            get { return fAddress; }
            set { SetPropertyValue<string>(nameof(Address), ref fAddress, value); }
        }
        string fCity;
        [Size(15)]
        public string City
        {
            get { return fCity; }
            set { SetPropertyValue<string>(nameof(City), ref fCity, value); }
        }
        string fRegion;
        [Size(15)]
        public string Region
        {
            get { return fRegion; }
            set { SetPropertyValue<string>(nameof(Region), ref fRegion, value); }
        }
        string fPostalcode;
        [Size(10)]
        [Persistent(@"PostalCode")]
        public string Postalcode
        {
            get { return fPostalcode; }
            set { SetPropertyValue<string>(nameof(Postalcode), ref fPostalcode, value); }
        }
        string fCountry;
        [Size(15)]
        public string Country
        {
            get { return fCountry; }
            set { SetPropertyValue<string>(nameof(Country), ref fCountry, value); }
        }
    }

}
