using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CwiczeniaRESTAPI.API.Model
{
    public class Doctor
    {
        public int Id { get; set; }
        
        public virtual string Name { get; set; }

        public virtual string Surname { get; set; }

        public virtual string Speciality { get; set; }

        public virtual string PhoneNumber { get; set; }

        public virtual string EmailAddress { get; set; }

        public virtual bool Active { get; set; }
        
        [IgnoreDataMember]
        public virtual IList<MedicalReport> MedicalReports { get; set; }
    }
}