using CommunityToolkit.Maui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ChainSpy.Extensions
{
    public static class AppBuilderExtensions
    {
        public static MauiAppBuilder UseDatabaseContext<T1,T2>(this MauiAppBuilder builder) where T1  : class where T2 : class
        {
            builder.Services.AddSingleton(typeof(T1), typeof(T2)); 

            

            return builder;
        }
    }
}
