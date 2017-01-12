using MinLab.Code.EntityLayer.FormatoImpresionComponentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinLab.Code.ControlSistemaInterno.ControlImpresora
{
    public class BufferImpresion
    {
        
        private List<EntityLayer.FormatoImpresionComponentes.FormatoImpresion> formatos = new List<EntityLayer.FormatoImpresionComponentes.FormatoImpresion>();
        
        private int indexFormatoActual;
        private int indexPagActual;
        private int indexLineaActual;
        

        public BufferImpresion(List<EntityLayer.FormatoImpresionComponentes.FormatoImpresion> Formatos)
        {
            this.formatos = Formatos;
            indexFormatoActual = -1;
            indexPagActual = -1;
            indexLineaActual = -1;
            IsModeRead = false;
        }
        
        public bool EmptyListFormato()
        {
            return indexFormatoActual >= formatos.Count;
        }

        public bool EmptyListPagina()
        {
            return indexPagActual >= formatos[indexFormatoActual].Paginas.Count;
        }

        public bool EmptyListLinea()
        {
            return indexLineaActual >= formatos[indexFormatoActual].Paginas[indexPagActual].Detalles.Count;
        }
        
        public FormatoImpresion GetFormato()
        {
            if (!EmptyListFormato())
                return formatos[indexFormatoActual];
            else return null;
        }

        public FormatoImpresionPagina GetPagina()
        {
            if (!EmptyListFormato()&&!EmptyListPagina())
                return formatos[indexFormatoActual].Paginas[indexPagActual];
            else return null;
            
        }

        public FormatoImpresionPaginaLinea GetLinea()
        {
            if (!EmptyListFormato() && !EmptyListPagina() && !EmptyListLinea())
                return formatos[indexFormatoActual].Paginas[indexPagActual].Detalles[indexLineaActual];
            else return null;

        }

        public bool SiguienteFormato()
        {
            indexFormatoActual++;
            indexPagActual = -1;
            indexLineaActual = -1;
            return !EmptyListFormato();
        }

        public bool SiguientePagina()
        {
            indexPagActual++;
            indexLineaActual = -1;
            return !EmptyListPagina();

        }
        public bool SiguienteLinea()
        {
            indexLineaActual++;
            return !EmptyListLinea();
        }

        public bool IsModeRead { get; set; }

    }
}
