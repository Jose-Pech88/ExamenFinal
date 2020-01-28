using AliExpress.Data.Entities.Interfaces;
using AliExpress.Services.Interfaces;
using System;

namespace AliExpress.Services
{
    public class CompletadorDatosDTO : ICompletadorDatosDTO
    {
        /// <summary>
        /// Dependencia de tipo IEvaluadorFechaAnterior.
        /// </summary>
        private readonly IEvaluadorFechaAnterior EvaluadorFechaAnterior;

        /// <summary>
        /// Dependencia de tipo IObtenedorTiempo.
        /// </summary>
        private readonly IObtenedorTiempo RecuperadorTiempo;

        /// <summary>
        /// Contructor de la clase.
        /// </summary>
        /// <param name="_evaluadorFechaAnterior">Dependencia de tipo IEvaluadorFechaAnterior.</param>
        /// <param name="_recuperadorTiempo">Dependencia de tipo IRecuperadorTiempoEvento.</param>
        public CompletadorDatosDTO(IEvaluadorFechaAnterior _evaluadorFechaAnterior, IObtenedorTiempo _recuperadorTiempo)
        {
            EvaluadorFechaAnterior = _evaluadorFechaAnterior ?? throw new ArgumentNullException(nameof(_evaluadorFechaAnterior));
            RecuperadorTiempo = _recuperadorTiempo ?? throw new ArgumentNullException(nameof(_recuperadorTiempo));
        }

        /// <summary>
        /// Llena la propiedades del DTO.
        /// </summary>
        /// <param name="_paqueteEnviado">Dto a llenar.</param>
        public void LlenarDTOPaquete(IPaqueteEnviado _paqueteEnviado)
        {
            if (_paqueteEnviado == null)
                throw new ArgumentNullException(nameof(_paqueteEnviado));
            _paqueteEnviado.lPaqueteEntregado = EvaluadorFechaAnterior.EvaluarFechaAnterior(_paqueteEnviado.dtFechaActual, _paqueteEnviado.dtFechaEntrega);
            _paqueteEnviado.cExpresionTiempo = RecuperadorTiempo.RecuperarExpresionTiempo().ProcesarTiempo(_paqueteEnviado.dtFechaActual, _paqueteEnviado.dtFechaEntrega);
        }
    }
}
