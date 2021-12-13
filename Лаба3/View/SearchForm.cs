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
        /// 
        /// </summary>
        private BindingList<DataGridFigureRow> datas = 
            new BindingList<DataGridFigureRow>();

        /// <summary>
        /// 
        /// </summary>
        public List<int> IndexforSearch { get; set; }

        

        /// <summary>
        /// конструктор формы
        /// </summary>
        public SearchForm(BindingList<DataGridFigureRow> datas)
        {
            InitializeComponent();
            this.datas = datas;
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
                MessageBox.Show("введите условия для выполнения поиска",
                    "Информация", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);    
            }
            else
            {
                List<int> index = new List<int>();
                int i = 0;
                foreach (DataGridFigureRow str in datas)
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
