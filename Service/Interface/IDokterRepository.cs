
using Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IDokterRepository
    {
        List<Dokter> GetAllDokter();
        Dokter GetDokterById(Guid id);
        void TambahDokter(Dokter data);
        void UbahDokter(Guid id, Dokter data);
        void HapusDokter(Guid id);
    }
}
