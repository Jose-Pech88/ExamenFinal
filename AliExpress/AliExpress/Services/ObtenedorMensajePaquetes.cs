using AliExpress.Data.Entities.Interfaces;
using AliExpress.Services.Factory.Interfaces;
using AliExpress.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace AliExpress.Services
{
    public class ObtenedorMensajePaquetes : IObtenedorMensajePaquetes
    {
        /// <summary>
        /// Dependencia de tipo IRecuperadorListaEvento.
        /// </summary>
        private readonly IRecuperadorListaPaquetes RecuperadorListaPaquetes;

        /// <summary>
        /// Dependencia de tipo ICreadorMensajeFactory.
        /// </summary>
        private readonly IRecuperadorTransportistas RecuperadorTransportistaFactory;

        /// <summary>
        /// Dependencia de tipo IComplementadorDatosDTO.
        /// </summary>
        private readonly ICompletadorDatosDTO CompletadorDatosDTO;

        private readonly IGeneradorMensajes GeneradorMensajes;

        private readonly IObtenedorCostoEnvioMenor ObtenedorCostoEnvioMenor;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="_recuperadorListaEvento">Dependencia de tipo IRecuperadorListaPaquetes.</param>
        /// <param name="_creadorMensajeFactory">Dependencia de tipo ICreadorMensajeFactory.</param>
        /// <param name="_completadorDatosDTO">Dependencia de tipo IComplementadorDatosDTO.</param>
        public ObtenedorMensajePaquetes(IRecuperadorListaPaquetes _recuperadorListaPaquetes, IRecuperadorTransportistas _recuperadorTransportistaFactory, ICompletadorDatosDTO _completadorDatosDTO, IGeneradorMensajes _generadorMensajes, IObtenedorCostoEnvioMenor _obtenedorCostoEnvioMenor)
        {
            RecuperadorListaPaquetes = _recuperadorListaPaquetes ?? throw new ArgumentNullException(nameof(_recuperadorListaPaquetes));
            RecuperadorTransportistaFactory = _recuperadorTransportistaFactory ?? throw new ArgumentNullException(nameof(_recuperadorTransportistaFactory));
            CompletadorDatosDTO = _completadorDatosDTO ?? throw new ArgumentNullException(nameof(_completadorDatosDTO));
            GeneradorMensajes = _generadorMensajes ?? throw new ArgumentNullException(nameof(_generadorMensajes));
            ObtenedorCostoEnvioMenor = _obtenedorCostoEnvioMenor ?? throw new ArgumentNullException(nameof(_obtenedorCostoEnvioMenor));
        }

        /// <summary>
        /// Obtiene el mensaje a mostrar.
        /// </summary>
        /// <param name="_path">Dirección física del archivo a leer.</param>
        /// <param name="_dtFechaBase">Fecha Base que servirá para comparar.</param>
        public void ObtenerMensaje(string _path, DateTime _dtFechaBase)
        {
            List<IPaqueteEnviado> lstPaquetes = RecuperadorListaPaquetes.RecuperarListaPaquetes(_path);
            ObtenerMensajeDeListaEventos(lstPaquetes, _dtFechaBase);
        }

        /// <summary>
        /// Obtiene el mensaje a mostrar de acuerdo a los registros contenidos en la lista de Evento.
        /// </summary>
        /// <param name="_lstEvento">Listo de objetos de objetos DTO´s</param>
        /// <param name="_dtFechaBase">Fecha Base que servira para comparar.</param>
        /// <returns>Retorna una cadena que contiene la concatenación de los mensajes de cada item de la lista.</returns>
        private void ObtenerMensajeDeListaEventos(List<IPaqueteEnviado> _lstEvento, DateTime _dtFechaBase)
        {
            foreach (IPaqueteEnviado item in _lstEvento)
            {
                if (item.dtFechaPedido != DateTime.MinValue)
                {
                    item.dtFechaActual = _dtFechaBase;
                    ITransportistas Transportistas = RecuperadorTransportistaFactory.ObtenerTransportista(item.cPaqueteria);
                    if (Transportistas != null)
                    {
                        if (Transportistas.ProcesarDTOPaqueteEnviado(item))
                        {
                            CompletadorDatosDTO.LlenarDTOPaquete(item);
                            GeneradorMensajes.GenerarMensajeConExpresiones(item);
                            IPaqueteCostoMenor paqueteCostoMenor = ObtenedorCostoEnvioMenor.RecuperarDTOCostoMenor(item);
                            if (paqueteCostoMenor != null)
                            {
                                GeneradorMensajes.GenerarMensajeCostoMenor(paqueteCostoMenor);
                            }
                        }
                    }
                    else
                    {
                        GeneradorMensajes.GenerarMensajePaqueteriaInexistente(item.cPaqueteria);
                    }
                }
            }
        }
    }
}
