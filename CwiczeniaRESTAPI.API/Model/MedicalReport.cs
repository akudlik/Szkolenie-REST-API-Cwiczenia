using System;

namespace CwiczeniaRESTAPI.API.Model
{
    public class MedicalReport
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public Patient Patient { get; set; }

        public Doctor Doctor { get; set; }

        public string BloodResult { get; set; }

        public string CMM { get; set; }

        public string FL { get; set; }

        public string GDL { get; set; }

        public string IUL { get; set; }

        public string MGDL { get; set; }

        public string CBC { get; set; }

        public string WBC { get; set; }

        public string RBC { get; set; }
    }
}