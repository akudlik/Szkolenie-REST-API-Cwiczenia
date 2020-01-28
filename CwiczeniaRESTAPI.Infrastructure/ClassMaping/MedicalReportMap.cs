using CwiczeniaRESTAPI.AggregatesModel.MedicalReportAggregate;
using FluentNHibernate.Mapping;

namespace CwiczeniaRESTAPI.Infrastructure.ClassMaping
{
    public class MedicalReportMap : ClassMap<MedicalReport>
    {
        public MedicalReportMap()
        {
            Table("MEDICAL_REPORTS");

            Id(medical => medical.Id).Column("ID_REPORTS").GeneratedBy.Identity();
            Map(medical => medical.Date).Column("DATE");
            Map(medical => medical.BloodResult).Column("BLOODRESULT").Length(100).Nullable();
            Map(medical => medical.CMM).Column("CMM").Length(100).Nullable();
            Map(medical => medical.FL).Column("FL").Length(100).Nullable();
            Map(medical => medical.GDL).Column("GDL").Length(100).Nullable();
            Map(medical => medical.IUL).Column("IUL").Length(100).Nullable();
            Map(medical => medical.MGDL).Column("MGDL").Nullable();
            Map(medical => medical.CBC).Column("CBC").Nullable();
            Map(medical => medical.WBC).Column("WBC").Nullable();
            Map(medical => medical.RBC).Column("RBC").Nullable();

            References(medical => medical.Patient, "PATIENT_ID").Cascade.None();
            ;
            References(medical => medical.Doctor, "DOCTOR_ID").Cascade.None();
            ;
        }
    }
}