using AutoMapper;

namespace CwiczeniaRESTAPI.API.Model
{
    public class CwiczenieProfile : Profile
    {
        public CwiczenieProfile()
        {
            CreateMap<CwiczeniaRESTAPI.AggregatesModel.PatientAggregate.Address, Address>().ReverseMap();
            CreateMap<CwiczeniaRESTAPI.AggregatesModel.PatientAggregate.Patient, Patient>().ReverseMap();
            CreateMap<CwiczeniaRESTAPI.AggregatesModel.DoctorAggregate.Doctor, Doctor>().ReverseMap();
            CreateMap<CwiczeniaRESTAPI.AggregatesModel.MedicalReportAggregate.MedicalReport, MedicalReport>().ReverseMap();
        }
    }
}