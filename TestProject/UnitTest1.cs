using DevExpress.Data.Filtering;
using DevExpress.DirectX.Common;
using DevExpress.Utils;
using DevExpress.Xpo;
using DevExpress.Xpo.Logger;
using DevExpress.Xpo.Metadata;
using Microsoft.Extensions.Configuration;
using System.ComponentModel;
using System.Diagnostics;
using TestProject.NWind;
using Ultra.Xpo;
using Ultra.Xpo.Loggers;

namespace TestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {


        }

        [Test]
        public void CreateViewWithPropertiesTest()
        {


            // Registers your custom logger.
            DevExpress.Xpo.Logger.LogManager.SetTransport(new XpoFileLogger(nameof(CreateViewWithPropertiesTest) + ".txt"));


            IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)

            .Build();

            var Ds = ConnectionHelper.GetConnectionProvider(configuration, DevExpress.Xpo.DB.AutoCreateOption.SchemaAlreadyExists);

            SimpleDataLayer simpleDataLayer = new SimpleDataLayer(Ds);
            UnitOfWork unitOfWork = new UnitOfWork(simpleDataLayer);

            BinaryOperator binaryOperator = new BinaryOperator("Orderid", 11077);
            var View = typeof(Orders).CreateViewWithProperties(unitOfWork, binaryOperator);

            foreach (ViewRecord record in View)
            {
                foreach (ViewProperty property in View.Properties)
                {
                    object value = record[property.Name];
                    Debug.WriteLine($"{property.Name}: {value}");
                }
                Debug.WriteLine("-----------");
            }
            Assert.Pass();
        }
        [Test]
        public void CreateUltraViewWithPropertiesTest()
        {


            // Registers your custom logger.
            DevExpress.Xpo.Logger.LogManager.SetTransport(new XpoFileLogger(nameof(CreateViewWithPropertiesTest) + ".txt"));


            IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)

            .Build();

            var Ds = ConnectionHelper.GetConnectionProvider(configuration, DevExpress.Xpo.DB.AutoCreateOption.SchemaAlreadyExists);

            SimpleDataLayer simpleDataLayer = new SimpleDataLayer(Ds);
            UnitOfWork unitOfWork = new UnitOfWork(simpleDataLayer);

            BinaryOperator binaryOperator11077 = new BinaryOperator("Orderid", 11077);
            BinaryOperator binaryOperator9911077 = new BinaryOperator("Orderid", 9911077);


            var classInfo = unitOfWork.GetClassInfo(typeof(Orders));
            UltraXPView view11077 = CreateUltraView(unitOfWork, binaryOperator11077, classInfo);
            var Select = view11077.GenerateSelectStatement();

            UltraXPView view9911077 = CreateUltraView(unitOfWork, binaryOperator9911077, classInfo);
            var Select2 = view9911077.GenerateSelectStatement();

            var Data = Ds.SelectData(Select, Select2);
            var Record = new UltraViewRecord(view9911077, Data.ResultSet[0].Rows[0].Values);
            foreach (UltraViewProperty ultraViewProperty in view9911077.Properties)
            {
                var val=Record[ultraViewProperty.Name];
            }
            Assert.Pass();
        }

        private static UltraXPView CreateUltraView(UnitOfWork unitOfWork, BinaryOperator binaryOperator, XPClassInfo classInfo)
        {
            var view = new UltraXPView(unitOfWork, classInfo.ClassType);
            view.Criteria = binaryOperator;

            foreach (XPMemberInfo memberInfo in classInfo.Members)
            {
                if (!memberInfo.IsPersistent || memberInfo.IsCollection)
                    continue;

                if (memberInfo.ReferenceType != null)
                {
                    // Get key property of the associated object
                    XPClassInfo nestedClassInfo = memberInfo.ReferenceType;//session.GetClassInfo(memberInfo.ReferenceType);
                    XPMemberInfo keyProperty = nestedClassInfo.KeyProperty;

                    // Attempt to find a property marked with DefaultPropertyAttribute
                    var defaultPropertyAttribute = nestedClassInfo.FindAttributeInfo(typeof(DefaultPropertyAttribute)) as DefaultPropertyAttribute;

                    string defaultPropertyName = defaultPropertyAttribute != null ? defaultPropertyAttribute.Name : keyProperty.Name;

                    // Add key property of the associated object to the view
                    view.Properties.Add(new UltraViewProperty(memberInfo.Name + "." + keyProperty.Name, SortDirection.None, memberInfo.Name + "." + keyProperty.Name, false, true));

                    // If the default property is different from the key, add it as well
                    if (defaultPropertyAttribute != null && defaultPropertyName != keyProperty.Name)
                    {
                        view.Properties.Add(new UltraViewProperty(memberInfo.Name + "." + defaultPropertyName, SortDirection.None, memberInfo.Name + "." + defaultPropertyName, false, true));
                    }
                }
                else
                {
                    // Add the simple property to the view
                    view.Properties.Add(new UltraViewProperty(memberInfo.Name, SortDirection.None, memberInfo.Name, false, true));
                }
            }

            return view;
        }

        [Test]
        public void CreateModificationCommand()
        {

            // Registers your custom logger.
            DevExpress.Xpo.Logger.LogManager.SetTransport(new XpoFileLogger(nameof(CreateViewWithPropertiesTest) + ".txt"));

            IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)

            .Build();

            var Ds = ConnectionHelper.GetConnectionProvider(configuration, DevExpress.Xpo.DB.AutoCreateOption.SchemaAlreadyExists);

            SimpleDataLayer simpleDataLayer = new SimpleDataLayer(Ds);
            UnitOfWork unitOfWork = new UnitOfWork(simpleDataLayer);

            Dictionary<string,object> Data=new Dictionary<string, object>();

            //Data.Add("CategoryID", 10);
            Data.Add("CategoryName", "Test");
            Data.Add("Description", "Test");
            var Command=   XpoCommandGenerator.GenerateModificationCommand<Categories>(unitOfWork, Data);
            var Result=Ds.ModifyData(Command);
        }

    }
}