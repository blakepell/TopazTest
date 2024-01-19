using System.Windows;
using Tenray.Topaz;

namespace TopazTest
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            // Set a static variable on TerminalScriptCommands so methods there
            // can call back to this window.
            TerminalScriptCommands.Window = this;
        }

        private async void ButtonRunScript_Click(object sender, RoutedEventArgs e)
        {
            var engine = new TopazEngine();
            engine.AddType(typeof(TerminalScriptCommands), "Terminal");
            await engine.ExecuteScriptAsync(@"
            for (var i = 0; i < 10; i++)
            {
                Terminal.Echo(""say "" + i)
                await Terminal.Pause(1000)
            }");
        }
    }
}