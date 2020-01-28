using System.Collections.Generic;
using System.Linq;
using CwiczeniaRESTAPI.AggregatesModel.DoctorAggregate;
using CwiczeniaRESTAPI.SeedWork;

namespace CwiczeniaRESTAPI.Infrastructure.Repositories.InMemory
{
    public class DoctorRepositoryInMemory:IDoctorRepository
    {
        private static IList<Doctor> _list = SimpleData();

        private static List<Doctor> SimpleData()
        {
            return new List<Doctor>
            {
                new Doctor
                {
                    Id = 1,
                    Active = true,
                    Name = "Doctor1",
                    Surname = "Dolittle",
                    Speciality = "Dentist",
                    EmailAddress = "Doctor1@doctor.pl",
                    PhoneNumber = "0101010101010"
                },
                new Doctor
                {
                    Id = 2,
                    Active = true,
                    Name = "Doctor2",
                    Surname = "Dolittle",
                    Speciality = "Dentist",
                    EmailAddress = "Doctor2@doctor.pl",
                    PhoneNumber = "1549161951"
                },
                new Doctor
                {
                    Id = 3,
                    Active = true,
                    Name = "Doctor3",
                    Surname = "Dolittle",
                    Speciality = "Dentist",
                    EmailAddress = "Doctor3@doctor.pl",
                    PhoneNumber = "93819129529"
                },
                new Doctor
                {
                    Id = 4,
                    Active = false,
                    Name = "Doctor4",
                    Surname = "Dolittle",
                    Speciality = "Dentist",
                    EmailAddress = "Doctor4@doctor.pl",
                    PhoneNumber = "0609405984"
                },new Doctor
                {
                    Id = 5,
                    Active = true,
                    Name = "Doctor5",
                    Surname = "Dolittle",
                    Speciality = "Dentist",
                    EmailAddress = "Doctor5@doctor.pl",
                    PhoneNumber = "8977119"
                }
            
            };
        }

        public Result<IEnumerable<Doctor>> GetListOfDoctors(int pageSize, int pageNumber)
        {
            var list = _list.Skip(pageNumber * pageSize).Take(pageSize);
            return Result<IEnumerable<Doctor>>.Ok(list);
        }

        public Result<Doctor> GetOneDoctor(int id)
        {
            return Result<Doctor>.Ok(_list.FirstOrDefault(s => s.Id == id));
        }

        public Result<Doctor> CreateDoctor(Doctor Doctor)
        {
            var highestId = _list.Any() ? _list.Select(x => x.Id).Max() : 1;
            Doctor.Id = highestId + 1;
            _list.Add(Doctor);

            return Result<Doctor>.Ok(Doctor);
        }

        public Result<Doctor> UpdateDoctor(Doctor Doctor)
        {
            var result = _list.FirstOrDefault(s => s.Id == Doctor.Id);
            _list.Remove(result);
            _list.Add(Doctor);
            return Result<Doctor>.Ok(Doctor);
        }

        public Result DeleteDoctor(int id)
        {
            var result = _list.FirstOrDefault(s => s.Id == id);
            _list.Remove(result);

            return Result.Ok();
        }

        public IUnitOfWork UnitOfWork { get; }
    }
}