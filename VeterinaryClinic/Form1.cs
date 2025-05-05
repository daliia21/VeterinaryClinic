using Newtonsoft.Json;
using System.Windows.Forms;
using System.Xml.Serialization;
using VeterinaryClinic.AbstractModels;
using VeterinaryClinic.DataBase;
using VeterinaryClinic.Models;


namespace VeterinaryClinic
{


    public partial class Form1 : Form
    {
        private List<ClinicDepartment> _departments = new List<ClinicDepartment>();

        public Form1()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            splitContainer1.Panel1.Controls.Add(treeView1);
            splitContainer1.Panel2.Controls.Add(dataGridView1);
            button1.Click += BtnImportXml_Click;
            button2.Click += BtnImportJson_Click;
            button3.Click += BtnSaveDb_Click;
            treeView1.NodeMouseDoubleClick += TreeView_NodeMouseDoubleClick;
        }

        private void BtnImportXml_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "XML Files|*.xml";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var serializer = new XmlSerializer(typeof(VeterinaryClinics));
                    using (var fs = File.OpenRead(ofd.FileName))
                    {
                        var clinic = (VeterinaryClinics)serializer.Deserialize(fs);
                        _departments = clinic.Departments;
                        UpdateTreeView();
                        UpdateDataGrid(_departments);
                    }
                }
            }
        }

        private void BtnImportJson_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "JSON Files|*.json";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var json = File.ReadAllText(ofd.FileName);
                    var clinic = JsonConvert.DeserializeObject<VeterinaryClinics>(json);
                    _departments = clinic.Departments;
                    UpdateTreeView();
                    UpdateDataGrid(_departments);
                }
            }
        }

        private void UpdateTreeView()
        {
            treeView1.Nodes.Clear();
            var rootNode = new TreeNode("Ветеринарная клиника");

            foreach (var department in _departments)
            {
                var depNode = new TreeNode(department.DepartmentName) { Tag = department };

                var vetsNode = new TreeNode("Ветеринары");
                foreach (var vet in department.Veterinarians)
                    vetsNode.Nodes.Add(new TreeNode(vet.Name) { Tag = vet });

                var petsNode = new TreeNode("Питомцы");
                foreach (var pet in department.Pets)
                    petsNode.Nodes.Add(new TreeNode(pet.Name) { Tag = pet });

                depNode.Nodes.Add(vetsNode);
                depNode.Nodes.Add(petsNode);
                rootNode.Nodes.Add(depNode);
            }

            treeView1.Nodes.Add(rootNode);
            treeView1.ExpandAll();
        }

        private void UpdateDataGrid(IEnumerable<object> data)
        {
            dataGridView1.DataSource = data.ToList();
            dataGridView1.AutoResizeColumns();
        }

        private void BtnSaveDb_Click(object sender, EventArgs e)
        {
            using (var db = new AppDbContext())
            {

                foreach (var dep in _departments)
                {
                    db.Departments.Add(dep);
                    db.Veterinarians.AddRange(dep.Veterinarians);
                    db.Pets.AddRange(dep.Pets);
                }

                db.SaveChanges();
                MessageBox.Show("Данные сохранены в БД!");
            }
        }

        private void TreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var detailsForm = new DetailsForm();
            detailsForm.ShowDetails(e.Node.Tag);
            detailsForm.Show();
        }




        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}

