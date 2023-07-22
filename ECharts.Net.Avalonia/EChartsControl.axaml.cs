using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Xilium.CefGlue.Avalonia;

namespace ECharts.Net.Avalonia
{
    public partial class EChartsControl : UserControl
    {
        public EChartsControl()
        {
            InitializeComponent();
            AvaloniaXamlLoader.Load(this);
            var browserWrapper = this.FindControl<Decorator>("browserWrapper")!;
            browser = new ();
            browser.Address = "about:blank";
            browserWrapper.Child = browser;
        }

        private readonly AvaloniaCefBrowser browser;
    }
}
