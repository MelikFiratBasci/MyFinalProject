using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    public interface ICoreModule//core gordugun zaman framework katmani oldugunu anlayabilirsin
    {
        void Load(IServiceCollection serviceCollection);//genel bagimliliklari yukleyecek metodun imzasi
    }
}
