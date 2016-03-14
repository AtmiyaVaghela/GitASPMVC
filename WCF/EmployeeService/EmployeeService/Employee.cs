using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace EmployeeService
{
    [DataContract(Namespace ="http://atmiya.com/2016/03/14")]
    public class Employee
    {
        [DataMember(Name ="ID",Order = 1)]
        public int Id { get; set; }
        [DataMember(Name = "NAME", Order = 2)]
        public string Name { get; set; }
        [DataMember(Name = "GENDER", Order = 3)]
        public string Gender { get; set; }
        [DataMember(Name = "DATEOFBIRTH", Order = 4)]
        public DateTime DateOfBirth { get; set; }
    }
}
