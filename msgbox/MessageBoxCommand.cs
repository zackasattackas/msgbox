using System;
using System.Reflection;
using System.Windows.Forms;
using JetBrains.Annotations;
using McMaster.Extensions.CommandLineUtils;

namespace msgbox
{
    [Command("msgbox", Description = "Displays a message box to current user.", ExtendedHelpText = "\r\nThe dialog result is returned as the process exit code.\r\nRun msgbox --error-codes to see a list of possible return values.")]
    [VersionOptionFromMember("--version", MemberName = nameof(GetVersion))]    
    internal class MessageBoxCommand
    {
        [Option("-t|--text", "The text to display in the message box.", CommandOptionType.SingleValue)]
        public string Text { get; set; }

        [Option("-c|--caption", "The text to display in the title bar of the message box.", CommandOptionType.SingleValue)]
        public string Caption { get; set; }

        [Option("-b|--buttons", "The buttons to display in the message box.", CommandOptionType.SingleValue)]
        public MessageBoxButtons Buttons { get; set; }

        [Option("-i|--icon", "The icon to display in the message box.", CommandOptionType.SingleValue)]
        public MessageBoxIcon Icon { get; set; }

        [Option("-d|--default-btn", "Specifies the default button for the message box.", CommandOptionType.SingleValue)]
        public MessageBoxDefaultButton DefaultButton { get; set; }

        [Option("-a|--help-btn", "Shows the help button in the message box.", CommandOptionType.NoValue)]
        public bool ShowHelpButton { get; set; }

        [Option("--error-codes", CommandOptionType.NoValue, ShowInHelpText = false)]
        public bool ErrorCodes { get; set; }

        [UsedImplicitly]
        public int OnExecute(CommandLineApplication app)
        {
            if (!ErrorCodes)
                return (int) MessageBox.Show(Text, Caption, Buttons, Icon, DefaultButton, 0, ShowHelpButton);

            return ShowErrorCodes();
        }

        private static string GetVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version?.ToString();
        }

        private static int ShowErrorCodes()
        {
            Console.Error.WriteLine("The following error codes are supported.\r\n");
            foreach (var item in Enum.GetNames(typeof(DialogResult)))
                Console.Error.WriteLine($"    {item,-8} = {(int)Enum.Parse(typeof(DialogResult), item)}");

            return 0;
        }
    }
}