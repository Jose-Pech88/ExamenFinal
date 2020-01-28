using AliExpress.Data.Entities.Interfaces;
using AliExpress.Services.Interfaces;
using System;

namespace AliExpress.Services
{
    public class GeneradorMensajes : IGeneradorMensajes
    {
        public void GenerarMensajeConExpresiones(IPaqueteEnviado _paqueteEnviada)
        {
            ObtenerColor(_paqueteEnviada.lPaqueteEntregado);
            string cExpresion1 = ObtenerExpresion1(_paqueteEnviada.lPaqueteEntregado);
            string cExpresion2 = ObtenerExpresion2(_paqueteEnviada.lPaqueteEntregado);
            string cExpresion3 = ObtenerExpresion3(_paqueteEnviada.lPaqueteEntregado);
            string cExpresion4 = ObtenerExpresion4(_paqueteEnviada.lPaqueteEntregado);
            string cFormato = "Tu paquete {0} de {1} y {2} a {3} {4} {5} y {6} un costo de {7}(Cualquier reclamación con {8}).";
            string cMensaje = string.Format(cFormato, cExpresion1, _paqueteEnviada.cOrigen, cExpresion2,
                _paqueteEnviada.cDestino, cExpresion3, _paqueteEnviada.cExpresionTiempo, cExpresion4, _paqueteEnviada.dCostoEnvio, _paqueteEnviada.cPaqueteria);
            Console.WriteLine(cMensaje);
        }

        public void GenerarMensajeMedioInexistente(string _cPaqueteria, string _cMedioTransporte)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string cMensaje = string.Format(@"{0} no ofrece el servicio de transporte {1}, te recomendamos cotizar en otra empresa.", _cPaqueteria, _cMedioTransporte);
            Console.WriteLine(cMensaje);
        }

        public void GenerarMensajeCostoMenor(IPaqueteCostoMenor _paqueteCostoMenor)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            string cMensaje = string.Format("Si hubieras pedido en {0} te hubiera costado ${1} más barato.", _paqueteCostoMenor.Empresa, _paqueteCostoMenor.CostoEnvio);
            Console.WriteLine(cMensaje);
        }

        public void GenerarMensajePaqueteriaInexistente(string _cPaqueteria)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string cMensaje = string.Format("La Paquetería: {0} no se encuentra registrada en nuestra red de distribución.", _cPaqueteria);
            Console.WriteLine(cMensaje);
        }

        private void ObtenerColor(bool _lEventoPasado)
        {
            if (_lEventoPasado)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
        }
        private string ObtenerExpresion1(bool _lEventoPasado)
        {
            string cExpresion1 = string.Empty;
            if (_lEventoPasado)
            {
                cExpresion1 = "salió";
            }
            else
            {
                cExpresion1 = "ha salido";
            }
            return cExpresion1;
        }

        private string ObtenerExpresion2(bool _lEventoPasado)
        {
            string cExpresion = string.Empty;
            if (_lEventoPasado)
            {
                cExpresion = "llegó";
            }
            else
            {
                cExpresion = "llegará";
            }
            return cExpresion;
        }

        private string ObtenerExpresion3(bool _lEventoPasado)
        {
            string cExpresion = string.Empty;
            if (_lEventoPasado)
            {
                cExpresion = "hace";
            }
            else
            {
                cExpresion = "dentro de";
            }
            return cExpresion;
        }

        private string ObtenerExpresion4(bool _lEventoPasado)
        {
            string cExpresion = string.Empty;
            if (_lEventoPasado)
            {
                cExpresion = "tuvó";
            }
            else
            {
                cExpresion = "tendrá";
            }
            return cExpresion;
        }
    }
}
