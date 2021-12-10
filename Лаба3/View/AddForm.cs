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
        /// <summary>
        /// поле для передачи фигуры в другие формы
        /// </summary>
        public FigureBase Figure { get; set; }    

        /// <summary>
        /// кортеж для создания и хранения элементов формы разных фигур
        /// </summary>
        private List<(List<Label> labels, List<TextBox> texts, FigureType type)>
            _tupleTextBox = new List<(List<Label> labels, List<TextBox> texts,
                FigureType type)>();

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
            List<Label> labelsForForm = new List<Label>();
            List<TextBox> textBoxForForm = new List<TextBox>();
            List<FigureType> figureTypes = new List<FigureType>()
            {
                FigureType.Triangle,
                FigureType.Rectangle,
                FigureType.Circle

            };                          
            for (int i = 0; i < 6; i++)
            {
                labelsForForm.Add(new Label());
                textBoxForForm.Add(new TextBox());
                labelsForForm[i].Visible = false;
                textBoxForForm[i].Visible = false;                                                                                                 
            }
            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        _tupleTextBox.Add((labelsForForm.GetRange(0, 3 - i), 
                            textBoxForForm.GetRange(0, 3 - i), figureTypes[i]));
                        break;
                    case 1:
                        _tupleTextBox.Add((labelsForForm.GetRange(3, 3 - i),
                            textBoxForForm.GetRange(3, 3 - i), figureTypes[i]));
                        break;
                    case 2:
                        _tupleTextBox.Add((labelsForForm.GetRange(5, 3 - i),
                            textBoxForForm.GetRange(5, 3 - i), figureTypes[i]));
                        break;

                }
            }
            for(int i = 0; i<_tupleTextBox.Count;i++)
            {
                for (int j = 0; j < _tupleTextBox[i].labels.Count; j++)
                {
                    groupBox1.Controls.Add(_tupleTextBox[i].labels[j]);
                    groupBox1.Controls.Add(_tupleTextBox[i].texts[j]);
                }
            }
            FormAction();            
        }

        /// <summary>
        /// метод для обновления контролов на форме в зависимости от типа фигур
        /// </summary>
        private void FormAction()
        {
           
            if (TriangleRadioButton.Checked == true)
            {
                visibleFalse(_tupleTextBox);
                _figureType = FigureType.Triangle;
                CreateElementsforForm(270, 170, 130, "Triangle", 
                    new Point(22, 190), new Point(130, 190), 3, "side",_tupleTextBox[0]);                                                                  
            }

            else if (CircleRadioButton.Checked == true)
            {
                visibleFalse(_tupleTextBox);
                _figureType = FigureType.Circle;
                CreateElementsforForm(200, 170, 70, "Circle", 
                    new Point(22, 125), new Point(130, 125),1,"radius", _tupleTextBox[2]);
            }

            else if (RectangleRadioButton.Checked == true)
            {
                visibleFalse(_tupleTextBox);
                _figureType = FigureType.Rectangle;
                CreateElementsforForm(230, 170, 100, "Rectangle", 
                    new Point(22, 155), new Point(130, 155),2,"side", _tupleTextBox[1]);
            }
        }

        /// <summary>
        /// метод для скрытия элементов формы после инициализации
        /// </summary>
        /// <param name="tupleElements">кортеж элементов формы</param>
        private void visibleFalse(List<(List<Label> labels, 
            List<TextBox> texts, FigureType type)> tupleElements)
        {
            for (int i = 0; i < tupleElements.Count; i++)
            {
                for (int j = 0; j < tupleElements[i].labels.Count; j++)
                {
                    tupleElements[i].texts[j].Visible = false;
                    tupleElements[i].labels[j].Visible = false;
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
        /// <param name="tupleElements"></param>
        private void CreateElementsforForm(int heightForm, int widthGrouBox, 
            int heightGroupBox, string nameTypeFigure,
            Point forButton1, Point  forButton2, int indexCountSide, 
            string nameSide, (List<Label> labels, 
            List<TextBox> texts, FigureType type) tupleElements)
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
                tupleElements.labels[i].Width = 46;
                tupleElements.labels[i].Height = 17;
                tupleElements.labels[i].Location = new Point(5, (i + 1) * 35);
                tupleElements.labels[i].Text = nameSide+(i+1);
                tupleElements.labels[i].Visible = true;
                tupleElements.texts[i].Location = new Point(60, (i + 1) * 33);
                tupleElements.texts[i].Visible = true;
                // плюс равно говорит что мы обрабатываем кей пресс событие обрабатывается методом 
                tupleElements.texts[i].KeyPress += textBox_KeyPress;
            }
        }

        /// <summary>
        /// метод для обновления формы при взаимодействии с чек 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CircleElementsOnFormRadioButton(object sender, EventArgs e)
        {                       
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
            this.Close();
        }

        /// <summary>
        /// Событие, при нажатии кнопки ОК
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OkAddFigureButton(object sender, EventArgs e)
        {
            try
            {                
                FigureBase newFigure = GetFigure(_figureType);
                Figure = newFigure; 
                this.Close();
                this.DialogResult = DialogResult.OK;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Ошибка",MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
            if (!Char.IsDigit(number) && e.KeyChar != '\b' && e.KeyChar != ',')
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
            List<double> paramsFigure = GetFigureParams(type);
            switch (type)
            {
                case FigureType.Triangle:                                        
                    figure = new Triangle(paramsFigure[0], paramsFigure[1],
                        paramsFigure[2]);
                    break;

                case FigureType.Rectangle:                         
                    figure = new LibraryForGeometry.Rectangle(paramsFigure[0],
                        paramsFigure[1]);
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
        private List<double> GetFigureParams(FigureType type)
        {
            List<double> figureParams = new List<double>();
            int i =0;
            switch(type)
            {
                case FigureType.Triangle:
                    i = 0;
                    break;
                case FigureType.Rectangle:
                    i = 1;
                    break;
                case FigureType.Circle:
                    i = 2;
                    break;
            }
            foreach (var textbox in _tupleTextBox[i].texts)
            {
                figureParams.Add(Convert.ToDouble(textbox.Text));
            }
            return figureParams;
        }

    }
}
