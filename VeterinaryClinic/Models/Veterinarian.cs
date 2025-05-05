using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using VeterinaryClinic.Enums;

namespace VeterinaryClinic.AbstractModels
{
    public class Veterinarian
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public TypeOfPet Specialization { get; set; }

        public int ClinicDepartmentId { get; set; }

        public ClinicDepartment ClinicDepartment { get; set; }

        public List<Pet> Pets { get; set; } = new List<Pet>();
    }
}
