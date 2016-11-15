using System;
using System.Threading.Tasks;
using Prism;
using Prism.IO;
using Prism.UI;
using Prism.UI.Controls;
using SampleSuite.Resources;

namespace SampleSuite
{
    [View]
    [PreferredPanes(Panes.Detail)]
    public class ReadWriteSampleView : BaseSampleView<ReadWriteSampleModel>
    {
        public override async Task ConfigureUIAsync()
        {
            await base.ConfigureUIAsync();

            var textArea = new TextArea()
            {
                Text = Model.InitialText,
                VerticalAlignment = VerticalAlignment.Stretch
            };

            var panel = Content as Panel;
            if (panel != null)
            {
                panel.Children.Add(textArea);
            };

            var readButton = new MenuButton()
            {
                Title = "Read",
                IsEnabled = Model.FileExists,
                Action = async (button) => textArea.Text = await File.ReadAllTextAsync(Model.FileName)
            };

            var writeButton = new MenuButton()
            {
                Title = "Write",
                IsEnabled = Model.FileExists,
                Action = async (button) =>
                {
                    Alert resultAlert = null;
                    try
                    {
                        await File.WriteAllTextAsync(Model.FileName, textArea.Text);
                        readButton.IsEnabled = true;
                        resultAlert = new Alert(Strings.FileWrittenSuccessfully, string.Empty);
                    }
                    catch (Exception e)
                    {
                        resultAlert = new Alert(e.Message, Strings.IOWriteError);
                    }

                    resultAlert.AddButton(new AlertButton(Strings.OK));
                    resultAlert.Show();
                }
            };            

            Menu = new ActionMenu()
            {
                MaxDisplayItems = 2,
                Items = { writeButton, readButton }
            };

            textArea.TextChanged += (o, e) => writeButton.IsEnabled = !string.IsNullOrEmpty(e.NewText);
        }
    }
}
