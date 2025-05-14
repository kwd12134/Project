using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BL12
{
    public partial class AddLog : ListView
    {
        public AddLog()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        public AddLog(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
