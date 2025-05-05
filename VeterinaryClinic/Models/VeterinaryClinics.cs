using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using VeterinaryClinic.AbstractModels;

namespace VeterinaryClinic.Models
{
    [XmlRoot("VeterinaryClinic")]
    public class VeterinaryClinics
    {

        public List<ClinicDepartment> Departments { get; set; }

       
    }
}
