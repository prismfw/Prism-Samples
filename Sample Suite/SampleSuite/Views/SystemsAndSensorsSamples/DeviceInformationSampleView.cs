using System;
using System.Threading.Tasks;
using Prism;
using Prism.Systems;
using Prism.UI;
using Prism.UI.Controls;
using Prism.Utilities;
using SampleSuite.Resources;

namespace SampleSuite
{
    [NavigationView(Perspective)]
    [PreferredPanes(Panes.Detail)]
    public class DeviceInformationSampleView : BaseSampleView<BaseSampleModel>
    {
        public const string Perspective = "DeviceInformation";

        private Timer uptimeTimer;

        public DeviceInformationSampleView()
        {
            Device.Current.BatteryLevelChanged += OnBatterLevelChanged;
            Device.Current.OrientationChanged += OnOrientationChanged;
            Device.Current.PowerSourceChanged += OnPowerSourceChanged;

            uptimeTimer = new Timer(1000, true);
            uptimeTimer.Elapsed += (o, e) =>
            {
                Application.Current.BeginInvokeOnMainThread(() =>
                {
                    var label = VisualTreeHelper.GetChild<Label>(this, lbl => lbl.Name == Strings.SystemUptime);
                    if (label != null)
                    {
                        label.Text = TimeSpan.FromMilliseconds(Device.Current.SystemUptime).ToString(@"hh\:mm\:ss");
                    }
                });
            };
        }

        public override async Task ConfigureUIAsync()
        {
            await base.ConfigureUIAsync();

            Device.Current.IsOrientationMonitoringEnabled = true;
            Device.Current.IsPowerMonitoringEnabled = true;

            var grid = new Grid()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(1, 2),
                ColumnDefinitions =
                {
                    new ColumnDefinition(new GridLength(1, GridUnitType.Star)),
                    new ColumnDefinition(new GridLength(1, GridUnitType.Star))
                }
            };

            ConfigureLabel(grid, Strings.DeviceId, Device.Current.Id);
            ConfigureLabel(grid, Strings.DeviceName, Device.Current.Name);
            ConfigureLabel(grid, Strings.DeviceModel, Device.Current.Model);
            ConfigureLabel(grid, Strings.FormFactor, Device.Current.FormFactor.ToString());
            ConfigureLabel(grid, Strings.OperatingSystem, Device.Current.OperatingSystem.ToString());
            ConfigureLabel(grid, Strings.OSVersion, Device.Current.OSVersion.ToString());
            ConfigureLabel(grid, Strings.DisplayScale, Device.Current.DisplayScale.ToString());
            ConfigureLabel(grid, Strings.PhysicalOrientation, Device.Current.Orientation.ToString());
            ConfigureLabel(grid, Strings.PowerSource, Device.Current.PowerSource.ToString());
            ConfigureLabel(grid, Strings.BatteryLevel, Device.Current.BatteryLevel.ToString());
            ConfigureLabel(grid, Strings.SystemUptime, TimeSpan.FromMilliseconds(Device.Current.SystemUptime).ToString(@"hh\:mm\:ss"));

            SetContent(grid);
        }

        protected override void OnLoaded(EventArgs e)
        {
            base.OnLoaded(e);

            Device.Current.IsOrientationMonitoringEnabled = true;
            Device.Current.IsPowerMonitoringEnabled = true;

            uptimeTimer.Start();
        }

        protected override void OnUnloaded(EventArgs e)
        {
            base.OnUnloaded(e);

            Device.Current.IsOrientationMonitoringEnabled = false;
            Device.Current.IsPowerMonitoringEnabled = false;

            uptimeTimer.Stop();
        }

        private void ConfigureLabel(Grid grid, string name, string text)
        {
            grid.RowDefinitions.Add(new RowDefinition());

            var label = new Label()
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                Margin = new Thickness(0, 0, 4, 0),
                Lines = 1,
                Text = name + ":",
            };
            Grid.SetRow(label, grid.RowDefinitions.Count - 1);
            grid.Children.Add(label);

            label = new Label()
            {
                Lines = 1,
                Name = name,
                Text = text
            };
            Grid.SetColumn(label, 1);
            Grid.SetRow(label, grid.RowDefinitions.Count - 1);
            grid.Children.Add(label);
        }

        private void OnBatterLevelChanged(Device sender, EventArgs e)
        {
            Application.Current.BeginInvokeOnMainThread(() =>
            {
                var label = VisualTreeHelper.GetChild<Label>(this, lbl => lbl.Name == Strings.BatteryLevel);
                if (label != null)
                {
                    label.Text = Device.Current.BatteryLevel.ToString();
                }
            });
        }

        private void OnOrientationChanged(Device sender, EventArgs e)
        {
            Application.Current.BeginInvokeOnMainThread(() =>
            {
                var label = VisualTreeHelper.GetChild<Label>(this, lbl => lbl.Name == Strings.PhysicalOrientation);
                if (label != null)
                {
                    label.Text = Device.Current.Orientation.ToString();
                }
            });
        }

        private void OnPowerSourceChanged(Device sender, EventArgs e)
        {
            Application.Current.BeginInvokeOnMainThread(() =>
            {
                var label = VisualTreeHelper.GetChild<Label>(this, lbl => lbl.Name == Strings.PowerSource);
                if (label != null)
                {
                    label.Text = Device.Current.PowerSource.ToString();
                }
            });
        }
    }
}
