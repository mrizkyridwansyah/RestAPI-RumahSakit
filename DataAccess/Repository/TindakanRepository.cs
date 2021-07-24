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
    public class TindakanRepository : ITindakanRepository
    {
        LibDbContext _dbContext;
        public TindakanRepository(LibDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Tindakan> GetAllTindakan()
        {
            return _dbContext.Tindakan.ToList();
        }
        public Registrasi GetTindakanByIdRegistrasi(Guid idRegistrasi)
        {
            return _dbContext.Registrasi.SingleOrDefault(x => x.Id == idRegistrasi);
        }
        public Tindakan GetTindakanById(Guid id)
        {
            return _dbContext.Tindakan
                .Include(x => x.Registrasi)
                .SingleOrDefault(x => x.Id == id);
        }
        public void TambahTindakan(Tindakan data)
        {
            if (!_dbContext.Registrasi.Any(x => x.Id == data.IdRegistrasi)) throw new Exception("Data registrasi tidak ditemukan");

            try
            {
                _dbContext.Tindakan.Add(data);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void UbahTindakan(Guid id, Tindakan data)
        {           
            Tindakan tindakan = _dbContext.Tindakan.SingleOrDefault(x => x.Id == id);
            if (tindakan == null) throw new Exception("Data Tindakan Tidak Ditemukan");

            if (!_dbContext.Registrasi.Any(x => x.Id == data.IdRegistrasi)) throw new Exception("Data registrasi tidak ditemukan");

            try
            {
                tindakan.IdRegistrasi = data.IdRegistrasi;
                tindakan.Keterangan = data.Keterangan;
                _dbContext.Tindakan.Update(tindakan);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void HapusTindakan(Guid id)
        {
            Tindakan tindakan = _dbContext.Tindakan.SingleOrDefault(x => x.Id == id);
            if (tindakan == null) throw new Exception("Data Tindakan Tidak Ditemukan");

            try
            {
                _dbContext.Remove(tindakan);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
