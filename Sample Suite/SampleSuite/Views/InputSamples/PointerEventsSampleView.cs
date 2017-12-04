using System;
using System.Threading.Tasks;
using Prism;
using Prism.Input;
using Prism.IO;
using Prism.UI;
using Prism.UI.Controls;
using Prism.UI.Media;
using SampleSuite.Resources;

namespace SampleSuite
{
    [NavigationView(Perspective)]
    [PreferredPanes(Panes.Detail)]
    public class PointerEventsSampleView : BaseSampleView<BaseSampleModel>
    {
        public const string Perspective = "PointerEvents";

        private Label textLabel;

        public override async Task ConfigureUIAsync()
        {
            await base.ConfigureUIAsync();

            textLabel = new Label()
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
            };
            SetLabelText(null, null);

            var grid = new Grid()
            {
                Children = { textLabel },
                Background = (Brush)TryFindResource(SystemResources.ViewBackgroundBrushKey),
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch
            };

            grid.PointerPressed += (o, e) => SetLabelText(Strings.Pressed, e);
            grid.PointerMoved += (o, e) => SetLabelText(Strings.Moved, e);
            grid.PointerReleased += (o, e) => SetLabelText(Strings.Released, e);

            SetContent(grid);
        }

        private void SetLabelText(string action, PointerEventArgs args)
        {
            if (args == null)
            {
                textLabel.Text = string.Format("{0}:\n{1}:\n{2}:\n{3}:\n{4}:\n",
                    Strings.Action, Strings.InputType, Strings.Position, Strings.Pressure, Strings.Timestamp);
            }
            else
            {
                textLabel.Text = string.Format("{0}: {1}\n{2}: {3}\n{4}: {5}\n{6}: {7}\n{8}: {9}",
                    Strings.Action, action,
                    Strings.InputType, args.PointerType,
                    Strings.Position, args.Position.ToString("N3"),
                    Strings.Pressure, args.Pressure.ToString("N3"),
                    Strings.Timestamp, args.Timestamp);

                textLabel.VerticalAlignment = args.Position.X < textLabel.RenderSize.Width + 10 && args.Position.Y < textLabel.RenderSize.Height + 10 ?
                    VerticalAlignment.Bottom : VerticalAlignment.Top;
            }
        }
    }
}
