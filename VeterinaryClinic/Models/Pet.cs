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
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [XmlElement("TypeOfPet")]
        public TypeOfPet TypeOfPet { get; set; }

        public int VeterinarianId { get; set; }
        public int ClinicDepartmentId { get; set; }

        [XmlIgnore]
        public Veterinarian Veterinarian { get; set; }

        [XmlIgnore]
        public ClinicDepartment ClinicDepartment { get; set; }
    }
}
