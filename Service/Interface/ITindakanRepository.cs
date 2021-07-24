
using Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ITindakanRepository
    {
        List<Tindakan> GetAllTindakan();
        Tindakan GetTindakanById(Guid id);
        Registrasi GetTindakanByIdRegistrasi(Guid idRegistrasi);
        void TambahTindakan(Tindakan data);
        void UbahTindakan(Guid id, Tindakan data);
        void HapusTindakan(Guid id);

    }
}
