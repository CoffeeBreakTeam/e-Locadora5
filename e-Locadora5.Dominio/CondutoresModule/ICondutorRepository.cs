using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Dominio.CondutoresModule
{
    public interface ICondutorRepository : IRepository<Condutor, int>, IReadOnlyRepository<Condutor, int>
    {
        
        public bool ExisteCondutorComEsteCPF(int id,string cpf);

        public bool ExisteCondutorComEsteRG(int id,string rg);      

        public List<Condutor> SelecionarCondutoresComCnhVencida(DateTime data);
    }
}
