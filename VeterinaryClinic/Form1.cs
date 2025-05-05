using System.Xml.Serialization;

namespace VeterinaryClinic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "XML Files|*.xml";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var serializer = new XmlSerializer(typeof(VeterinaryClinic));
                    using (var fs = new FileStream(ofd.FileName, FileMode.Open))
                    {
                        var clinic = (VeterinaryClinic)serializer.Deserialize(fs);
                        _departments = clinic.Departments;
                        UpdateTreeView();
                    }
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
