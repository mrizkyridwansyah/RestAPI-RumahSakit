
using Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IRegistrasiRepository
    {
        List<Registrasi> GetAllRegistrasi();
        Registrasi GetRegistrasiById(Guid id);
        void TambahRegistrasi(Registrasi data);
        void UbahRegistrasi(Guid id, Registrasi data);
        void HapusRegistrasi(Guid id);
    }
}
