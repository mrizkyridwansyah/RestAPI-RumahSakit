//using Newtonsoft.Json;
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
    public class Registrasi
    {
        [Key]
        [SwaggerSchema(ReadOnly = true)]
        public Guid Id { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        [MaxLength(11)]
        public string NoRegistrasi { get; set; }

        [Required]
        public DateTime Jadwal { get; set; }

        [Required]
        [ForeignKey("Pasien")]
        public Guid IdPasien { get; set; }

        [Required]
        [ForeignKey("Dokter")]
        public Guid IdDokter { get; set; }

        [JsonIgnore]
        public virtual Pasien Pasien { get; set; }
        [JsonIgnore]
        public virtual Dokter Dokter { get; set; }
        [JsonIgnore]
        public virtual ICollection<Diagnosa> Diagnosa { get; set; }
        [JsonIgnore]
        public virtual ICollection<Tindakan> Tindakan { get; set; }
    }
}
