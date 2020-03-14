using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace HeadTail
{
    class TeamA : Teams
    {
        String name;
        public int runs =0 ;
        public bool wicket = false;
        public void setRuns(int runs)
        {
            this.runs = runs;
        }
        public int getRuns()
        {
            return runs;
        }
        public TeamA()
        {

        }
        public TeamA(String name)
        {
            this.name = name;
        }
        public String getName()
        {
            return name;
        }
      
    }
}
