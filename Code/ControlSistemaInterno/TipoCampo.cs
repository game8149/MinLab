using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinLab.Code.ControlSistemaInterno
{
   
    public enum TipoCampo
    {
        Input = 0,
        Lista = 1,
        Texto = 2,
        Fecha =3
    }

    public enum Area
    {
        BIOQUIMICA=0,
        ESTUDIODESECRECIONES=1,
        HEMATOLOGIA=2,
        INMUNOLOGIA=3,
        MICROBIOLOGIA=4,
        PARASITOLOGIA=5,
        UROANALISIS=6
    }

    public enum TipoDato
    {
        Bool = 0,
        Texto = 1,
        Entero = 2,
        Decimal = 3,
        Fecha = 4
    }

    public enum TipoPaquete
    {
        Simple = 0,
        Compuesto = 1,
        Perfil = 2
    }
}
