using Microsoft.AspNetCore.Mvc;
using Service.Entities;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebAPI.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TindakanController : ControllerBase
    {
        private ITindakanRepository _tindakanRepository;

        public TindakanController(ITindakanRepository TindakanRepository)
        {
            _tindakanRepository = TindakanRepository;
        }

        [HttpGet]
        public IEnumerable<TindakanModel> Get()
        {
            var results = _tindakanRepository.GetAllTindakan();
            List<TindakanModel> data = new List<TindakanModel>();
            foreach (var result in results)
            {
                data.Add(new TindakanModel
                {
                    Id = result.Id,
                    IdRegistrasi = result.IdRegistrasi,
                    NoRegistrasi = result.Registrasi.NoRegistrasi,
                    IdPasien = result.Registrasi.IdPasien,
                    NamaPasien = result.Registrasi.Pasien.Nama,
                    IdDokter = result.Registrasi.IdDokter,
                    NamaDokter = result.Registrasi.Dokter.Nama,
                    KeteranganTindakan = result.Keterangan
                });
            }

            return data;
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var result = _tindakanRepository.GetTindakanById(id);

            if (result == null) return NoContent();

            TindakanModel data = new TindakanModel
            {
                Id = result.Id,
                IdRegistrasi = result.IdRegistrasi,
                NoRegistrasi = result.Registrasi.NoRegistrasi,
                IdPasien = result.Registrasi.IdPasien,
                NamaPasien = result.Registrasi.Pasien.Nama,
                IdDokter = result.Registrasi.IdDokter,
                NamaDokter = result.Registrasi.Dokter.Nama,
                KeteranganTindakan = result.Keterangan
            };

            return Ok(data);

        }

        [HttpGet("GetTindakanByIdRegistrasi/{idRegistrasi}")]
        public IActionResult GetTindakanByIdRegistrasi(Guid idRegistrasi)
        {
            var result = _tindakanRepository.GetTindakanByIdRegistrasi(idRegistrasi);

            if (result == null) return NoContent();

            return Ok(new { IdRegistrasi = result.Id, NoRegistrasi = result.NoRegistrasi, DetailTindakan = result.Tindakan });
        }

        [HttpPost]
        public IActionResult Post([FromBody] Tindakan data)
        {
            try
            {
                _tindakanRepository.TambahTindakan(data);
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Tindakan data)
        {
            try
            {
                _tindakanRepository.UbahTindakan(id, data);
                return Ok("Data berhasil di ubah");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _tindakanRepository.HapusTindakan(id);
                return Ok("Data berhasil di hapus");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
