using AliExpress.Data.Entities.Interfaces;
using System;

namespace AliExpress.Data.Entities.DTO
{
    public class PaqueteEnviado : IPaqueteEnviado
    {
        public string cOrigen { set; get; }
        public string cDestino { set; get; }
        public string cDistancia { set; get; }
        public string cPaqueteria { set; get; }
        public string cMedioTransporte { set; get; }
        public DateTime dtFechaPedido { set; get; }
        public bool lPaqueteEntregado { set; get; }
        public DateTime dtFechaEntrega { set; get; }
        public DateTime dtFechaActual { set; get; }
        public decimal dCostoEnvio { set; get; }
        public string cExpresionTiempo { set; get; }
    }
}
