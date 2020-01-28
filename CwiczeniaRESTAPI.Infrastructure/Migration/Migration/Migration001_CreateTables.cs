using FluentMigrator;

namespace CwiczeniaRESTAPI.Infrastructure.Migration.Migration
{
    [Migration(1, "Create configurator tables")]
    public class Migration001_CreateTables : FluentMigrator.Migration
    {
        public override void Up()
        {
            Create.Table("PATIENT")
                .WithColumn("ID_PATIENT").AsInt32().NotNullable().PrimaryKey().Identity().WithColumnDescription("ID, PRIMARY KEY")
                .WithColumn("FIRSTNAME").AsString(100).NotNullable()
                .WithColumn("SURNAME").AsString(100).NotNullable()
                .WithColumn("IDNUMBER").AsString(20).Nullable()
                .WithColumn("BIRTHDAY").AsDate().Nullable()
                .WithColumn("PHONENUMBER").AsString(20).Nullable()
                .WithColumn("EMAILADDRESS").AsString(100).Nullable()
                .WithColumn("ACTIVE").AsByte().Nullable()
                .WithColumn("CORRESPONDENCE_STREET").AsString(100).Nullable()
                .WithColumn("CORRESPONDENCE_HOUSENO").AsString(20).Nullable()
                .WithColumn("CORRESPONDENCE_APARTMENTNO").AsString(20).Nullable()
                .WithColumn("CORRESPONDENCE_ZIPCODE").AsString(20).Nullable()
                .WithColumn("CORRESPONDENCE_CITY").AsString(100).Nullable()
                .WithColumn("HOME_STREET").AsString(100).Nullable()
                .WithColumn("HOME_HOUSENO").AsString(20).Nullable()
                .WithColumn("HOME_APARTMENTNO").AsString(20).Nullable()
                .WithColumn("HOME_ZIPCODE").AsString(20).Nullable()
                .WithColumn("HOME_CITY").AsString(100).Nullable();

            Create.Table("MEDICAL_REPORTS")
                .WithColumn("ID_REPORTS").AsInt32().NotNullable().PrimaryKey().Identity().WithColumnDescription("ID, PRIMARY KEY")
                .WithColumn("DATE").AsDateTime2().NotNullable()
                .WithColumn("PATIENT_ID").AsInt32().NotNullable()
                .WithColumn("DOCTOR_ID").AsInt32().NotNullable()
                .WithColumn("BLOODRESULT").AsString(100).Nullable()
                .WithColumn("CMM").AsString(100).Nullable()
                .WithColumn("FL").AsString(100).Nullable()
                .WithColumn("GDL").AsString(100).Nullable()
                .WithColumn("IUL").AsString(100).Nullable()
                .WithColumn("MGDL").AsInt32().Nullable()
                .WithColumn("CBC").AsInt32().Nullable()
                .WithColumn("WBC").AsInt32().Nullable()
                .WithColumn("RBC").AsInt32().Nullable();
            
            Create.Table("DOCTOR")
                .WithColumn("ID_DOCTOR").AsInt32().NotNullable().PrimaryKey().Identity().WithColumnDescription("ID, PRIMARY KEY")
                .WithColumn("FIRSTNAME").AsString(100).NotNullable()
                .WithColumn("SURNAME").AsString(100).NotNullable()
                .WithColumn("PHONENUMBER").AsString(20).Nullable()
                .WithColumn("EMAILADDRESS").AsString(100).Nullable()
                .WithColumn("ACTIVE").AsByte().Nullable()
                .WithColumn("SPECIALITY").AsString(100).Nullable();
        }

        public override void Down()
        {
            Delete.Table("PATIENT");
            Delete.Table("DOCTOR");
            Delete.Table("MEDICAL_REPORTS");
        }
    }
}