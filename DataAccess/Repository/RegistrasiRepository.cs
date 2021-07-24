using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Service.Entities;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class RegistrasiRepository : IRegistrasiRepository
    {
        LibDbContext _dbContext;
        public RegistrasiRepository(LibDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Registrasi> GetAllRegistrasi()
        {
            return _dbContext.Registrasi
                .Include(x => x.Pasien)
                .Include(x => x.Dokter)
                .ToList();
        }
        public Registrasi GetRegistrasiById(Guid id)
        {
            return _dbContext.Registrasi
                .Include(x => x.Pasien)
                .Include(x => x.Dokter)
                .SingleOrDefault(x => x.Id == id);
        }
        public void TambahRegistrasi(Registrasi data)
        {
            Validasi(data);
            data.NoRegistrasi = GetNoRegistrasi(data);

            try
            {
                _dbContext.Registrasi.Add(data);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void UbahRegistrasi(Guid id, Registrasi data)
        {           
            Registrasi registrasi = _dbContext.Registrasi.SingleOrDefault(x => x.Id == id);
            if (registrasi == null) throw new Exception("Data Registrasi Tidak Ditemukan");

            Validasi(data);

            try
            {
                if(registrasi.Jadwal.Date != data.Jadwal.Date)
                {
                    registrasi.NoRegistrasi = GetNoRegistrasi(data);
                    registrasi.Jadwal = data.Jadwal;
                }
                registrasi.IdPasien = data.IdPasien;
                registrasi.IdDokter = data.IdDokter;
                _dbContext.Registrasi.Update(registrasi);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void HapusRegistrasi(Guid id)
        {
            Registrasi registrasi = _dbContext.Registrasi.SingleOrDefault(x => x.Id == id);
            if (registrasi == null) throw new Exception("Data Registrasi Tidak Ditemukan");

            try
            {
                _dbContext.Remove(registrasi);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private void Validasi(Registrasi data)
        {
            if (data.Jadwal < DateTime.Today) throw new Exception("Tanggal jadwal sudah lewat");
            if (!_dbContext.Pasien.Any(x => x.Id == data.IdPasien)) throw new Exception("Data pasien tidak ditemukan");
            if (!_dbContext.Dokter.Any(x => x.Id == data.IdDokter)) throw new Exception("Data dokter tidak ditemukan");
        }

        private string GetNoRegistrasi(Registrasi data)
        {
            var xx = _dbContext.Registrasi
                        .OrderByDescending(x => x.NoRegistrasi)
                        .FirstOrDefault(x => x.Jadwal.Date == data.Jadwal.Date);

            string jd = data.Jadwal.ToString("yyyyMMdd");
            int noRegistrasiTerakhirPerTanggal = xx == null ? 1 : Convert.ToInt32(xx.NoRegistrasi.Substring(8,3)) + 1;
            string noRegistrasi = jd + noRegistrasiTerakhirPerTanggal.ToString().PadLeft(3, '0');

            return noRegistrasi;
        }
    }
}
