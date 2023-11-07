using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace TestProject.NWind
{

    public partial class Customercustomerdemo
    {
        public Customercustomerdemo(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
