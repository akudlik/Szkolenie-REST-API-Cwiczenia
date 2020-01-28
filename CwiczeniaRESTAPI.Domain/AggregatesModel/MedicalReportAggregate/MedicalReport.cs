using System;
using CwiczeniaRESTAPI.AggregatesModel.DoctorAggregate;
using CwiczeniaRESTAPI.AggregatesModel.PatientAggregate;
using CwiczeniaRESTAPI.SeedWork;

namespace CwiczeniaRESTAPI.AggregatesModel.MedicalReportAggregate
{
    public class MedicalReport : Entity, IAggregateRoot
    {
        public virtual DateTime Date { get; set; }

        public virtual Patient Patient { get; set; }

        public virtual Doctor Doctor { get; set; }

        public virtual string BloodResult { get; set; }

        public virtual string CMM { get; set; }

        public virtual string FL { get; set; }

        public virtual string GDL { get; set; }

        public virtual string IUL { get; set; }

        public virtual int? MGDL { get; set; }

        public virtual int? CBC { get; set; }

        public virtual int? WBC { get; set; }

        public virtual int? RBC { get; set; }
    }
}