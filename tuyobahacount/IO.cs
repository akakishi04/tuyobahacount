using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using tuyobahacount.DataModel;

namespace tuyobahacount
{
    public class IO
    {

        public static void SaveData<T>(string filePath, T data)
        {


            var serializer = new XmlSerializer(typeof(T));
            using (var writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, data);
            }
        }

        public static DataModelContainer LoadDataModelFromXml(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(DataModelContainer));

            using (StreamReader reader = new StreamReader(filePath))
            {
                return (DataModelContainer)serializer.Deserialize(reader);
                Debug.WriteLine($"loading...");
            }
        }
        public static void WriteToCsv(string filename, string data)
        {
            using (StreamWriter sw = new StreamWriter(filename, true))
            {
                sw.WriteLine(data);
            }
        }
        public static void RemoveLastLine(string filePath)
        {
            var lines = File.ReadAllLines(filePath).ToList();
            if (lines.Count > 0)
            {
                lines.RemoveAt(lines.Count - 1); // 最終行を削除
                File.WriteAllLines(filePath, lines); // ファイルに書き戻す
            }
        }
    }
}
