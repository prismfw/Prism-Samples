using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleSuite
{
    public class SelectListSampleModel : UIControlsSampleModel
    {
        public SelectListSampleModelItem[] Items { get; set; }
    }

    public class SelectListSampleModelItem
    {
        public string Name { get; set; }

        public object Value { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
