using LibraryForGeometry;
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
    /// Работа с главной формой
    /// </summary>
    public partial class FigureForm : Form
    {
        /// <summary>
        /// Лист для данных
        /// </summary>
        public BindingList<DataGridFigureRow> FigureList =
            new BindingList<DataGridFigureRow>();

        /// <summary>
        /// конструктор формы
        /// </summary>
        public FigureForm()
        {
            InitializeComponent();
            #if !DEBUG
            button4.Visible = false;            
            #endif
        }

        /// <summary>
        /// Кнопка для вызова формы добавления фигуры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ParentForm = this;
            form2.ShowDialog(this);
        }


        /// <summary>
        /// метод для связи datagrid с полем параметров
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FigureForm_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = FigureList;
        }


        /// <summary>
        /// метод для добавления элемента в список данных и экран
        /// </summary>
        /// <param name="figureName">имя фигуры</param>
        /// <param name="figureInfo">параметры фигуры</param>
        public void AddFigureeRow(string figureName, string figureInfo)
        {

            FigureList.Add(new DataGridFigureRow()
            {
                FigureName = figureName,
                FigureProps = figureInfo
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (FigureList.Count == 0)
            {
                MessageBox.Show("Список пустой");
            }
            else
            {
                int delet = dataGridView1.SelectedCells[0].RowIndex;
                dataGridView1.Rows.RemoveAt(delet);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ParentForm = this;
            form3.ShowDialog(this);
        }


        /// <summary>
        /// кнопка для формирования рандомных данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            FigureBase figure = FigureRandom.GetRandomFigure();
            AddFigureeRow(figure.GetName(), figure.GetInfo());
        }


        /// <summary>
        /// метод для выделения найденных объектов
        /// </summary>
        /// <param name="index"></param>
        public void SelectRow(List<int> index)
        {
            dataGridView1.ClearSelection();
            for (int i = 0; i < index.Count(); i++)
            {
                dataGridView1.Rows[index[i]].Selected = true;
            }
        }



        /// <summary>
        /// кнопка сохранения данных в файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FigureList.Count == 0)
            {
                MessageBox.Show("Отсутствуют данные для сохранения");
            }
            else
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                WorkIWithFile.SaveFile(saveFileDialog1.FileName, FigureList);
            }
        }

        /// <summary>
        /// кнопка для загрузки данных из файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FigureList.Clear();
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            FigureList = WorkIWithFile.LoadFile(openFileDialog1.FileName);
            dataGridView1.DataSource = FigureList;

        }
    }
}
