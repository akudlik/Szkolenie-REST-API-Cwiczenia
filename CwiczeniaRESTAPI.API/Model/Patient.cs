using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CwiczeniaRESTAPI.API.Model
{
    public class Patient 
    {
        public int Id { get; set; }
        
        public virtual string Name { get; set; }

        public virtual string Surname { get; set; }

        public virtual string IdNumber { get; set; }

        public virtual DateTime Birthday { get; set; }

        public virtual Address HomeAddress { get; set; }

        public virtual Address CorrespondenceAddress { get; set; }

        public virtual string PhoneNumber { get; set; }

        public virtual string EmailAddress { get; set; }
        
        [IgnoreDataMember]
        public virtual IList<MedicalReport> MedicalReports { get; set; }
        
        public virtual bool Active { get; set; }
    }
    public class Address 
    {
        public virtual string Street { get; set; }
 
        public virtual string HouseNo { get; set; }
 
        public virtual string ApartmentNo { get; set; }
 
        public virtual string ZipCode { get; set; }
 
        public virtual string City { get; set; }
    }
}