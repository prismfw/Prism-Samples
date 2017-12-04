using System;
using System.IO;
using System.Threading.Tasks;
using Prism;
using Prism.IO;

namespace SampleSuite
{
    [NavigationController("FileIO/{sample}")]
    public class ReadWriteSampleController : Controller<ReadWriteSampleModel>
    {
        public override async Task<string> LoadAsync(NavigationContext context)
        {
            Model = new ReadWriteSampleModel()
            {
                Title = Resources.Strings.ResourceManager.GetString(context.Parameters.GetValueOrDefault<string>("sample")),
                Description = Resources.Strings.ReadWriteSampleDescription,
                FileName = Directory.DataDirectoryPath + "readwritesample.txt"
            };

            try
            {
                Model.InitialText = await File.ReadAllTextAsync(Model.FileName);
                Model.FileExists = true;
            }
            catch (FileNotFoundException)
            {
                Model.FileExists = false;
            }

            return ReadWriteSampleView.Perspective;
        }
    }
}
