using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using VeterinaryClinic.Enums;
using VeterinaryClinic.Models;

namespace VeterinaryClinic.AbstractModels
{
    [Serializable]
    public class Veterinarian
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [XmlElement("Specialization")]
        public TypeOfPet Specialization { get; set; }

        [XmlElement("VeterinarianContactInfo")]
        public VeterinarianContactInfo VeterinarianContactInfo { get; set; }

        public int ClinicDepartmentId { get; set; }

        [XmlIgnore]
        public ClinicDepartment ClinicDepartment { get; set; }

        [XmlIgnore]
        public List<Pet> Pets { get; set; } = new List<Pet>();
    }
}
