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
    /// форма для добавления фигур в список данных
    /// </summary>
    public partial class AddForm : Form
    {
        public FigureBase figure { get; set; }
      //  private 
        /// <summary>
        /// список для создания и работы с текстбоксами
        /// </summary>
        private List<TextBox> _textBoxes = new List<TextBox>();

        private List<TextForTextBox> texts = new List<TextForTextBox>();

        private List<Label> _labels = new List<Label>();

       // private (List<Label> labels, List<TextBox> texts, FigureType type) x =   ( new List<Label> (), new List<TextBox> (), new FigureType ());

        /// <summary>
        /// поле перечисления для создания фигур нужного типа
        /// </summary>
        private FigureType _figureType;
       
        //TODO: убрать.+ убрал родительскую форму


        /// <summary>
        /// конструктор формы
        /// </summary>
        public AddForm()
        {
            //TODO: передать список для поиска в конструктор - выполнил по другому,
            //списки тоже не передаю, передаю между формами только созданную фигуру            
            InitializeComponent();
            
           
            for (int i = 0; i < 6; i++)
            {
                _textBoxes.Add(new TextBox());
                _textBoxes[i].Visible = false;
                _labels.Add(new Label());
                _labels[i].Visible = false;

                switch (_textBoxes.Count)
                {
                    case  3 :
                        texts.Add(new TextForTextBox()
                        {
                            type = FigureType.Triangle,
                            textBox = _textBoxes.GetRange(0,3),
                            labels = _labels.GetRange(0,3)
                        });
                        break;

                    case 5:
                        texts.Add(new TextForTextBox()
                        {
                            type = FigureType.Rectangle,
                            textBox = _textBoxes.GetRange(3, 2),
                            labels = _labels.GetRange(3, 2)
                        });
                        break;

                    case 6:
                        texts.Add(new TextForTextBox()
                        {
                            type = FigureType.Circle,
                            textBox = _textBoxes.GetRange(5, 1),
                            labels = _labels.GetRange(5, 1)
                        });
                        break;
                }                                                           
            }    

            for(int i = 0; i<texts.Count;i++)
            {
                for (int j = 0; j < texts[i].labels.Count; j++)
                {
                    groupBox1.Controls.Add(texts[i].labels[j]);
                    groupBox1.Controls.Add(texts[i].textBox[j]);
                }
            }
       
            FormAction();
            
        }

        /// <summary>
        /// метод для обновления контролов на форме в зависимости от типа фигур
        /// </summary>
        private void FormAction()
        {
           
            if (radioButton1.Checked == true)
            {
                visibleFalse(texts);
                _figureType = FigureType.Triangle;
                CreateElementsforForm(270, 170, 130, "Triangle", new Point(22, 190), new Point(130, 190), 3, "side",texts[0]);                                                                  
            }

            else if (radioButton2.Checked == true)
            {
                visibleFalse(texts);
                _figureType = FigureType.Circle;
                CreateElementsforForm(200, 170, 70, "Circle", new Point(22, 125), new Point(130, 125),1,"radius", texts[2]);
            }

            else if (radioButton3.Checked == true)
            {
                visibleFalse(texts);
                _figureType = FigureType.Rectangle;
                CreateElementsforForm(230, 170, 100, "Rectangle", new Point(22, 155), new Point(130, 155),2,"side", texts[1]);
            }
        }

        private void visibleFalse(List<TextForTextBox> texts)
        {
            for (int i = 0; i < texts.Count; i++)
            {
                for (int j = 0; j < texts[i].labels.Count; j++)
                {
                    texts[i].textBox[j].Visible = false;
                    texts[i].labels[j].Visible = false;
                }
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
        private void CreateElementsforForm(int heightForm, int widthGrouBox, 
            int heightGroupBox, string nameTypeFigure,
            Point forButton1, Point  forButton2, int indexCountSide, string nameSide, TextForTextBox box)
        {
            this.Width = 255;
            this.Height = heightForm;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            groupBox1.Width = widthGrouBox;
            groupBox1.Height = heightGroupBox;
            groupBox1.Text = nameTypeFigure;
            button1.Location = forButton1;
            button2.Location = forButton2;
            for (int i = 0; i < indexCountSide; i++)
            {              
                box.labels[i].Width = 46;
                box.labels[i].Height = 17;
                box.labels[i].Location = new Point(5, (i + 1) * 35);
                box.labels[i].Text = nameSide+(i+1);
                box.labels[i].Visible = true;
                box.textBox[i].Location = new Point(60, (i + 1) * 33);
                box.textBox[i].Visible = true;
                // плюс равно говорит что мы обрабатываем кей пресс событие обрабатывается методом 
                _textBoxes[i].KeyPress += textBox_KeyPress;
            }
        }

        /// <summary>
        /// метод для обновления формы при взаимодействии с чек 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CircleElementsOnFormRadioButton(object sender, EventArgs e)
        {
            
            for (int i = 0; i < texts.Count; i ++)

            FormAction();
            
        }

        /// <summary>
        /// метод для обновления формы при взаимодействии с чеком 3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RectangleElementsOnFormRadioButton(object sender, EventArgs e)
        {
            FormAction();
        }

        /// <summary>
        /// метод для обновления формы при взаимодействии с чекбоксом 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TriangleElementsOnFormRadioButton(object sender, EventArgs e)
        {
            FormAction();
        }

        /// <summary>
        /// Событие, при нажатии кнопки отмена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Событие, при нажатии кнопки ОК
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OkAddFigureButton(object sender, EventArgs e)
        {
            //var parent = this.ParentForm as FigureForm;
            try
            {
                FigureBase newFigure = GetFigure(_figureType);
                //parent.AddFigureeRow(figure.GetName(), figure.GetInfo());
                figure = newFigure; 
                this.Close();
                this.DialogResult = DialogResult.OK;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
        }

        /// <summary>
        /// обработчик взаимодействия с текстбоксами (валидация данных)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }

        }

        /// <summary>
        /// Создание фигуры с введенными пользователем параметрами
        /// </summary>
        /// <param name="type"></param>
        /// <returns>возвращает фигуру нужного типа</returns>
        private FigureBase GetFigure(FigureType type)
        {
            FigureBase figure = null;
            List<double> paramsFigure = GetFigureParams();
            switch (type)
            {
                case FigureType.Triangle:                                        
                    figure = new Triangle(paramsFigure[0], paramsFigure[1], paramsFigure[2]);
                    break;

                case FigureType.Rectangle:                         
                    figure = new LibraryForGeometry.Rectangle(paramsFigure[0], paramsFigure[1]);
                    break;

                case FigureType.Circle:
                    figure = new Circle(paramsFigure[0]);
                    break;
            }
            return figure;                                                  
        }

        /// <summary>
        /// метод для считывания параметров с экрана 
        /// </summary>
        /// <returns>возвращает массив числовых параметров фигуры</returns>
        private List<double> GetFigureParams()
        {
            List<double> figureParams = new List<double>();
            foreach(var textbox in _textBoxes)
            {
                figureParams.Add(Convert.ToDouble(textbox.Text));
            }
            return figureParams;
        }
    }
}
