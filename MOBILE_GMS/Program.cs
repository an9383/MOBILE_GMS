using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace mobile_gms
{
    /**
     * 실서버 올릴때 
         */

    //public class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        /*
    //         (실 서버에서 실행) 컨솔 창
    //         c:>dotnet run --hosturl http://서버아이피:서버포트
    //         */

    //        var configuration = new ConfigurationBuilder()
    //            .AddCommandLine(args)
    //            .Build();
    //        var hostUrl = configuration["hosturl"];
    //        if (string.IsNullOrEmpty(hostUrl))
    //        {
    //            hostUrl = "http://0.0.0.0:8090";
    //        }

    //        var host = new WebHostBuilder()
    //            .UseKestrel()
    //            .UseUrls(hostUrl)   // <!-- this 
    //            .UseContentRoot(Directory.GetCurrentDirectory())
    //            .UseIISIntegration()
    //            .UseStartup<Startup>()
    //            .UseConfiguration(configuration)
    //            .Build();

    //        host.Run();

    //    }  

    //}

        /**
         로컬에서 개발 할때 
         */
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }










}
