using DevExpress.Xpo;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.NWind;
using Ultra.Xpo.Loggers;

namespace TestProject
{
  
    public class XpoCommandGeneratorTest
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

            var View = typeof(Orders).CreateViewWithProperties(unitOfWork, null);

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
