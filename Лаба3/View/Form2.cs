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
    public partial class Form2 : Form
    {
        /// <summary>
        /// список для создания и работы с текстбоксами
        /// </summary>
        private List<TextBox> _textBoxes = new List<TextBox>();

        /// <summary>
        /// поле перечисления для создания фигур нужного типа
        /// </summary>
      //  private FigureType _figureType;

        /// <summary>
        /// Объявление родительской формы
        /// </summary>
        public FigureForm ParentForm { get; set; }

        public Form2()
        {
            InitializeComponent();
        }
    }
}
