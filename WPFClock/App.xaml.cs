using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Windows.Media;

namespace WPFClock
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public string Location { get; set; } = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            System.Reflection.Assembly.GetExecutingAssembly().EntryPoint.DeclaringType.Namespace);
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            ImportFile("Settings.xml", typeof(Settings), "Settings");
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            SaveFile("Settings.xml", typeof(Settings), "Settings");
        }
        private void ImportFile(string fileName, Type objectType, string resourceName)
        {
            string _fileName = Path.Combine(Location, fileName);
            if (!File.Exists(_fileName))
            {
                return;
            }
            FileStream fs = new FileStream(_fileName, FileMode.Open);
            DataContractSerializer ser = new DataContractSerializer(objectType);
            using (var reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas()))
            {
                var obj = ser.ReadObject(reader, true);
                Application.Current.Resources[resourceName] = obj;
            }
        }
        private void SaveFile(string fileName, Type objectType, string resourceName)
        {
            var _fileName = Path.Combine(Location, fileName);
            if (!Directory.Exists(Location))
            {
                Directory.CreateDirectory(Location);
            }
            var obj = Application.Current.Resources[resourceName];
            DataContractSerializer ser = new DataContractSerializer(objectType);
            var xmlSettings = new XmlWriterSettings { Indent = true, IndentChars = "\t" };
            using (var writer = XmlWriter.Create(_fileName, xmlSettings))
            {
                ser.WriteObject(writer, obj);
            }
        }
    }
}
