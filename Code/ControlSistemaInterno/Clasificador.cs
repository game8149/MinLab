using MinLab.Code.EntityLayer;
using MinLab.Code.EntityLayer.FichaExamen;
using System;
using System.Globalization;
using System.Text;
using static MinLab.Code.ControlSistemaInterno.DiccionarioGeneral;

namespace MinLab.Code.ControlSistemaInterno
{
    public class Clasificador
    {
        public bool Controlar(Examen ex)
        {
            switch (ex.IdPlantilla)
            {
                case 6:
                    NumberFormatInfo nfi = new NumberFormatInfo();
                    nfi.NumberDecimalSeparator = ".";
                    double abas, seg, neut, mono, eosi, lin, bas;
                    abas = double.Parse(ex.DetallesByItem[4].Campo, nfi);
                    seg = double.Parse(ex.DetallesByItem[5].Campo, nfi);
                    mono = double.Parse(ex.DetallesByItem[7].Campo, nfi);
                    eosi = double.Parse(ex.DetallesByItem[8].Campo, nfi);
                    lin = double.Parse(ex.DetallesByItem[9].Campo, nfi);
                    bas = double.Parse(ex.DetallesByItem[10].Campo, nfi);
                    neut = double.Parse(ex.DetallesByItem[6].Campo, nfi);
                    if (abas + seg != neut) { throw new Exception("Neutrofilos no tiene la cantidad Correcta.\n Neutrofilos= Abastonados + Segmentados "); }
                    if (neut + mono + bas + eosi + lin != 100) throw new Exception("La suma de los 5 ultimos campos debe ser 100.");
                    break;
            }
            return true;
        }


