using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    public class DiagnosaModel
    {
        public Guid Id { get; set; }
        public Guid IdRegistrasi { get; set; }
        public string NoRegistrasi { get; set; }
        public Guid IdPasien { get; set; }
        public string NamaPasien { get; set; }
        public Guid IdDokter { get; set; }
        public string NamaDokter { get; set; }
        public string KeteranganDiagnosa { get; set; }
    }
}
