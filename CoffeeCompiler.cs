using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Cache;
using System.Web;
using System.Web.Optimization;

namespace WebLife
{
    public class CoffeeCompiler : IBundleTransform
    {
        public void Process(BundleContext context, BundleResponse response)
        {
            var coffeeEngine = new CoffeeSharp.CoffeeScriptEngine();
            string compiledCoffeeScript = string.Empty;
            foreach (var file in response.Files)
            {
                string physicalPath = System.Web.Hosting.HostingEnvironment.MapPath(HttpContext.Current.Request.ApplicationPath);
                using (var reader = new StreamReader(physicalPath + file.VirtualFile.VirtualPath))//////////////////////////////////////////////////
                {
                    compiledCoffeeScript += coffeeEngine.Compile(reader.ReadToEnd());
                    reader.Close();
                }
            }
            response.Content = compiledCoffeeScript;
            response.ContentType = "text/javascript";
            response.Cacheability = HttpCacheability.Public;
        }
    }
}