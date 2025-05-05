using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using VeterinaryClinic.Enums;

namespace VeterinaryClinic.AbstractModels
{
    public class ClinicDepartment
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public TypeOfPet SpecializationDepartment { get; set; }
        public List<Veterinarian> Veterinarians { get; set; } = new List<Veterinarian>();
        public List<Pet> Pets { get; set; } = new List<Pet>();
    }
}
