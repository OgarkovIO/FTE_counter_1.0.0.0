using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Loader
{
    public class Options_save //Создаём класс для сохранения данных  в конфиг файл.
    {
        private string _dbpath;//Создаём приватную переменную для хранения данных о месте размещения файла.

        private string _sm_upload_type;

        private string _fields_upload_type;

        private int _nulltype;
        /*
        public delegate void OtionsEvent(string s);
        public event OtionsEvent Income_Fields_upload_type;
        */
        public Options_save()//Создаём публичный конструктор класса
        {
            _dbpath = "";//Содержащий команду на присвоение переменной  _filePath пустоно значения при инициализации экземпляра класса.
            _nulltype = 0;
        }
        /*
        public void UpdateFieldsType()
        {
            Income_Fields_upload_type(_fields_upload_type);
        }*/

        public void ReadConfig()//Создаём публичный метод для чтения конфигурационного XML файла.
        {
            //читаем данные из конфигурационного файла
            try//Добавляем обработчик исключений в нутрь которого ложим запускаемый код.
            {
                XDocument xml = new XDocument();//Объявляем новый экземпляр класса XDocument - xml
                xml = XDocument.Load("config.xml");//Загружаем наш конфиг файл из папки приложения.
                string FilePath = xml.Element("config").Element("FilePath").Value;//Объявляем переменную типа string - FilePath куда запишем данные из конфиг файла, в.т.ч, из элемента FilePath вытаскиваем текстовое содержимое (.Value) и вбрасываем в переменную FilePath
                string SMUploadType = xml.Element("config").Element("SMUploadType").Value;
                string FieldsUploadType = xml.Element("config").Element("FieldsUploadType").Value;

                _dbpath = FilePath;//Заносим значение в приватное поле для работы внутри класса
                _sm_upload_type = SMUploadType;
                _fields_upload_type = FieldsUploadType;
            }
            catch//Перехватываем исключение и ......
            {
                MessageBox.Show("Не удалось загрузить настройки из файла config.xml");//В случе ошибки будет показанно это сообщение.
            }
        }

        public void saveConfig(string FilePath, int SMUploadType/*, int FieldsUploadType*/)//Создаём публичный метод для сохранения данных в конфиг файл, входным параметром которого будет строчная переменная FilePath.
        {   /*
            UpdateFieldsType();
            */
            string SMUploadTypeString;
            SMUploadTypeString = SMUploadType.ToString();

            string FieldsUploadTypeString;
            FieldsUploadTypeString = Fields_upload_type.ToString();

            XmlTextWriter textWriter = new XmlTextWriter("config.xml", null);//Объявляем новый экземпляр класса XmlTextWriter, наз. textWriter
            textWriter.Formatting = Formatting.Indented;//Задаём отступы всех элементо XML файла, по умолчанию - 2.

            textWriter.WriteStartDocument();//Записываем начало XML документа с номером версии <1.0>
            textWriter.WriteStartElement("config");//Открываем XML элемент с названием - <config>

            textWriter.WriteStartElement("FilePath");//Открываем внутри незакрытого жлемента <config>, элемент <FilePath>
            textWriter.WriteString(FilePath);//Записываем значение переменной FilePath в открытый элемент.
            textWriter.WriteEndElement();//Закрываем Элемент <FilePath>

            textWriter.WriteStartElement("SMUploadType");//Открываем внутри незакрытого жлемента <config>, элемент <FilePath>
            textWriter.WriteString(SMUploadTypeString);//Записываем значение переменной FilePath в открытый элемент.
            textWriter.WriteEndElement();//Закрываем Элемент <FilePath>

            textWriter.WriteStartElement("FieldsUploadType");//Открываем внутри незакрытого жлемента <config>, элемент <FilePath>
            textWriter.WriteString(FieldsUploadTypeString);//Записываем значение переменной FilePath в открытый элемент.
            textWriter.WriteEndElement();//Закрываем Элемент <FilePath>

            textWriter.WriteEndDocument();//Закрываем все открытые элементы XML(<config>)
            textWriter.Close();//Закрываем файл, сохраняем изменения.

            _dbpath = FilePath;//Переменной FilePath присвоенно значение приватного поля _filePath
            _sm_upload_type = SMUploadTypeString;
        }

        public string DBPath    //Создаём свойство которое даёт возможность считывать и записывать в поле _FilePath значения.
        {
            get { return _dbpath; }  //get - Возвращает значение _FilePath, return - принудительно завершает выполнение и возвращает значение
            set { _dbpath = value; } //set - Присваевает значеия, value - хранит значение.
        }

        public string Sm_upload_type
        {
            get { return _sm_upload_type; }
            set { _sm_upload_type = value; } 
        }

        public string Fields_upload_type
        {
            get {
                    if (_fields_upload_type != null)
                    {
                        return _fields_upload_type;
                    }
                    else
                    {   
                        return _nulltype.ToString();
                    }
                }
            set { _fields_upload_type = value; }
        }
    }
}
