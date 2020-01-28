using CwiczeniaRESTAPI.AggregatesModel.DoctorAggregate;
using FluentNHibernate.Mapping;

namespace CwiczeniaRESTAPI.Infrastructure.ClassMaping
{
    public class DoctorMap: ClassMap<Doctor>
    {
        public DoctorMap()
        {
            Table("DOCTOR");

            Id(doctor => doctor.Id).Column("ID_DOCTOR").GeneratedBy.Identity();

            Map(doctor => doctor.Name).Column("FIRSTNAME").Length(100).Not.Nullable();
            Map(doctor => doctor.Surname).Column("SURNAME").Length(100).Not.Nullable();
            Map(doctor => doctor.Speciality).Column("SPECIALITY").Length(20);
            Map(doctor => doctor.PhoneNumber).Column("PHONENUMBER").Length(20);
            Map(doctor => doctor.EmailAddress).Column("EMAILADDRESS").Length(100);
            Map(doctor => doctor.Active).Column("ACTIVE");

            HasMany(doctor => doctor.MedicalReports)
                .KeyColumn("DOCTOR_ID").Inverse().Not.LazyLoad().Cascade.All();;

        }
    }

}