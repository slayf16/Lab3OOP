using LibraryForGeometry;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    /// <summary>
    /// работа (сохранение/загрузка) с файлами
    /// </summary>
    public class Loader
    {
        /// <summary>
        /// сохранение файлы путем XML-серилизации
        /// </summary>
        /// <param name="path">путь до файла</param>
        public static void SaveFile(string path,List<FigureBase> data)

        {
            // создаем объект BinaryFormatter
            BinaryFormatter formatter = new BinaryFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            using (var fs =  File.Create(path))
            {
                formatter.Serialize(fs, data);                
            }
        }

        /// <summary>
        /// метод для загрузки файла
        /// </summary>
        /// <param name="path">путь до файла</param>
        /// <returns>Возвращает загруженный список</returns>
        public static List<FigureBase> LoadFile(string path)
        {
            try
            {
                var datas = new System.ComponentModel.BindingList<DataGridFigureRow>();
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream($"{path}", FileMode.OpenOrCreate))
                {
                    var loadedData = (List<FigureBase>)formatter.Deserialize(fs);
                    return loadedData;
                }                
            }
            catch(Exception ex)
            {
                throw new Exception("неверная структура или файл поврежден");
            }
        }
    }
}
