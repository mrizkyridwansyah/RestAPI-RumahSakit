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
    public class DiagnosaController : ControllerBase
    {
        private IDiagnosaRepository _diagnosaRepository;

        public DiagnosaController(IDiagnosaRepository diagnosaRepository)
        {
            _diagnosaRepository = diagnosaRepository;
        }

        [HttpGet]
        public IEnumerable<DiagnosaModel> Get()
        {
            var results = _diagnosaRepository.GetAllDiagnosa();
            List<DiagnosaModel> data = new List<DiagnosaModel>();
            foreach (var result in results)
            {
                data.Add(new DiagnosaModel
                {
                    Id = result.Id,
                    IdRegistrasi = result.IdRegistrasi,
                    NoRegistrasi = result.Registrasi.NoRegistrasi,
                    IdPasien = result.Registrasi.IdPasien,
                    NamaPasien = result.Registrasi.Pasien.Nama,
                    IdDokter = result.Registrasi.IdDokter,
                    NamaDokter = result.Registrasi.Dokter.Nama,
                    KeteranganDiagnosa = result.Keterangan
                });
            }

            return data;
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var result = _diagnosaRepository.GetDiagnosaById(id);

            if (result == null) return NoContent();

            DiagnosaModel data = new DiagnosaModel
            {
                Id = result.Id,
                IdRegistrasi = result.IdRegistrasi,
                NoRegistrasi = result.Registrasi.NoRegistrasi,
                IdPasien = result.Registrasi.IdPasien,
                NamaPasien = result.Registrasi.Pasien.Nama,
                IdDokter = result.Registrasi.IdDokter,
                NamaDokter = result.Registrasi.Dokter.Nama,
                KeteranganDiagnosa = result.Keterangan
            };

            return Ok(data);

        }

        [HttpGet("GetDiagnosaByIdRegistrasi/{idRegistrasi}")]
        public IActionResult GetDiagnosaByIdRegistrasi(Guid idRegistrasi)
        {
            var result = _diagnosaRepository.GetDiagnosaByIdRegistrasi(idRegistrasi);

            if (result == null) return NoContent();

            return Ok(new { IdRegistrasi = result.Id, NoRegistrasi = result.NoRegistrasi, DetailDiagnosa = result.Diagnosa });
        }

        [HttpPost]
        public IActionResult Post([FromBody] Diagnosa data)
        {
            try
            {
                _diagnosaRepository.TambahDiagnosa(data);
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Diagnosa data)
        {
            try
            {
                _diagnosaRepository.UbahDiagnosa(id, data);
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
                _diagnosaRepository.HapusDiagnosa(id);
                return Ok("Data berhasil di hapus");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
