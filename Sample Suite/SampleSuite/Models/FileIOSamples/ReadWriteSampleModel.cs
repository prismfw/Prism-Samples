using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleSuite
{
    public class ReadWriteSampleModel : BaseSampleModel
    {
        public string FileName { get; set; }

        public bool FileExists { get; set; }

        public string InitialText { get; set; }
    }
}
