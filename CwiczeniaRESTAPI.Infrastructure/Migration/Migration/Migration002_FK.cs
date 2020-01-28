using FluentMigrator;

namespace CwiczeniaRESTAPI.Infrastructure.Migration.Migration
{
    [Migration(2, "Create FK")]
    public class Migration002_FK : FluentMigrator.Migration
    {
        public override void Up()
        {
            Create.ForeignKey("FK_MEDICAL_REPORTS_PATIENT")
                .FromTable("MEDICAL_REPORTS").ForeignColumn("PATIENT_ID")
                .ToTable("PATIENT").PrimaryColumn("ID_PATIENT");
            
            Create.ForeignKey("FK_MEDICAL_REPORTS_DOCTOR")
                .FromTable("MEDICAL_REPORTS").ForeignColumn("DOCTOR_ID")
                .ToTable("DOCTOR").PrimaryColumn("ID_DOCTOR");

        }

        public override void Down()
        {
            Delete.ForeignKey("FK_MEDICAL_REPORTS_PATIENT");
            Delete.ForeignKey("FK_MEDICAL_REPORTS_DOCTOR");

        }
    }
}