        public string Clasificar(Paciente pac,int idTarifa,ExamenDetalle exdet)
        {
            StringBuilder cad=new StringBuilder();
            double value;
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";
            value=double.Parse(exdet.Campo, nfi);
            Tiempo tiempo = DiccionarioGeneral.GetInstance().CalcularEdad(pac.FechaNacimiento);
            switch (exdet.IdItem)
            {
                case 1:
                    if (tiempo.Dias<=29 && tiempo.Mes == 0 && tiempo.Año == 0)
                    {
                        if (value < 14.55)
                            cad.Append(" (Bajo)");
                        else if (value > 23.0)
                            cad.Append(" (Alto)");
                        else
                            cad.Append(" (Normal)");
                    }
                    else if (tiempo.Dias>29 && tiempo.Año == 0)
                    {
                        if (value < 11)
                            cad.Append(" (Bajo)");
                        else if (value > 12)
                            cad.Append(" (Alto)");
                        else
                            cad.Append(" (Normal)");
                    }
                    else if (tiempo.Año >= 1 && tiempo.Año <= 5)
                    {
                        if (value < 11)
                            cad.Append(" (Bajo)");
                        else if (value > 13)
                            cad.Append(" (Alto)");
                        else
                            cad.Append(" (Normal)");
                    }
                    else if (tiempo.Año >= 6 && tiempo.Año <= 10)
                    {
                        if (value < 12)
                            cad.Append(" (Bajo)");
                        else if (value > 13.5)
                            cad.Append(" (Alto)");
                        else
                            cad.Append(" (Normal)");
                    }
                    else if (tiempo.Año >= 11)
                    {
                        switch (pac.Genero)
                        {
                            case 0://HOMBRE
                                if (value < 13)
                                    cad.Append(" (Bajo)");
                                else if (value > 15.5)
                                    cad.Append(" (Alto)");
                                else
                                    cad.Append(" (Normal)");
                                break;
                            case 1://MUJER
                                //ES PROBABLE QUE DEBA SER CAMBIADO LA ORGANIZACION DE DOCUMENTOS//
                                if(idTarifa==70)//SI ES PERFIL PRENATAL{
                                {
                                    if (value < 11)
                                        cad.Append(" (Bajo)");
                                    else if (value > 13)
                                        cad.Append(" (Alto)");
                                    else
                                        cad.Append(" (Normal)");
                                }
                                else
                                {
                                    if (value < 12.00)
                                        cad.Append(" (Bajo)");
                                    else if (value > 15.00)
                                        cad.Append(" (Alto)");
                                    else
                                        cad.Append(" (Normal)");
                                    
                                }
                                
                                break;
                        }
                    }
                    break;//HEMOGLOBINA
                case 2:
                    if (tiempo.Dias <= 10 && tiempo.Mes == 0 && tiempo.Año == 0)
                    {
                        if (value < 44)
                            cad.Append(" (Bajo)");
                        else if (value > 64)
                            cad.Append(" (Alto)");
                        else
                            cad.Append(" (Normal)");
                    }
                    else if (tiempo.Dias > 10 && tiempo.Mes >= 0 && tiempo.Año >= 0 && tiempo.Año < 14)
                    {
                        if (value < 33)
                            cad.Append(" (Bajo)");
                        else if (value > 43)
                            cad.Append(" (Alto)");
                        else
                            cad.Append(" (Normal)");
                    }
                    else if (tiempo.Año >= 14)
                    {
                        switch (pac.Genero)
                        {
                            case 0:
                                if (value < 40)
                                    cad.Append(" (Bajo)");
                                else if (value > 50)
                                    cad.Append(" (Alto)");
                                else
                                    cad.Append(" (Normal)");
                                break;
                            case 1:
                                //ES PROBABLE QUE DEBA SER CAMBIADO LA ORGANIZACION DE DOCUMENTOS//
                                if (idTarifa == 70)//SI ES PERFIL PRENATAL{
                                {
                                    if (value < 34)
                                        cad.Append(" (Bajo)");
                                    else if (value > 44)
                                        cad.Append(" (Alto)");
                                    else
                                        cad.Append(" (Normal)");
                                }
                                else
                                {
                                    if (value < 37)
                                        cad.Append(" (Bajo)");
                                    else if (value > 47)
                                        cad.Append(" (Alto)");
                                    else
                                        cad.Append(" (Normal)");
                                }

                                break;
                        }
                    }
                    break;//HEMATOCRITO
                case 3:
                    if (tiempo.Año == 0 && tiempo.Dias <= 29)
                    {
                        if (value < 5)
                            cad.Append(" (Bajo)");
                        else if (value > 25)
                            cad.Append(" (Alto)");
                        else
                            cad.Append(" (Normal)");
                    }
                    else
                    {
                        if (value < 5)
                            cad.Append(" (Bajo)");
                        else if (value > 10)
                            cad.Append(" (Alto)");
                        else
                            cad.Append(" (Normal)");
                    }
                   
                    break;//LEUCOCITO (HMG)
                case 4:
                    if (value < 2)
                        cad.Append(" (Bajo)");
                    else if (value > 4)
                        cad.Append(" (Alto)");
                    else
                        cad.Append(" (Normal)");
                    break;//ABASTONADOS
                case 5:
                    if (value < 55)
                        cad.Append(" (Bajo)");
                    else if (value > 65)
                        cad.Append(" (Alto)");
                    else
                        cad.Append(" (Normal)");

                    break;//SEGMENTADOS
                case 6:

                    if (value < 40)
                        cad.Append(" (Bajo)");
                    else if (value > 75)
                        cad.Append(" (Alto)");
                    else
                        cad.Append(" (Normal)");

                    break;//NEUTROFILOS
                case 7:
                    if (value < 5)
                        cad.Append(" (Bajo)");
                    else if (value > 8)
                        cad.Append(" (Alto)");
                    else
                        cad.Append(" (Normal)");
                    break;//MONOCITOS
                case 8:
                    if (value < 0)
                        cad.Append(" (Bajo)");
                    else if (value > 3)
                        cad.Append(" (Alto)");
                    else
                        cad.Append(" (Normal)");

                    break;//EOSINOFILOS
                case 9:
                    if (value < 21)
                        cad.Append(" (Bajo)");
                    else if (value > 47)
                        cad.Append(" (Alto)");
                    else
                        cad.Append(" (Normal)");

                    break;//LINFOCITOS
                case 10:
                    if (value < 0)
                        cad.Append(" (Bajo)");
                    else if (value > 1)
                        cad.Append(" (Alto)");
                    else
                        cad.Append(" (Normal)");
                    break;//BASOFILOS
                case 11:
                    if (value < 150)
                        cad.Append(" (Bajo)");
                    else if (value > 450)
                        cad.Append(" (Alto)");
                    else
                        cad.Append(" (Normal)");

                    break;//RECUENTO DE PLAQUETAS (HMG)
                case 14:
                    if (value < 1)
                        cad.Append(" (Bajo)");
                    else if (value > 3)
                        cad.Append(" (Alto)");
                    else
                        cad.Append(" (Normal)");

                    break;//TIEMPO DE SANGRIA
                case 15:
                    if (value < 1)
                        cad.Append(" (Bajo)");
                    else if (value > 10)
                        cad.Append(" (Alto)");
                    else
                        cad.Append(" (Normal)");


                    break;//TIEMPO DE COAGULACION
                case 16:
                    if (value >= 80 && value <= 90)
                        cad.Append(" (Normal)");
                    else
                        cad.Append(" (Patologico)");
                    break;//VELOCIDAD DE SEDIMENTACION GLOBULAR
                case 18:
                    if (value < 2)
                        cad.Append(" (Bajo)");
                    else if (value > 7.5)
                        cad.Append(" (Patologico)");
                    else
                        cad.Append(" (Normal)");
                    break;//ACIDO URICO
                case 19:
                    if (value >= 3.0 && value <= 4.8)
                        cad.Append(" (Normal)");
                    else
                        cad.Append(" (Patologico)");

                    break;//ALBUMINA
                case 20:

                    switch (pac.Genero)
                    {
                        case 0:
                            if (value < 14)
                                cad.Append(" (Bajo)");
                            else if (value > 26)
                                cad.Append(" (Patologico)");
                            else
                                cad.Append(" (Normal)");
                            break;
                        case 1:
                            if (value < 11)
                                cad.Append(" (Bajo)");
                            else if (value > 20)
                                cad.Append(" (Patologico)");
                            else
                                cad.Append(" (Normal)");
                            break;
                    }
                    break;//CREATININA EN ORINA
                case 21:

                    if (value < 0.2)
                        cad.Append(" (Bajo)");
                    else if (value > 1.2)
                        cad.Append(" (Alto)");
                    else
                        cad.Append(" (Normal)");

                    break;//CREATININA SERICA
                case 22:
                    switch (pac.Genero)
                    {
                        case 0:
                            if (value >= 94 && value <= 140)
                                cad.Append(" (Normal)");
                            else
                                cad.Append(" (Patologico)");
                            break;
                        case 1:
                            if (value >= 72 && value <= 110)
                                cad.Append(" (Normal)");
                            else
                                cad.Append(" (Patologico)");
                            break;
                    }

                    break;//DEPURACION DE CREATININA
                case 23:
                    switch (pac.Genero)
                    {
                        case 0:
                            if (value >= 8 && value <= 46)
                                cad.Append(" (Normal)");
                            else
                                cad.Append(" (Patologico)");
                            break;
                        case 1:
                            if (value >= 7 && value <= 29)
                                cad.Append(" (Normal)");
                            else
                                cad.Append(" (Patologico)");
                            break;
                    }

                    break;//GAMMAGLUTAMILTRANSEPTIDASA
                case 24:

                    if (value < 70)
                        cad.Append(" (Bajo)");
                    else if (value > 140)
                        cad.Append(" (Alto)");
                    else
                        cad.Append(" (Normal)");
                    break;//GLUCOSA (POSTPRANDIAL)
                case 25:
                    if (value < 70)
                        cad.Append(" (Bajo)");
                    else if (value > 110)
                        cad.Append(" (Alto)");
                    else
                        cad.Append(" (Normal)");

                    break;//GLUCOSA (BASAL)
                case 26:

                    if (value >=2.5&&value <= 2.9)
                        cad.Append(" (Normal)");
                    else
                        cad.Append(" (Patologico)");
                    break;//GLOBULINA
                case 27:
                    if (value >= 6.1 && value <= 7.9)
                        cad.Append(" (Normal)");
                    else
                        cad.Append(" (Patologico)");

                    break;//PROTEINA TOTAL

                case 29:

                    if (value >= 150)
                        cad.Append(" (Patologico)");
                    else
                        cad.Append(" (Normal)");

                    break;//PROTEINA EN ORINA DE 24 HORAS
                case 30:

                    if (value <= 200)
                        cad.Append(" (Normal)");
                    else
                        cad.Append(" (Patologico)");
                    break;//COLESTEROL TOTAL
                case 31:


                    if (value <= 150)
                        cad.Append(" (Normal)");
                    else
                        cad.Append(" (Patologico)");
                    break;//TRIGLICERIDOS
                case 32:
                    if (value > 35)
                        cad.Append(" (Normal)");
                    else
                        cad.Append(" (Patologico)");

                    break;//COLESTEROL HDL
                case 33:
                    if (value <= 130)
                        cad.Append(" (Normal)");
                    else
                        cad.Append(" (Patologico)");

                    break;//COLESTEROL LDL
                case 34:

                    if (value <= 50)
                        cad.Append(" (Normal)");
                    else
                        cad.Append(" (Patologico)");

                    break;//COLESTEROL VLDL
                case 35:

                    if (value < 50)
                        cad.Append(" (Bajo)");
                    else if (value > 125)
                        cad.Append(" (Alto)");
                    else
                        cad.Append(" (Normal)");

                    break;//FOSFATA ALCALINA
                case 36:

                    if (value < 20)
                        cad.Append(" (Bajo)");
                    else if (value > 45)
                        cad.Append(" (Alto)");
                    else
                        cad.Append(" (Normal)");

                    break;//UREA
                case 37:


                    if (value < 8)
                        cad.Append(" (Bajo)");
                    else if (value > 37)
                        cad.Append(" (Alto)");
                    else
                        cad.Append(" (Normal)");

                    break;//TRANSAMINASAS TGP
                case 38:

                    if (value < 8)
                        cad.Append(" (Bajo)");
                    else if (value > 40)
                        cad.Append(" (Alto)");
                    else
                        cad.Append(" (Normal)");

                    break;//TRANSAMINASAS TGO
                case 39:

                    if (value <= 1.2)
                        cad.Append(" (Normal)");
                    else
                        cad.Append(" (Alto)");

                    break;//BILIRRUBINA TOTAL
                case 40:


                    if (value <= 0.23)
                        cad.Append(" (Normal)");
                    else
                        cad.Append(" (Alto)");


                    break;//BILIRRUBINA DIRECTA
                case 41:


                    if (value <= 0.37)
                        cad.Append(" (Normal)");
                    else
                        cad.Append(" (Alto)");

                    break;//BILIRRUBINA INDIRECTA
                case 61:

                    if (value < 7)
                        cad.Append(" (Acido)");
                    else if (value > 7)
                        cad.Append(" (Basico)");
                    else
                        cad.Append(" (Neutro)");

                    break;//PH
                case 65:

                    if (value < 10)
                        cad.Append(" (Normal)");
                    else if (value > 20)
                        cad.Append(" (Patologico)");
                    else
                        cad.Append(" (Regular Alto)");


                    break;//LEUCOCITOS (EXM)
                case 77:

                    if (value < 140)
                        cad.Append(" (Normal)");
                    else if (value > 200)
                        cad.Append(" (Diabetes)");
                    else
                        cad.Append(" (Intolerante)");

                    break;//GLUCOSA TOMA 1
                case 78:

                    if (value < 140)
                        cad.Append(" (Normal)");
                    else if (value > 200)
                        cad.Append(" (Diabetes)");
                    else
                        cad.Append(" (Intolerante)");
                    break;//GLUCOSA TOMA 2
                
                case 174:
                    if (value > 13.5)
                        cad.Append(" (Patologico)");
                    else if (value < 11)
                        cad.Append(" (Patologico)");
                    else
                        cad.Append(" (Normal)");

                    break;//TIEMPO DE PROTOMBINA
                case 175:
                    if (value < 25)
                        cad.Append(" (Patologico)");
                    else if (value > 35)
                        cad.Append(" (Patologico)");
                    else
                        cad.Append(" (Normal)");
                    break;//TIEMPO DE TROMBOPLASTINA
                case 183:
                    if(value<=90 && value >= 80)
                        cad.Append(" (Normal)");
                    else
                        cad.Append(" (Patologico)");
                    break;//VCM
                case 184:
                    if (value >= 27 && value <= 32)
                        cad.Append(" (Normal)");
                    else
                        cad.Append(" (Patologico)");
                    break;//HCM
                case 185:
                    if (value >= 32 && value <= 36)
                        cad.Append(" (Normal)");
                    else
                        cad.Append(" (Patologico)");

                    break;//CMHC
                case 186:
                    if (tiempo.Dias <= 10 && tiempo.Mes == 0 && tiempo.Año == 0)
                    {
                        if (value < 4500)
                            cad.Append(" (Bajo)");
                        else if (value > 5100)
                            cad.Append(" (Alto)");
                        else
                            cad.Append(" (Normal)");
                    }
                    else if (tiempo.Dias > 10 && tiempo.Mes >= 0 && tiempo.Año >= 0)
                    {
                        if (value < 4500)
                            cad.Append(" (Bajo)");
                        else if (value > 5000)
                            cad.Append(" (Alto)");
                        else
                            cad.Append(" (Normal)");
                    }

                    break;//RECUENTO DE GLOBULOS ROJOS
            }
            return cad.ToString();
        }
    }
}
