using System;

namespace AliExpress.Data.Entities.Interfaces
{
    public interface IPaqueteEnviado
    {
        string cOrigen { set; get; }
        string cDestino { set; get; }
        string cDistancia { set; get; }
        string cPaqueteria { set; get; }
        string cMedioTransporte { set; get; }
        DateTime dtFechaPedido { set; get; }
        bool lPaqueteEntregado { set; get; }
        DateTime dtFechaEntrega { set; get; }
        DateTime dtFechaActual { set; get; }
        decimal dCostoEnvio { set; get; }

        string cExpresionTiempo { set; get; }
    }
}
