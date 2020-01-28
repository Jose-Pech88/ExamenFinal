using AliExpress.Data.Entities.DTO;
using AliExpress.Data.Entities.Interfaces;
using AliExpress.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace AliExpress.Services
{
    public class RecuperadorListaPaquetes : IRecuperadorListaPaquetes
    {
        /// <summary>
        /// Dependencia de tipo IObtenedorDatosArchivo.
        /// </summary>
        private readonly IObtenedorDatosArchivo ObtenedorDatosArchivo;

        /// <summary>
        /// Contructor de la clase
        /// </summary>
        /// <param name="_obtenedorDatosArchivo">Dependencia de tipo IObtenedorDatosArchivo</param>
        public RecuperadorListaPaquetes(IObtenedorDatosArchivo _obtenedorDatosArchivo)
        {
            ObtenedorDatosArchivo = _obtenedorDatosArchivo ?? throw new ArgumentNullException(nameof(_obtenedorDatosArchivo));
        }

        /// <summary>
        /// Crea una lista de objetos EventoDTO con las información contenida en el archivo cuya ubicación es enviada como parámetro.
        /// </summary>
        /// <param name="_path">Ruta del archivo a procesar.</param>
        /// <returns>Retorna una lista de objetos de tipo EventoDTO.</returns>
        public List<IPaqueteEnviado> RecuperarListaPaquetes(string _path)
        {
            List<IPaqueteEnviado> lstEventos = new List<IPaqueteEnviado>();
            string[] arrFilas = ObtenedorDatosArchivo.LeerArchivo(_path);
            if (arrFilas != null)
            {
                lstEventos = LlenarListaEventosConArregloDatos(arrFilas);
            }
            return lstEventos;
        }

        /// <summary>
        /// Llena la lista de EventoDTO con la información contenida en el objeto enviado como parámetro.
        /// </summary>
        /// <param name="_arreglo">Arreglo que contiene la información a procesar.</param>
        /// <returns>Retorna una lista de objetos EventoDTO.</returns>
        private List<IPaqueteEnviado> LlenarListaEventosConArregloDatos(string[] _arreglo)
        {
            List<IPaqueteEnviado> lstEventos = new List<IPaqueteEnviado>();
            foreach (string item in _arreglo)
            {
                string[] arrValores = SepararValoresCadenaComa(item);
                IPaqueteEnviado evento = AsignarValoresEvento(arrValores);
                lstEventos.Add(evento);
            }
            return lstEventos;
        }

        /// <summary>
        /// Separa una cadena cuando encuentra una Coma.
        /// </summary>
        /// <param name="_cadena">Texto a separar.</param>
        /// <returns>Retorna un arreglo con la información separada por coma.</returns>
        private string[] SepararValoresCadenaComa(string _cadena)
        {
            return _cadena.Split(',');
        }

        /// <summary>
        /// Crea un objeto de tipo EventoDTO y asigna los valores que recibe como parámetro.
        /// </summary>
        /// <param name="_arrValores">Arreglo que contien los valores a asignar al DTO.</param>
        /// <returns>Retorna un objeto de tipo EventoDTO.</returns>
        private IPaqueteEnviado AsignarValoresEvento(string[] _arrValores)
        {
            IPaqueteEnviado Paquete = new PaqueteEnviado();
            switch (_arrValores.Length)
            {
                case 1:
                    Paquete.cOrigen = _arrValores[0];
                    break;
                case 2:
                    Paquete.cOrigen = _arrValores[0];
                    Paquete.cDestino = _arrValores[1];
                    break;
                case 3:
                    Paquete.cOrigen = _arrValores[0];
                    Paquete.cDestino = _arrValores[1];
                    Paquete.cDistancia = _arrValores[2];
                    break;
                case 4:
                    Paquete.cOrigen = _arrValores[0];
                    Paquete.cDestino = _arrValores[1];
                    Paquete.cDistancia = _arrValores[2];
                    Paquete.cPaqueteria = _arrValores[3];
                    break;
                case 5:
                    Paquete.cOrigen = _arrValores[0];
                    Paquete.cDestino = _arrValores[1];
                    Paquete.cDistancia = _arrValores[2];
                    Paquete.cPaqueteria = _arrValores[3];
                    Paquete.cMedioTransporte = _arrValores[4];
                    break;
                case 6:
                    Paquete.cOrigen = _arrValores[0];
                    Paquete.cDestino = _arrValores[1];
                    Paquete.cDistancia = _arrValores[2];
                    Paquete.cPaqueteria = _arrValores[3];
                    Paquete.cMedioTransporte = _arrValores[4];
                    Paquete.dtFechaPedido = Convert.ToDateTime(_arrValores[5]);
                    break;
                default:
                    break;
            }
            return Paquete;
        }
    }
}
