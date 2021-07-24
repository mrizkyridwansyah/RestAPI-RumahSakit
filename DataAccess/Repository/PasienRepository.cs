using DataAccess.Context;
using Service.Entities;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class PasienRepository : IPasienRepository
    {
        LibDbContext _dbContext;
        public PasienRepository(LibDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Pasien> GetAllPasien()
        {
            return _dbContext.Pasien.ToList();
        }
        public Pasien GetPasienById(Guid id)
        {
            return _dbContext.Pasien.SingleOrDefault(x => x.Id == id);
        }
        public void TambahPasien(Pasien data)
        {
            try
            {
                _dbContext.Pasien.Add(data);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void UbahPasien(Guid id, Pasien data)
        {
            Pasien pasien = _dbContext.Pasien.SingleOrDefault(x => x.Id == id);
            if (pasien == null) throw new Exception("Data Pasien Tidak Ditemukan");

            try
            {
                pasien.Nama = data.Nama;
                _dbContext.Pasien.Update(pasien);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void HapusPasien(Guid id)
        {
            Pasien pasien = _dbContext.Pasien.SingleOrDefault(x => x.Id == id);
            if (pasien == null) throw new Exception("Data Pasien Tidak Ditemukan");

            try
            {
                _dbContext.Remove(pasien);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
