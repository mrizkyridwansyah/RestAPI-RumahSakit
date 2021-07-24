
using Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IDiagnosaRepository
    {
        List<Diagnosa> GetAllDiagnosa();
        Diagnosa GetDiagnosaById(Guid id);
        Registrasi GetDiagnosaByIdRegistrasi(Guid idRegistrasi);
        void TambahDiagnosa(Diagnosa data);
        void UbahDiagnosa(Guid id, Diagnosa data);
        void HapusDiagnosa(Guid id);

    }
}
