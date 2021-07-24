using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
//using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Service.Entities
{
    public class Dokter
    {
        [Key]
        [SwaggerSchema(ReadOnly = true)]
        public Guid Id { get; set; }
        [Required]
        public string Nama { get; set; }
    }
}
