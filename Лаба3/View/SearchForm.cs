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
    /// <summary>
    /// форма для выполнения поиска данных
    /// </summary>
    public partial class SearchForm : Form
    {
        /// <summary>
        /// поле формы с данными , которые хранятся на главной форме
        /// </summary>
        private BindingList<DataGridFigureRow> dataFromTheFigureForm = 
            new BindingList<DataGridFigureRow>();

        /// <summary>
        /// поле для присвания и передачи индекса фигуры после выполнения поиска
        /// </summary>
        public List<int> IndexforSearch { get; set; }

        

        /// <summary>
        /// конструктор формы
        /// </summary>
        public SearchForm(BindingList<DataGridFigureRow> datas)
        {
            InitializeComponent();
            this.dataFromTheFigureForm = datas;
        }

        /// <summary>
        /// Кнопка для выполнения поиска
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchButton(object sender, EventArgs e)
        {
            
            if (textBox1.Text == "")
            {
                MessageBox.Show("enter your search terms",
                    "Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);    
            }
            else
            {
                List<int> index = new List<int>();
                int i = 0;
                foreach (DataGridFigureRow str in dataFromTheFigureForm)
                {
                    if (str.FigureName.Contains(textBox1.Text) ||
                        str.FigureProps.Contains(textBox1.Text))
                    {
                        index.Add(i);
                    }
                    i++;
                }
                IndexforSearch = index;
                this.Close();
                this.DialogResult = DialogResult.OK;
            }
        }

        /// <summary>
        /// кнопка для отказа от поиска
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
