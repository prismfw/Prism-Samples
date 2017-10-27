using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Prism;
using Prism.UI;
using Prism.UI.Controls;
using SampleSuite.Resources;

namespace SampleSuite
{
    [NavigationController("UIControls/SelectList")]
    public class SelectListSampleController : Controller<SelectListSampleModel>
    {
        public override Task<string> LoadAsync(NavigationContext context)
        {
            Model = new SelectListSampleModel()
            {
                Title = typeof(SelectList).Name,
                Description = Resources.Strings.SelectListSampleDescription,
                Items = new[]
                {
                    new SelectListSampleModelItem() { Name = Strings.Black, Value = Colors.Black },
                    new SelectListSampleModelItem() { Name = Strings.Blue, Value = Colors.Blue },
                    new SelectListSampleModelItem() { Name = Strings.Green, Value = Colors.Green },
                    new SelectListSampleModelItem() { Name = Strings.Orange, Value = Colors.Orange },
                    new SelectListSampleModelItem() { Name = Strings.Purple, Value = Colors.Purple },
                    new SelectListSampleModelItem() { Name = Strings.Red, Value = Colors.Red },
                    new SelectListSampleModelItem() { Name = Strings.White, Value = Colors.White },
                    new SelectListSampleModelItem() { Name = Strings.Yellow, Value = Colors.Yellow }
                }
            };

            return Task.FromResult(SelectListSampleView.Perspective);
        }
    }
}
