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
    public class RegistrasiController : ControllerBase
    {
        private IRegistrasiRepository _registrasiRepository;

        public RegistrasiController(IRegistrasiRepository registrasiRepository)
        {
            _registrasiRepository = registrasiRepository;
        }

        [HttpGet]
        public IEnumerable<RegistrasiModel> Get()
        {
            var results = _registrasiRepository.GetAllRegistrasi();
            List<RegistrasiModel> data = new List<RegistrasiModel>();
            foreach (var result in results)
            {
                data.Add(new RegistrasiModel
                {
                    Id = result.Id,
                    NoRegistrasi = result.NoRegistrasi,
                    Jadwal = result.Jadwal,
                    IdPasien = result.IdPasien,
                    NamaPasien = result.Pasien.Nama,
                    IdDokter = result.IdDokter,
                    NamaDokter = result.Dokter.Nama,
                });
            }

            return data;
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var result = _registrasiRepository.GetRegistrasiById(id);

            if (result == null) return NoContent();

            RegistrasiModel data = new RegistrasiModel
            {
                Id = result.Id,
                NoRegistrasi = result.NoRegistrasi,
                Jadwal = result.Jadwal,
                IdPasien = result.IdPasien,
                NamaPasien = result.Pasien.Nama,
                IdDokter = result.IdDokter,
                NamaDokter = result.Dokter.Nama
            };

            return Ok(data);

        }

        [HttpPost]
        public IActionResult Post([FromBody] Registrasi data)
        {
            try
            {
                _registrasiRepository.TambahRegistrasi(data);
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Registrasi data)
        {
            try
            {
                _registrasiRepository.UbahRegistrasi(id, data);
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
                _registrasiRepository.HapusRegistrasi(id);
                return Ok("Data berhasil di hapus");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
