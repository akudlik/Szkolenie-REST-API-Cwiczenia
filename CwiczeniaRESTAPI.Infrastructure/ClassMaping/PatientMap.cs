using CwiczeniaRESTAPI.AggregatesModel.PatientAggregate;
using FluentNHibernate.Mapping;

namespace CwiczeniaRESTAPI.Infrastructure.ClassMaping
{
    public class PatientMap: ClassMap<Patient>
    {
        public PatientMap()
        {
            Table("PATIENT");

            Id(patient => patient.Id).Column("ID_PATIENT").GeneratedBy.Identity();

            Map(patient => patient.Name).Column("FIRSTNAME").Length(100).Not.Nullable();
            Map(patient => patient.Surname).Column("SURNAME").Length(100).Not.Nullable();
            Map(patient => patient.IdNumber).Column("IDNUMBER").Length(20);
            Map(patient => patient.Birthday).Column("BIRTHDAY");
            Map(patient => patient.PhoneNumber).Column("PHONENUMBER").Length(20);
            Map(patient => patient.EmailAddress).Column("EMAILADDRESS").Length(100);
            Map(patient => patient.Active).Column("ACTIVE");

            Component(x => x.CorrespondenceAddress, m =>
            {
                m.Map(c => c.Street).Column("CORRESPONDENCE_STREET").Length(100);
                m.Map(c => c.HouseNo).Column("CORRESPONDENCE_HOUSENO").Length(20);
                m.Map(c => c.ApartmentNo).Column("CORRESPONDENCE_APARTMENTNO").Length(20);
                m.Map(c => c.ZipCode).Column("CORRESPONDENCE_ZIPCODE").Length(20);
                m.Map(c => c.City).Column("CORRESPONDENCE_CITY").Length(100);
            });
            Component(x => x.HomeAddress, m =>
            {
                m.Map(c => c.Street).Column("HOME_STREET").Length(100);
                m.Map(c => c.HouseNo).Column("HOME_HOUSENO").Length(20);
                m.Map(c => c.ApartmentNo).Column("HOME_APARTMENTNO").Length(20);
                m.Map(c => c.ZipCode).Column("HOME_ZIPCODE").Length(20);
                m.Map(c => c.City).Column("HOME_CITY").Length(100);
            });
            
            HasMany(doctor => doctor.MedicalReports)
                .KeyColumn("PATIENT_ID").Inverse().Not.LazyLoad().Cascade.All();;
        }
    }

}