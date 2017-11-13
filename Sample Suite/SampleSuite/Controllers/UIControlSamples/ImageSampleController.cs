using System;
using System.Threading.Tasks;
using Prism;

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
                ImageUri = new Uri("image.png", UriKind.Relative),
                Title = Resources.Strings.Image
            };

            return Task.FromResult(ImageSampleView.Perspective);
        }
    }
}
