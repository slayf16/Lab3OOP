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
        /// 
        /// </summary>
        public List<FigureBase> Figures = new List<FigureBase>(); 

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
        private void AddFigureButton(object sender, EventArgs e)
        {
            AddForm form2 = new AddForm();
            form2.ShowDialog();
            if(form2.DialogResult == DialogResult.OK)
            {
                Figures.Add(form2.figure);
                AddFigureeRow(form2.figure.GetName(), form2.figure.GetInfo());
            }            
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
            }) ;
        }

        /// <summary>
        /// кнопка для удаления выделенного элемента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveFigureButton(object sender, EventArgs e)
        {
            if (FigureList.Count == 0)
            {
                MessageBox.Show("Список пустой");
            }
            else
            {
                int delet = dataGridView1.SelectedCells[0].RowIndex;
                dataGridView1.Rows.RemoveAt(delet);
                Figures.RemoveAt(delet);
            }
        }

        /// <summary>
        /// кнопка для вызова формы поиска
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchButton(object sender, EventArgs e)
        {
            List<int> indexFofSearch = new List<int>();
            SearchForm form3 = new SearchForm(FigureList);
            form3.ShowDialog();
            if (form3.DialogResult == DialogResult.OK)
            {
                indexFofSearch = form3.IndexforSearch;
                SelectRow(indexFofSearch);

            }
        }

        /// <summary>
        /// кнопка для формирования рандомных данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RandomFigureButton(object sender, EventArgs e)
        {
            FigureBase figure = FigureRandom.GetRandomFigure();
            Figures.Add(figure);
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
        private void SaveButtonMenuStrip(object sender, EventArgs e)
        {
            if (FigureList.Count == 0)
            {
                MessageBox.Show("Отсутствуют данные для сохранения");
            }
            else
            {
                //TODO: RSDN+
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                Loader.SaveFile(saveFileDialog1.FileName, Figures);
            }
        }

        /// <summary>
        /// кнопка для загрузки данных из файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadButtonMenuStrip(object sender, EventArgs e)
        {
            try
            {
                Figures.Clear();
                FigureList.Clear();
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                Figures = Loader.LoadFile(openFileDialog1.FileName);
                foreach (FigureBase figureBase in Figures)
                {
                    FigureList.Add(new DataGridFigureRow()
                    {
                        FigureName = figureBase.GetName(),
                        FigureProps = figureBase.GetInfo(),
                    });
                }
                dataGridView1.DataSource = FigureList;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Уточнение завершения работы с программой, если  имеются не пустые данные
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FigureForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(FigureList.Count!=0)
            {
                DialogResult dialog = MessageBox.Show("вы действительно хотите выйти?", 
                    "завершение работы", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                //TODO: switch-case+
                switch (dialog)
                {
                    case DialogResult.Yes:
                        e.Cancel = false;
                        break;
                    case DialogResult.No:
                        e.Cancel = true;
                        break;
                }
            }
        }
    }
}
