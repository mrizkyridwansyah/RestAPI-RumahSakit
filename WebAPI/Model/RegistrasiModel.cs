using Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    public class RegistrasiModel
    {
        public Guid Id { get; set; }
        public string NoRegistrasi { get; set; }
        public DateTime Jadwal { get; set; }
        public Guid IdPasien { get; set; }
        public string NamaPasien { get; set; }
        public Guid IdDokter { get; set; }
        public string NamaDokter { get; set; }
    }
}
