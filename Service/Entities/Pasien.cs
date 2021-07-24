using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Service.Entities
{
    public class Pasien
    {
        [Key]
        [SwaggerSchema(ReadOnly = true)]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(16)]
        public string NIK { get; set; }
        [Required]
        public string Nama { get; set; }
    }
}
