using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VeterinaryClinic.AbstractModels;

namespace VeterinaryClinic
{
    public partial class DetailsForm : Form
    {

        private PictureBox pictureBox;
        private Panel detailsPanel;
        public DetailsForm()
        {
            InitializeComponent();
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            // Основные настройки формы
            this.Size = new Size(600, 400);
            this.StartPosition = FormStartPosition.CenterParent;

            // Создание элементов управления
            var splitContainer = new SplitContainer
            {
                Dock = DockStyle.Fill,
                SplitterDistance = 200
            };

            pictureBox = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.Zoom
            };

            detailsPanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };

            splitContainer.Panel1.Controls.Add(pictureBox);
            splitContainer.Panel2.Controls.Add(detailsPanel);
            this.Controls.Add(splitContainer);
        }

        public void ShowDetails(object entity)
        {
            
            detailsPanel.Controls.Clear();

            var y = 10;
            foreach (var prop in entity.GetType().GetProperties())
            {
                if (prop.Name == "Image") continue;

                var label = new Label
                {
                    Text = GetDisplayName(prop.Name),
                    Location = new Point(10, y),
                    Width = 180,
                    Font = new Font("Arial", 9, FontStyle.Bold)
                };

                var value = prop.GetValue(entity)?.ToString() ?? "-";

                if (prop.PropertyType == typeof(Veterinarian))
                    value = ((Veterinarian)prop.GetValue(entity))?.Name;
                else if (prop.PropertyType == typeof(ClinicDepartment))
                    value = ((ClinicDepartment)prop.GetValue(entity))?.DepartmentName;

                var valueLabel = new Label
                {
                    Text = value,
                    Location = new Point(200, y),
                    Width = 350,
                    Font = new Font("Arial", 9)
                };

                detailsPanel.Controls.Add(label);
                detailsPanel.Controls.Add(valueLabel);
                y += 30;
            }

            this.Text = $"{entity.GetType().Name} Details";
            this.Show();
        }

        private string GetDisplayName(string propertyName)
        {
            var names = new Dictionary<string, string>
        {
            {"Id", "ID"},
            {"DepartmentName", "Название отделения"},
            {"SpecializationDepartment", "Специализация"},
            {"Veterinarians", "Ветеринары"},
            {"Pets", "Питомцы"},
            {"Name", "Имя"},
            {"TypeOfPet", "Тип животного"},
            {"VeterinarianId", "ID ветеринара"},
            {"ClinicDepartmentId", "ID отделения"},
            {"Specialization", "Специализация"},
            {"ClinicDepartment", "Отделение"},
            {"Veterinarian", "Ветеринар"}
        };

            return names.TryGetValue(propertyName, out var value) ? value : propertyName;
        }

        private void LoadImage(object entity)
        {
            try
            {
                var imagePath = Path.Combine(Application.StartupPath, "images", $"{entity.GetType().Name}.jpg");
                pictureBox.Image = File.Exists(imagePath)
                    ? Image.FromFile(imagePath)
                    : Image.FromFile("default.jpg");
            }
            catch
            {
                pictureBox.Image = CreateDefaultImage();
            }
        }

        private Bitmap CreateDefaultImage()
        {
            var bmp = new Bitmap(200, 200);
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.LightGray);
                g.DrawString("No Image",
                    new Font("Arial", 16),
                    Brushes.Black,
                    new PointF(50, 80));
            }
            return bmp;
        }

        
    }
}
