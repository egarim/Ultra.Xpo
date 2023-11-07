using DevExpress.Utils;
using DevExpress.Xpo;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using TestProject.NWind;

namespace TestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
           

        }

        [Test]
        public void Test1()
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)

            .Build();

            var Ds=  ConnectionHelper.GetConnectionProvider(configuration,DevExpress.Xpo.DB.AutoCreateOption.SchemaAlreadyExists);

            SimpleDataLayer simpleDataLayer = new SimpleDataLayer(Ds);
            UnitOfWork unitOfWork = new UnitOfWork(simpleDataLayer);

             var View=  typeof(Orders).CreateViewWithProperties(unitOfWork, null);
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
    }
}