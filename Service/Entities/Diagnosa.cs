using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Service.Entities
{
    public class Diagnosa
    {
        [Key]
        [SwaggerSchema(ReadOnly = true)]
        public Guid Id { get; set; }

        [Required]
        public string Keterangan { get; set; }


        [Required]
        [ForeignKey("Registrasi")]
        public Guid IdRegistrasi { get; set; }

        [JsonIgnore]
        public virtual Registrasi Registrasi { get; set; }
    }
}
