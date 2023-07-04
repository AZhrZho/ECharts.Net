using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ECharts.Net.Webview2")]
namespace ECharts.Net
{
    public static class Config
    {
        static Config()
        {
            using var echartsEngineStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ECharts.Net.Resource.echarts_5.4.2.min.js");
            if (echartsEngineStream is null) throw new ApplicationException("cant find resource 'echarts_5.4.2.min.js'");
            using var reader = new StreamReader(echartsEngineStream);
            EChartsEngineScript = reader.ReadToEnd();
        }

        internal static string EChartsEngineScript { get; private set; }

        public static void SetEchartsEngineScript(string script)
        {
            EChartsEngineScript = script;
        }
    }
}
