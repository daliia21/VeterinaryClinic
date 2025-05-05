using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using VeterinaryClinic.Enums;

namespace VeterinaryClinic.AbstractModels
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public TypeOfPet TypeOfPet { get; set; }

        public int VeterinarianId { get; set; }
        public int ClinicDepartmentId { get; set; }

        public Veterinarian Veterinarian { get; set; }

        public ClinicDepartment ClinicDepartment { get; set; }
    }
}
