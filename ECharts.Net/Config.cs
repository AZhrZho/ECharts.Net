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
            EChartsContainerId = "root";
            EChartsContainerHtml =
                """
                <!DOCTYPE html>
                <html>
                <head>
                    <style>
                        * {
                            margin:0;
                            padding:0;
                        }
                            html,body {
                            height:100%;
                            overflow: hidden;
                        }
                        .box {
                            height:100%;
                        }
                    </style>
                </head>
                <body>
                    <div id="root" class="box"></div>
                </body>
                </html>
                """;
        }

        internal static string EChartsEngineScript { get; private set; }
        internal static string EChartsContainerHtml { get; private set; }
        internal static string EChartsContainerId { get; private set; }

        public static void SetEchartsEngineScript(string script)
        {
            EChartsEngineScript = script;
        }

        public static void SetEchartsContainerHtml(string html, string containerElementId)
        {
            EChartsContainerHtml = html;
            EChartsContainerId = containerElementId;
        }
    }
}
