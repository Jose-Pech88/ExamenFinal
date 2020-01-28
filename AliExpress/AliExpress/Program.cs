using AliExpress.Data.Entities;
using AliExpress.Data.Entities.Interfaces;
using AliExpress.Services;
using AliExpress.Services.Factory;
using AliExpress.Services.Interfaces;
using System;
using System.IO;

namespace AliExpress
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                InicializarAplicacion();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Inicializa la aplicación.
        /// </summary>
        private static void InicializarAplicacion()
        {
            DateTime dtFechaBase = new DateTime(2020, 01, 23, 14, 00, 00);

            //Se obtiene la ruta del archivo.
            string cPath = string.Format("{0}{1}", Directory.GetCurrentDirectory(), @"\AppData\Paquetes.csv");
            IRecuperadorConfiguracionTransportista recuperadorConfiguracionTransportista = new RecuperadorConfiguracionTransportista();
            IGeneradorMensajes generadorMensajes = new GeneradorMensajes();
            IObtenedorDatosArchivo obtenedorDatosArchivo = new ObtenedorDatosArchivo();
            IEvaluadorFechaAnterior evaluadorFechaAnterior = new EvaluadorFechaAnterior();
            IObtenedorTiempo obtenedorTiempo = new ObtenedorTiempo();
            ICompletadorDatosDTO completadorDatosDTO = new CompletadorDatosDTO(evaluadorFechaAnterior, obtenedorTiempo);
            IRecuperadorListaPaquetes recuperadorListaPaquetes = new RecuperadorListaPaquetes(obtenedorDatosArchivo);
            RecuperadorTransportistaFactory recuperadorTransportistaFactory = new RecuperadorTransportistaFactory(recuperadorConfiguracionTransportista, generadorMensajes);
            IEnlistadorPaqueteriaDisponibles enlistadorPaqueteriaDisponibles = new EnlistadorPaqueteriasDisponibles(recuperadorTransportistaFactory);
            IObtenedorCostoEnvioMenor obtenedorCostoEnvioMenor = new ObtenedorCostoEnvioMenor(enlistadorPaqueteriaDisponibles);
            IObtenedorMensajePaquetes ObtenedorMensajePaquetes = new ObtenedorMensajePaquetes(recuperadorListaPaquetes, recuperadorTransportistaFactory, completadorDatosDTO, generadorMensajes, obtenedorCostoEnvioMenor);
            ObtenedorMensajePaquetes.ObtenerMensaje(cPath, dtFechaBase);
            Console.WriteLine("\r\nPresione una tecla para salir.");
            System.Console.ReadKey();
        }
    }
}
