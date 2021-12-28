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
        /// фигуры
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
            AddForm addForm = new AddForm();
            addForm.ShowDialog();
            if(addForm.DialogResult == DialogResult.OK)
            {
                Figures.Add(addForm.Figure);
                AddFigureeRow(addForm.Figure.GetName(), addForm.Figure.GetInfo());
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
                MessageBox.Show("List is empty", "information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //BUG:+
                try
                {
                    int delet = dataGridView1.SelectedCells[0].RowIndex;
                    dataGridView1.Rows.RemoveAt(delet);
                    Figures.RemoveAt(delet);
                }
                catch
                {                   
                    MessageBox.Show("Highlight the item", "Information",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// кнопка для вызова формы поиска
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchButton(object sender, EventArgs e)
        {
            var searchForm = new SearchForm(FigureList);
            searchForm.ShowDialog();
            if (searchForm.DialogResult != DialogResult.OK) return;

            var indexFofSearch = searchForm.IndexforSearch;
            SelectRow(indexFofSearch);
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
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "(*.fig) | *.fig";

            if (FigureList.Count == 0)
            {
                MessageBox.Show("No data to save", "information",
                    MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                if (save.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                Loader.SaveFile(save.FileName, Figures);
            }
        }

        /// <summary>
        /// кнопка для загрузки данных из файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadButtonMenuStrip(object sender, EventArgs e)
        {
            var figures = new List<FigureBase>();
            var figureList =
                new BindingList<DataGridFigureRow>();
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "(*.fig)|*.fig";
                if (openFile.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
         
                figures = Loader.LoadFile(openFile.FileName);
                foreach (FigureBase figureBase in figures)
                {
                    figureList.Add(new DataGridFigureRow()
                    {
                        FigureName = figureBase.GetName(),
                        FigureProps = figureBase.GetInfo(),
                    });
                }
                Figures.Clear();
                FigureList.Clear();
                FigureList = figureList;
                Figures = figures;
                dataGridView1.DataSource = FigureList;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
                DialogResult dialog = MessageBox.Show("Do you really want to exit?",
                    "shutdown", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                
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
