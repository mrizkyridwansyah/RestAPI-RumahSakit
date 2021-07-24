using Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IPasienRepository
    {
        List<Pasien> GetAllPasien();
        Pasien GetPasienById(Guid id);
        void TambahPasien(Pasien data);
        void UbahPasien(Guid id, Pasien data);
        void HapusPasien(Guid id);
    }
}
