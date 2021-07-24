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
    public class DiagnosaRepository : IDiagnosaRepository
    {
        LibDbContext _dbContext;
        public DiagnosaRepository(LibDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Diagnosa> GetAllDiagnosa()
        {
            return _dbContext.Diagnosa.ToList();
        }
        public Registrasi GetDiagnosaByIdRegistrasi(Guid idRegistrasi)
        {
            return _dbContext.Registrasi.SingleOrDefault(x => x.Id == idRegistrasi);
        }
        public Diagnosa GetDiagnosaById(Guid id)
        {
            return _dbContext.Diagnosa
                .Include(x => x.Registrasi)
                .SingleOrDefault(x => x.Id == id);
        }
        public void TambahDiagnosa(Diagnosa data)
        {
            if (!_dbContext.Registrasi.Any(x => x.Id == data.IdRegistrasi)) throw new Exception("Data registrasi tidak ditemukan");

            try
            {
                _dbContext.Diagnosa.Add(data);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void UbahDiagnosa(Guid id, Diagnosa data)
        {           
            Diagnosa diagnosa = _dbContext.Diagnosa.SingleOrDefault(x => x.Id == id);
            if (diagnosa == null) throw new Exception("Data Diagnosa Tidak Ditemukan");

            if (!_dbContext.Registrasi.Any(x => x.Id == data.IdRegistrasi)) throw new Exception("Data registrasi tidak ditemukan");

            try
            {
                diagnosa.IdRegistrasi = data.IdRegistrasi;
                diagnosa.Keterangan = data.Keterangan;
                _dbContext.Diagnosa.Update(diagnosa);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void HapusDiagnosa(Guid id)
        {
            Diagnosa diagnosa = _dbContext.Diagnosa.SingleOrDefault(x => x.Id == id);
            if (diagnosa == null) throw new Exception("Data Diagnosa Tidak Ditemukan");

            try
            {
                _dbContext.Remove(diagnosa);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
