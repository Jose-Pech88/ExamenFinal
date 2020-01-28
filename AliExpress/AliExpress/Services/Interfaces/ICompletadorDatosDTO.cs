using AliExpress.Data.Entities.Interfaces;

namespace AliExpress.Services.Interfaces
{
    public interface ICompletadorDatosDTO
    {
        /// <summary>
        /// Llena la propiedades del DTO.
        /// </summary>
        /// <param name="_paqueteEnviado">Dto a llenar.</param>
        void LlenarDTOPaquete(IPaqueteEnviado _paqueteEnviado);
    }
}
