using System;
using System.Windows.Forms;
using GraphicsViewer.Core;
using GraphicsViewer.Core.Input;
using GraphicsViewer.Core.Rendering;
using Microsoft.Extensions.DependencyInjection;

namespace GraphicsViewer
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();

            ConfigureServices(services);

            using (var serviceProvider = services.BuildServiceProvider())
            {
                var form1 = serviceProvider.GetRequiredService<GraphicsViewerForm>();
                var presenter = serviceProvider.GetRequiredService<IGraphicsPresenter>();
                presenter.SetView(form1);

                Application.Run(form1);
            }
        }

        static void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<GraphicsViewerForm>();
            services.AddScoped<IGraphicsPresenter, GraphicsPresenter>();
            services.AddScoped<IInputProcessor, InputProcessor>();
            services.AddScoped<IGraphicsRenderer, GraphicsRenderer>();
        }
    }
}
