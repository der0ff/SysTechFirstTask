using System.Windows;
using System.Xml;
using System;
using System.Linq;
using System.Text;

namespace SysTechFirstTask
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BrowseXmlFile(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog
            {
                CheckFileExists = true,
                Filter = "XML Files (*.xml)|*.xml|All Files(*.*)|*.*",
                Multiselect = false
            };

            if (dlg.ShowDialog() != true) { return; }

            XmlDocument XMLdoc = new XmlDocument();
            try
            {
                XMLdoc.Load(dlg.FileName);
            }
            catch (XmlException)
            {
                MessageBox.Show("The XML file is invalid");
                return;
            }

            txtFilePath.Text = dlg.FileName;
            vXMLViwer.xmlDocument = XMLdoc;
        }

        private void ClearXmlFile(object sender, RoutedEventArgs e)
        {
            txtFilePath.Text = string.Empty;
            vXMLViwer.xmlDocument = null;
        }

        private void RunXPath_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(xPathValue.Text))
                    throw new System.Exception("xPath is invalid");
                if (vXMLViwer.xmlDocument==null)
                    throw new System.Exception("Select XML file");
                var navigator = vXMLViwer.xmlDocument.CreateNavigator();
                var result = navigator.Evaluate(xPathValue.Text);
                MessageBox.Show("Result = " + result.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }
    }
}
