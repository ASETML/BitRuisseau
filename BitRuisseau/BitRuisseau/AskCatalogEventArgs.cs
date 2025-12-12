using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitRuisseau
{
    internal class AskCatalogEventArgs : EventArgs
    {
        public string Name { get; }

        public AskCatalogEventArgs(string name)
        {
            this.Name = name;
        }
    }
}
