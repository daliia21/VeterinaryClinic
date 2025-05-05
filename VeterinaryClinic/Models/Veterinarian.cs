using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using VeterinaryClinic.Enums;
using VeterinaryClinic.Models;

namespace VeterinaryClinic.AbstractModels
{
    public class Veterinarian
    {
        public int ClinicDepartmentId { get; set; }
        public ClinicDepartment ClinicDepartment { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public TypeOfPet Specialization { get; set; }
        public List<Pet> Pets { get; set; } = new List<Pet>();
        public VeterinarianContactInfo Contact { get; set; }

    }
}
