using System.Windows.Controls;
using System.Windows.Data;
using System.Xml;

namespace SysTechFirstTask
{
    public partial class Viewer : UserControl
    {
        private XmlDocument _xmldocument;
        public Viewer()
        {
            InitializeComponent();
        }

        public XmlDocument xmlDocument
        {
            get { return _xmldocument; }
            set
            {
                _xmldocument = value;
                BindXMLDocument();
            }
        }

        private void BindXMLDocument()
        {
            if (_xmldocument == null)
            {
                xmlTree.ItemsSource = null;
                return;
            }

            XmlDataProvider provider = new XmlDataProvider();
            provider.Document = _xmldocument;
            Binding binding = new Binding
            {
                Source = provider,
                XPath = "child::node()"
            };
            xmlTree.SetBinding(ItemsControl.ItemsSourceProperty, binding);
        }
    }
}
