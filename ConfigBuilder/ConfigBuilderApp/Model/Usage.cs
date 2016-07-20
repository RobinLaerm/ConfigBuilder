using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigBuilderApp.Model
{
    public class Usage
    {
        public Usage(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }
    }
}
