using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Configuracoes
{
    public static class Configuracao
    {
        private static readonly Dictionary<string, string> camposIniciais
            = new Dictionary<string, string>()
            {
                {"precoGasolina", "0" },
                {"precoGas", "0" },
                {"precoDiesel", "0" },
                {"precoAlcool", "0" },

            };

        private static AppConfigControle appConfigControler;

        static Configuracao()
        {
            appConfigControler = new AppConfigControle(camposIniciais);
        }

        public static double PrecoGasolina
        {
            get
            {
                return Convert.ToDouble(appConfigControler.Ler("precoGasolina"));
            }
            set
            {
                appConfigControler.Setar("precoGasolina", value);
            }
        }

        public static double PrecoGas
        {
            get
            {
                return Convert.ToDouble(appConfigControler.Ler("precoGas"));
            }
            set
            {
                appConfigControler.Setar("precoGas", value);
            }
        }

        public static double PrecoDiesel
        {
            get
            {
                return Convert.ToDouble(appConfigControler.Ler("precoDiesel"));
            }
            set
            {
                appConfigControler.Setar("precoDiesel", value);
            }
        }

        public static double PrecoAlcool
        {
            get
            {
                return Convert.ToDouble(appConfigControler.Ler("precoAlcool"));
            }
            set
            {
                appConfigControler.Setar("precoAlcool", value);
            }
        }

     

     
    }
}
