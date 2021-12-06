using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    /// <summary>
    /// работа (сохранение/загрузка) с файлами
    /// </summary>
    public class WorkIWithFile
    {
        /// <summary>
        /// сохранение файлы путем XML-серилизации
        /// </summary>
        /// <param name="path">путь до файла</param>
        public static void SaveFile(string path,
            System.ComponentModel.BindingList<DataGridFigureRow> data)

        {
            var writer = new System.Xml.Serialization.XmlSerializer(typeof
                (System.ComponentModel.BindingList<DataGridFigureRow>));

            using (var file = System.IO.File.Create(path))
            {
                writer.Serialize(file, data);
                file.Close();
            }
        }

        /// <summary>
        /// метод для загрузки файла
        /// </summary>
        /// <param name="path">путь до файла</param>
        /// <returns>Возвращает загруженный список</returns>
        public static System.ComponentModel.BindingList<DataGridFigureRow> LoadFile(string path)
        {
            System.ComponentModel.BindingList<DataGridFigureRow> data = new
                System.ComponentModel.BindingList<DataGridFigureRow>();

            var reader = new System.Xml.Serialization.XmlSerializer(typeof
                (System.ComponentModel.BindingList<DataGridFigureRow>));

            var file = new System.IO.StreamReader(path);
            data = (System.ComponentModel.BindingList<DataGridFigureRow>)reader.Deserialize(file);
            return data;
        }
    }
}
