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
    public class DokterRepository : IDokterRepository
    {
        LibDbContext _dbContext;
        public DokterRepository(LibDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Dokter> GetAllDokter()
        {
            return _dbContext.Dokter.ToList();
        }
        public Dokter GetDokterById(Guid id)
        {
            return _dbContext.Dokter.SingleOrDefault(x => x.Id == id);
        }
        public void TambahDokter(Dokter data)
        {
            try
            {
                _dbContext.Dokter.Add(data);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void UbahDokter(Guid id, Dokter data)
        {
            Dokter dokter = _dbContext.Dokter.SingleOrDefault(x => x.Id == id);
            if (dokter == null) throw new Exception("Data Dokter Tidak Ditemukan");

            try
            {
                dokter.Nama = data.Nama;
                _dbContext.Dokter.Update(dokter);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void HapusDokter(Guid id)
        {
            Dokter dokter = _dbContext.Dokter.SingleOrDefault(x => x.Id == id);
            if (dokter == null) throw new Exception("Data Dokter Tidak Ditemukan");

            try
            {
                _dbContext.Remove(dokter);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
