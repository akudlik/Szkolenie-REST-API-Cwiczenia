using System;
using System.Collections.Generic;
using System.Linq;
using CwiczeniaRESTAPI.AggregatesModel.DoctorAggregate;
using CwiczeniaRESTAPI.AggregatesModel.MedicalReportAggregate;
using CwiczeniaRESTAPI.AggregatesModel.PatientAggregate;
using CwiczeniaRESTAPI.SeedWork;

namespace CwiczeniaRESTAPI.Infrastructure.Repositories.InMemory
{
    public class MedicalReportRepositoryInMemory : IMedicalReportRepository
    {
        private static IList<MedicalReport> _list = SimpleData();

        private static List<MedicalReport> SimpleData()
        {
            return new List<MedicalReport>
            {
                new MedicalReport
                {
                    Id = 1,
                    Date = DateTime.Today,
                    BloodResult = "dasdasda",
                    FL = "dasd",
                    CBC = 321,
                    CMM = "dasd",
                    GDL = "dasd",
                    IUL = "dasd",
                    RBC = 123,
                    WBC = 123,
                    MGDL =123,
                    Doctor = new Doctor
                    {
                        Id = 3,
                        Active = true,
                        Name = "Doctor3",
                        Surname = "Dolittle",
                        Speciality = "Dentist",
                        EmailAddress = "Doctor3@doctor.pl",
                        PhoneNumber = "93819129529"
                    },
                    Patient = new Patient
                    {
                        Id = 4,
                        Active = true,
                        Name = "Patient4",
                        Surname = "SSPatient4",
                        EmailAddress = "Patient4@doctor.pl",
                        PhoneNumber = "9099520",
                        Birthday = DateTime.Parse("1994-10-31"),
                        IdNumber = "198059029",
                        CorrespondenceAddress = new Address
                        {
                            City = "Warsaw",
                            Street = "Street1",
                            ApartmentNo = "1",
                            HouseNo = "",
                            ZipCode = "00-000"
                        }
                    }
                },
                new MedicalReport
                {
                    Id = 2,
                    Date = DateTime.Today.AddYears(-2),
                    BloodResult = "231345645",
                    FL = "ljkljkljkl",
                    CBC = 1312,
                    CMM = "jkljkl",
                    GDL = "daljklsdasdsad",
                    IUL = "645546",
                    RBC = 33,
                    WBC = 654645,
                    MGDL =5161982,
                    Patient = new Patient
                    {
                        Id = 4,
                        Active = true,
                        Name = "Patient4",
                        Surname = "SSPatient4",
                        EmailAddress = "Patient4@doctor.pl",
                        PhoneNumber = "9099520",
                        Birthday = DateTime.Parse("1994-10-31"),
                        IdNumber = "198059029",
                        CorrespondenceAddress = new Address
                        {
                            City = "Warsaw",
                            Street = "Street1",
                            ApartmentNo = "1",
                            HouseNo = "",
                            ZipCode = "00-000"
                        }
                    },
                    Doctor = new Doctor
                    {
                        Id = 1,
                        Active = true,
                        Name = "Doctor1",
                        Surname = "Dolittle",
                        Speciality = "Dentist",
                        EmailAddress = "Doctor1@doctor.pl",
                        PhoneNumber = "0101010101010"
                    },
                },
                new MedicalReport
                {
                    Id = 3,
                    Date = DateTime.Today.AddDays(-65),
                    BloodResult = "gfhgfhgfhgfh",
                    FL = "dahgfh1gfhsd",
                    CBC = 123,
                    CMM = "dafhgfhgfhsd",
                    GDL = "daf2hgfhsd",
                    IUL = "dfghgfhgfhasd",
                    RBC = 312,
                    WBC = 55,
                    MGDL = 1313,
                    Patient = new Patient
                    {
                        Id = 2,
                        Active = true,
                        Name = "Patient2",
                        Surname = "SSPatient2",
                        EmailAddress = "Patient2@doctor.pl",
                        PhoneNumber = "908402892",
                        Birthday = DateTime.Parse("1985-10-21"),
                        IdNumber = "6001010101010",
                        CorrespondenceAddress = new Address
                        {
                            City = "Las Vegas",
                            Street = "Vegased",
                            ApartmentNo = "12",
                            HouseNo = "123456",
                            ZipCode = "02-000"
                        }
                    },
                    Doctor = new Doctor
                    {
                        Id = 1,
                        Active = true,
                        Name = "Doctor1",
                        Surname = "Dolittle",
                        Speciality = "Dentist",
                        EmailAddress = "Doctor1@doctor.pl",
                        PhoneNumber = "0101010101010"
                    },
                },
            };
        }

        public Result<IEnumerable<MedicalReport>> GetListOfMedicalReports(int pageSize, int pageNumber)
        {
            var list = _list.Skip(pageNumber * pageSize).Take(pageSize);
            return Result<IEnumerable<MedicalReport>>.Ok(list);
        }

        public Result<MedicalReport> GetOneMedicalReport(int id)
        {
            return Result<MedicalReport>.Ok(_list.FirstOrDefault(s => s.Id == id));
        }

        public Result<MedicalReport> CreateMedicalReport(MedicalReport MedicalReport)
        {
            var highestId = _list.Any() ? _list.Select(x => x.Id).Max() : 1;
            MedicalReport.Id = highestId + 1;
            _list.Add(MedicalReport);

            return Result<MedicalReport>.Ok(MedicalReport);
        }

        public Result<MedicalReport> UpdateMedicalReport(MedicalReport MedicalReport)
        {
            var result = _list.FirstOrDefault(s => s.Id == MedicalReport.Id);
            _list.Remove(result);
            _list.Add(MedicalReport);
            return Result<MedicalReport>.Ok(MedicalReport);
        }

        public Result DeleteMedicalReport(int id)
        {
            var result = _list.FirstOrDefault(s => s.Id == id);
            _list.Remove(result);

            return Result.Ok();
        }

        public IUnitOfWork UnitOfWork { get; }
    }
}