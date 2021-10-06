using e_Locadora5.Dominio.ParceirosModule;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Infra.ORM.ParceiroModule
{
    public class ParceiroOrmDAO 
    {
        LocadoraDbContext parceiroDbContext;
        public ParceiroOrmDAO()
        {
            this.parceiroDbContext = new LocadoraDbContext();
        }

       
    }
}
