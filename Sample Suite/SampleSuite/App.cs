using System;
using Prism;

namespace SampleSuite
{
    public class App : Application
    {
        protected override void OnInitialized()
        {
            Navigate(CategoryController.Uri);
        }
    }
}
