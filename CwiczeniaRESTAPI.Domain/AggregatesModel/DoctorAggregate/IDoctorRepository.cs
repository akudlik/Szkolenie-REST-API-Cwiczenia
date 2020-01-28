using System.Collections.Generic;
using CwiczeniaRESTAPI.SeedWork;

namespace CwiczeniaRESTAPI.AggregatesModel.DoctorAggregate
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        Result<IEnumerable<Doctor>> GetListOfDoctors(int pageSize, int pageNumber);

        Result<Doctor> GetOneDoctor(int id);

        Result<Doctor> CreateDoctor(Doctor Doctor);

        Result<Doctor> UpdateDoctor(Doctor Doctor);

        Result DeleteDoctor(int id);
    }
}