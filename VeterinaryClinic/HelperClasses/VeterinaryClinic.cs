using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using VeterinaryClinic.AbstractModels;

namespace VeterinaryClinic.HelperClasses
{
    [XmlRoot("VeterinaryClinic")]
    public class VeterinaryClinic
    {
        [XmlArray("Departments")]
        [XmlArrayItem("ClinicDepartment")]
        public List<ClinicDepartment> Departments { get; set; } = new List<ClinicDepartment>();
    }
}
