using System;
using System.Collections.Generic;
using System.Linq;
using CwiczeniaRESTAPI.AggregatesModel.PatientAggregate;
using CwiczeniaRESTAPI.SeedWork;

namespace CwiczeniaRESTAPI.Infrastructure.Repositories.InMemory
{
    public class PatientRepositoryInMemory : IPatientRepository
    {
        private static IList<Patient> _list = SimpleData();

        private static List<Patient> SimpleData()
        {
            return new List<Patient>
            {
                new Patient
                {
                    Id = 1,
                    Active = true,
                    Name = "Patient1",
                    Surname = "SSPatient1",
                    EmailAddress = "Patient1@doctor.pl",
                    PhoneNumber = "529498492852",
                    Birthday = DateTime.Parse("1999-01-01"),
                    IdNumber = "949292993",
                    CorrespondenceAddress = new Address
                    {
                        City = "New York",
                        Street = "Street1",
                        ApartmentNo = "1",
                        HouseNo = "",
                        ZipCode = "00-123"
                    }
                },
                new Patient
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
                new Patient
                {
                    Id = 3,
                    Active = false,
                    Name = "Patient3",
                    Surname = "SSPatient3",
                    EmailAddress = "Patient3@doctor.pl",
                    PhoneNumber = "0101010101010",
                    Birthday = DateTime.Parse("1956-07-01"),
                    IdNumber = "0904980592",
                    CorrespondenceAddress = new Address
                    {
                        City = "New York",
                        Street = "Street2",
                        ApartmentNo = "13",
                        HouseNo = "13",
                        ZipCode = "01-000"
                    }
                },
                new Patient
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
            };
        }

        public Result<IEnumerable<Patient>> GetListOfPatients(int pageSize, int pageNumber)
        {
            var list = _list.Skip(pageNumber * pageSize).Take(pageSize);
            return Result<IEnumerable<Patient>>.Ok(list);
        }

        public Result<Patient> GetOnePatient(int id)
        {
            return Result<Patient>.Ok(_list.FirstOrDefault(s => s.Id == id));
        }

        public Result<Patient> CreatePatient(Patient patient)
        {
            var highestId = _list.Any() ? _list.Select(x => x.Id).Max() : 1;
            patient.Id = highestId + 1;
            _list.Add(patient);

            return Result<Patient>.Ok(patient);
        }

        public Result<Patient> UpdatePatient(Patient patient)
        {
            var result = _list.FirstOrDefault(s => s.Id == patient.Id);
            _list.Remove(result);
            _list.Add(patient);
            return Result<Patient>.Ok(patient);
        }

        public Result DeletePatient(int id)
        {
            var result = _list.FirstOrDefault(s => s.Id == id);
            _list.Remove(result);

            return Result.Ok();
        }

        public IUnitOfWork UnitOfWork { get; }
    }
}