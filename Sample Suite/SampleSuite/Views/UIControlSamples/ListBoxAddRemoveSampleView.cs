using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Prism;
using Prism.Systems;
using Prism.UI;
using Prism.UI.Controls;
using Prism.UI.Media;
using SampleSuite.Resources;

namespace SampleSuite
{
    [View]
    [PreferredPanes(Panes.Detail)]
    public class ListBoxAddRemoveSampleView : BaseSampleView<ListBoxSampleModel>
    {
        public override async Task ConfigureUIAsync()
        {
            await base.ConfigureUIAsync();

            var listBox = new ListBox()
            {
                Items = new ObservableCollection<object>(Model.Items),
                SelectionMode = SelectionMode.None
            };

            var panel = Content as Panel;
            if (panel != null)
            {
                panel.Children.Add(listBox);
            };

            Menu = new ActionMenu()
            {
                MaxDisplayItems = 3,
                Items =
                {
                    new MenuButton()
                    {
                        Title = "+",
                        Action = (button) => listBox.Items.Add(Strings.Item + " " + (listBox.Items.Count + 1))
                    },
                    new MenuButton()
                    {
                        Title = "-",
                        Action = (button) =>
                        {
                            if (listBox.Items.Count > 0)
                            {
                                listBox.Items.RemoveAt(listBox.Items.Count - 1);
                            }
                        }
                    },
                    new MenuButton()
                    {
                        Title = ">]",
                        Action = (button) =>
                        {
                            var textBox = new TextBox() { Margin = new Thickness(4, 12, 4, 6), BorderWidth = 1 };
                            var errorLabel = new Label() { Foreground = new SolidColorBrush(Colors.Red), Visibility = Visibility.Hidden, Text = " " };
                            var okButton = new Button() { Title = Strings.OK, Margin = new Thickness(5), MinWidth = 96 };
                            var cancelButton = new Button() { Title = Strings.Cancel, Margin = new Thickness(5), MinWidth = 96 };

                            var popup = new Popup()
                            {
                                IsLightDismissEnabled = true,
                                PresentationStyle = PopupPresentationStyle.Custom,
                                Width = 480,
                                Height = 192
                            };
                            
                            popup.Content = new Border()
                            {
                                BorderBrush = new SolidColorBrush(Colors.Gray),
                                BorderThickness = new Thickness(1),
                                HorizontalAlignment = HorizontalAlignment.Stretch,
                                VerticalAlignment = VerticalAlignment.Stretch,
                                Child = new StackPanel()
                                {
                                    HorizontalAlignment = HorizontalAlignment.Center,
                                    VerticalAlignment = VerticalAlignment.Center,
                                    Orientation = Orientation.Vertical,
                                    Children =
                                    {
                                        new Label() { Text = string.Format(Strings.EnterIndexValue, listBox.Items.Count) },
                                        textBox,
                                        errorLabel,
                                        new StackPanel()
                                        {
                                            HorizontalAlignment = HorizontalAlignment.Center,
                                            Margin = new Thickness(4, 12, 4, 6),
                                            Children = { okButton, cancelButton }
                                        }
                                    }
                                }
                            };

                            textBox.TextChanged += (o, e) =>
                            {
                                int index = 0;
                                if (e.NewText == string.Empty || (int.TryParse(e.NewText, out index) && index >= 0 && index <= listBox.Items.Count))
                                {
                                    errorLabel.Visibility = Visibility.Hidden;
                                    okButton.IsEnabled = true;
                                    return;
                                }

                                errorLabel.Visibility = Visibility.Visible;
                                errorLabel.Text = index == 0 ? Strings.InvalidIndexValue : Strings.IndexOutOfRange;
                                okButton.IsEnabled = false;
                            };

                            okButton.Clicked += (o, e) =>
                            {
                                int index;
                                if (int.TryParse(textBox.Text, out index))
                                {
                                    listBox.Items.Insert(index, Strings.Item + " " + (listBox.Items.Count + 1));
                                }

                                popup.Close();
                            };

                            cancelButton.Clicked += (o, e) => popup.Close();

                            popup.Open(Window.Current);
                        }
                    }
                }
            };
        }
    }
}
