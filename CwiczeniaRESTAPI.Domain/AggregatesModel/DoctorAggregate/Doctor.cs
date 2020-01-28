using System.Collections.Generic;
using System.Runtime.Serialization;
using CwiczeniaRESTAPI.AggregatesModel.MedicalReportAggregate;
using CwiczeniaRESTAPI.SeedWork;

namespace CwiczeniaRESTAPI.AggregatesModel.DoctorAggregate
{
    public class Doctor : Entity, IAggregateRoot
    {
        public virtual string Name { get; set; }

        public virtual string Surname { get; set; }

        public virtual string Speciality { get; set; }

        public virtual string PhoneNumber { get; set; }

        public virtual string EmailAddress { get; set; }

        public virtual bool Active { get; set; }
        
        [IgnoreDataMember]
        public virtual ICollection<MedicalReport> MedicalReports { get; set; }
    }
}