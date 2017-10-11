using System;
using System.Threading.Tasks;
using Prism;
using Prism.IO;
using Prism.UI.Controls;

namespace SampleSuite
{
    [NavigationController("UIControls/" + ImageSampleView.Perspective)]
    public class ImageSampleController : Controller<ImageSampleModel>
    {
        public override Task<string> LoadAsync(NavigationContext context)
        {
            Model = new ImageSampleModel()
            {
                Description = Resources.Strings.ImageSampleDescription,
                ImageUri = new Uri(Directory.AssetDirectory + "image.png", UriKind.RelativeOrAbsolute),
                Title = Resources.Strings.Image
            };

            return Task.FromResult(ImageSampleView.Perspective);
        }
    }
}
