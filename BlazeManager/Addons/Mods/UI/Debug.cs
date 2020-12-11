using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace Addons.Mods.UI
{
    public partial class Debug : Form
    {
        public Debug()
        {
            InitializeComponent();
            Instance = this;
        }

        public static void SetMessage(string text)
        {
            Instance.textBox1.Text = text;
        }

        public static Debug Instance;
    }
}
