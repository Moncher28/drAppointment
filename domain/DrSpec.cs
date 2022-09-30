using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain
{
    internal class DrSpec
    {
        private int id;
        private string name;
        private DrSpec spec;

        public int Id { get { return id; } }
        public string Name { get { return name; } }

        public DrSpec Spec { get { return spec; } set { spec = value; } }
    }
}
