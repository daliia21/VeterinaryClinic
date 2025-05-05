using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using VeterinaryClinic.Enums;

namespace VeterinaryClinic.AbstractModels
{
    [Serializable]
    public class ClinicDepartment
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }

        [XmlElement("SpecializationDepartment")]
        public TypeOfPet SpecializationDepartment { get; set; }

        [XmlArray("Veterinarians")]
        [XmlArrayItem("Veterinarian")]
        public List<Veterinarian> Veterinarians { get; set; } = new List<Veterinarian>();

        [XmlArray("Pets")]
        [XmlArrayItem("Pet")]
        public List<Pet> Pets { get; set; } = new List<Pet>();
    }
}
