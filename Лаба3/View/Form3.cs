using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class Form3 : Form
    {
        /// <summary>
        /// поле для назначения родительской формы
        /// </summary>
        public FigureForm ParentForm { get; set; }

        public Form3()
        {
            InitializeComponent();
        }
    }
}
