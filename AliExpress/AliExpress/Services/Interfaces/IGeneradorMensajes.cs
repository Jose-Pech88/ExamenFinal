using AliExpress.Data.Entities.Interfaces;

namespace AliExpress.Services.Interfaces
{
    public interface IGeneradorMensajes
    {
        void GenerarMensajePaqueteriaInexistente(string _cPaqueteria);
        void GenerarMensajeMedioInexistente(string _cPaqueteria, string _CMedioTransporte);
        void GenerarMensajeConExpresiones(IPaqueteEnviado _paqueteEnviada);
        void GenerarMensajeCostoMenor(IPaqueteCostoMenor _paqueteCostoMenor);
    }
}
