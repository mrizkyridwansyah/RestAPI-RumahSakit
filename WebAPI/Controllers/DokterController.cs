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
    public class DokterController : ControllerBase
    {
        private IDokterRepository _dokterRepository;

        public DokterController(IDokterRepository dokterRepository)
        {
            _dokterRepository = dokterRepository;
        }

        [HttpGet]
        public IEnumerable<Dokter> Get()
        {
            return _dokterRepository.GetAllDokter();
        }

        [HttpGet("{id}")]
        public Dokter Get(Guid id)
        {
            return _dokterRepository.GetDokterById(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Dokter data)
        {
            try
            {
                _dokterRepository.TambahDokter(data);
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Dokter data)
        {
            try
            {
                _dokterRepository.UbahDokter(id, data);
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
                _dokterRepository.HapusDokter(id);
                return Ok("Data berhasil di hapus");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
