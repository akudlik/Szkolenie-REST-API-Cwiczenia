using System;
using CwiczeniaRESTAPI.SeedWork;

namespace CwiczeniaRESTAPI.AggregatesModel.PatientAggregate
{
    public class Patient : Entity, IAggregateRoot
    {
        public string Name { get; set; }
        
        public string Surname { get; set; }
        
        public string IdNumber { get; set; }
        
        public DateTime Birthday { get; set; }
        
        public Address HomeAddress { get; set; }
        
        public Address CorrespondenceAddress { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public string EmailAddress { get; set; }
    }

    public abstract class Address
    {
        public string Street { get; set; }
        
        public string HouseNo { get; set; }
        
        public string ApartmentNo { get; set; }
        
        public string ZipCode { get; set; }
        
        public string City { get; set; }
    }
}