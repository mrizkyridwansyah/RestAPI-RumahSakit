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
    public class PasienController : ControllerBase
    {
        private IPasienRepository _pasienRepository;

        public PasienController(IPasienRepository PasienRepository)
        {
            _pasienRepository = PasienRepository;
        }

        [HttpGet]
        public IEnumerable<Pasien> Get()
        {
            return _pasienRepository.GetAllPasien();
        }

        [HttpGet("{id}")]
        public Pasien Get(Guid id)
        {
            return _pasienRepository.GetPasienById(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Pasien data)
        {
            try
            {
                _pasienRepository.TambahPasien(data);
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Pasien data)
        {
            try
            {
                _pasienRepository.UbahPasien(id, data);
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
                _pasienRepository.HapusPasien(id);

                return Ok("Data berhasil di hapus");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
