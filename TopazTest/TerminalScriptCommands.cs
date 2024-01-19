using System.Windows;
using System.Windows.Threading;

namespace TopazTest
{
    public static class TerminalScriptCommands
    {
        public static MainWindow Window;

        public static void Echo(string? text)
        {
            Window.TextOutput.AppendText($"{text}\r\n");
        }

        public static void Pause(int milliseconds)
        {
            DispatcherFrame df = new DispatcherFrame();

            new Thread(() =>
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(milliseconds));
                df.Continue = false;

            }).Start();

            Dispatcher.PushFrame(df);
        }
    }
}
