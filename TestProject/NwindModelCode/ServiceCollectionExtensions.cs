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
using Microsoft.Extensions.Configuration;
using TestProject.NWind;
namespace TestProject.NWind
{
    public partial class NWindUnitOfWork : UnitOfWork
    {
        public NWindUnitOfWork() : base() { }
        public NWindUnitOfWork(DevExpress.Xpo.Metadata.XPDictionary dictionary) : base(dictionary) { }
        public NWindUnitOfWork(IDataLayer layer, params IDisposable[] disposeOnDisconnect) : base(layer, disposeOnDisconnect) { }
        public NWindUnitOfWork(IObjectLayer layer, params IDisposable[] disposeOnDisconnect) : base(layer, disposeOnDisconnect) { }
    }
}
namespace Microsoft.Extensions.DependencyInjection
{
    public static class NWindXpoServiceCollectionExtensions
    {
        public static IServiceCollection AddNWindAsXpoDefaultUnitOfWork(this IServiceCollection serviceCollection, bool useDataLayerAsSingletone = true, Action<DataLayerOptionsBuilder> customDataLayerOptionsBuilder = null)
        {
            Action<DataLayerOptionsBuilder> optionsBuilder = CreateDataLayerOptionsBuilder(customDataLayerOptionsBuilder);
            return serviceCollection.AddXpoDefaultUnitOfWork(useDataLayerAsSingletone, optionsBuilder);
        }
        public static IServiceCollection AddNWindAsXpoDefaultSession(this IServiceCollection serviceCollection, bool useDataLayerAsSingletone = true, Action<DataLayerOptionsBuilder> customDataLayerOptionsBuilder = null)
        {
            Action<DataLayerOptionsBuilder> optionsBuilder = CreateDataLayerOptionsBuilder(customDataLayerOptionsBuilder);
            return serviceCollection.AddXpoDefaultSession(useDataLayerAsSingletone, optionsBuilder);
        }
        public static IServiceCollection AddNWindUnitOfWork(this IServiceCollection serviceCollection, bool useDataLayerAsSingletone = true, Action<DataLayerOptionsBuilder> customDataLayerOptionsBuilder = null)
        {
            Action<DataLayerOptionsBuilder> optionsBuilder = CreateDataLayerOptionsBuilder(customDataLayerOptionsBuilder);
            return serviceCollection.AddXpoCustomSession<NWindUnitOfWork>(useDataLayerAsSingletone, optionsBuilder);
        }
        public static IServiceCollection AddNWindXpoDefaultDataLayer(this IServiceCollection serviceCollection, ServiceLifetime lifetime, Action<DataLayerOptionsBuilder> customDataLayerOptionsBuilder = null)
        {
            Action<DataLayerOptionsBuilder> optionsBuilder = CreateDataLayerOptionsBuilder(customDataLayerOptionsBuilder);
            return serviceCollection.AddXpoDefaultDataLayer(lifetime, customDataLayerOptionsBuilder);
        }
        public static IServiceCollection AddNWindAsXpoDefaultUnitOfWork(this IServiceCollection serviceCollection, IConfiguration configuration, bool useDataLayerAsSingletone = true, Action<DataLayerOptionsBuilder> customDataLayerOptionsBuilder = null)
        {
            Action<DataLayerOptionsBuilder> optionsBuilder = CreateDataLayerOptionsBuilder(customDataLayerOptionsBuilder);
            return serviceCollection.AddXpoDefaultUnitOfWork(useDataLayerAsSingletone, o => { o.UseConnectionStringForNWind(configuration); optionsBuilder(o); });
        }
        public static IServiceCollection AddNWindAsXpoDefaultSession(this IServiceCollection serviceCollection, IConfiguration configuration, bool useDataLayerAsSingletone = true, Action<DataLayerOptionsBuilder> customDataLayerOptionsBuilder = null)
        {
            Action<DataLayerOptionsBuilder> optionsBuilder = CreateDataLayerOptionsBuilder(customDataLayerOptionsBuilder);
            return serviceCollection.AddXpoDefaultSession(useDataLayerAsSingletone, o => { o.UseConnectionStringForNWind(configuration); optionsBuilder(o); });
        }
        public static IServiceCollection AddNWindUnitOfWork(this IServiceCollection serviceCollection, IConfiguration configuration, bool useDataLayerAsSingletone = true, Action<DataLayerOptionsBuilder> customDataLayerOptionsBuilder = null)
        {
            Action<DataLayerOptionsBuilder> optionsBuilder = CreateDataLayerOptionsBuilder(customDataLayerOptionsBuilder);
            return serviceCollection.AddXpoCustomSession<NWindUnitOfWork>(useDataLayerAsSingletone, o => { o.UseConnectionStringForNWind(configuration); optionsBuilder(o); });
        }
        public static IServiceCollection AddNWindXpoDefaultDataLayer(this IServiceCollection serviceCollection, IConfiguration configuration, ServiceLifetime lifetime, Action<DataLayerOptionsBuilder> customDataLayerOptionsBuilder = null)
        {
            Action<DataLayerOptionsBuilder> optionsBuilder = CreateDataLayerOptionsBuilder(customDataLayerOptionsBuilder);
            return serviceCollection.AddXpoDefaultDataLayer(lifetime, o => { o.UseConnectionStringForNWind(configuration); optionsBuilder(o); });
        }
        public static DataLayerOptionsBuilder UseConnectionStringForNWind(this DataLayerOptionsBuilder options, IConfiguration configuration)
        {
            return options.UseConnectionString(configuration.GetConnectionString(ConnectionHelper.ConnectionStringName));
        }
        static Action<DataLayerOptionsBuilder> CreateDataLayerOptionsBuilder(Action<DataLayerOptionsBuilder> injectCustomDataLayerOptionsBuilder)
        {
            return (options) =>
            {
                options
                .UseNullableBehavior(NullableBehavior.ByUnderlyingType)
                .UseEntityTypes(ConnectionHelper.GetPersistentTypes())
                .UseEntityTypes(ConnectionHelper.GetNonPersistentTypes());
                if (injectCustomDataLayerOptionsBuilder != null)
                {
                    injectCustomDataLayerOptionsBuilder(options);
                }
            };
        }
    }
}
