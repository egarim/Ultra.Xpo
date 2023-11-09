using DevExpress.Data.Filtering;
using DevExpress.Utils;
using DevExpress.Xpo;
using DevExpress.Xpo.Logger;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using TestProject.NWind;
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