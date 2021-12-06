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
    public partial class Form2 : Form
    {
        /// <summary>
        /// список для создания и работы с текстбоксами
        /// </summary>
        private List<TextBox> _textBoxes = new List<TextBox>();

        /// <summary>
        /// поле перечисления для создания фигур нужного типа
        /// </summary>
        private FigureType _figureType;

        /// <summary>
        /// Объявление родительской формы
        /// </summary>
        public FigureForm ParentForm { get; set; }

        public Form2()
        {
            InitializeComponent();
            FormAction();
        }

        /// <summary>
        /// метод для обновления контролов на форме в зависимости от типа фигур
        /// </summary>
        private void FormAction()
        {
            _textBoxes.Clear();
            if (radioButton1.Checked == true)
            {
                _figureType = FigureType.Triangle;
                CreateElementsforForm(270, 170, 130, "Triangle", new Point(22, 190), new Point(130, 190), 3, "side");
            }

            else if (radioButton2.Checked == true)
            {
                _figureType = FigureType.Circle;
                CreateElementsforForm(200, 170, 70, "Circle", new Point(22, 125), new Point(130, 125), 1, "radius");
            }

            else if (radioButton3.Checked == true)
            {
                _figureType = FigureType.Rectangle;
                CreateElementsforForm(230, 170, 100, "Rectangle", new Point(22, 155), new Point(130, 155), 2, "side");
            }
        }

        /// <summary>
        /// метод для создания элементов взаимодействия с формой
        /// </summary>
        /// <param name="heightForm">высота формы</param>
        /// <param name="widthGrouBox">ширина группбокса</param>
        /// <param name="heightGroupBox">высота группбокса</param>
        /// <param name="nameTypeFigure">название типа фигуры для названия групбокса</param>
        /// <param name="forButton1">положение кнопки вставить</param>
        /// <param name="forButton2">положение кнопки отмена</param>
        /// <param name="indexCountSide">количество сторон определяющих фигуру</param>
        /// <param name="nameSide">название стороны фигруы показываемое на экране</param>
        private void CreateElementsforForm(int heightForm, int widthGrouBox, int heightGroupBox, string nameTypeFigure,
            Point forButton1, Point forButton2, int indexCountSide, string nameSide)
        {
            this.Width = 255;
            this.Height = heightForm;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            groupBox1.Width = widthGrouBox;
            groupBox1.Height = heightGroupBox;
            groupBox1.Controls.Clear();
            groupBox1.Text = nameTypeFigure;
            button1.Location = forButton1;
            button2.Location = forButton2;
            List<Label> labels = new List<Label>();
            for (int i = 0; i < indexCountSide; i++)
            {
                labels.Add(new Label());
                _textBoxes.Add(new TextBox());
                groupBox1.Controls.Add(labels[i]);
                groupBox1.Controls.Add(_textBoxes[i]);
                labels[i].Width = 46;
                labels[i].Height = 17;
                labels[i].Location = new Point(5, (i + 1) * 35);
                labels[i].Text = nameSide + (i + 1);
                _textBoxes[i].Location = new Point(60, (i + 1) * 33);
                _textBoxes[i].KeyPress += textBox_KeyPress;// плюс равно говорит что мы обрабатываем кей пресс событие обрабатывается методом 
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            FormAction();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            FormAction();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            FormAction();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var parent = this.ParentForm as FigureForm;
            try
            {
                FigureBase figure = GetFigure(_figureType);
                parent.AddFigureeRow(figure.GetName(), figure.GetInfo());
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
