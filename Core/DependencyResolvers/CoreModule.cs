using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();//arkada hazir bir ICacheManager instance,Cache vs olaylarin instancesiyle ugrasmamak icin kolaylastirilmis.  
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();//uygulama seviyesinde servis bagimliliklarini cozumleyecegimiz yer
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
        }
    }
}
