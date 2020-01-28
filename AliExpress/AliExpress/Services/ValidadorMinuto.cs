using System;

namespace AliExpress.Services
{
    public class ValidadorMinuto : RecuperadorExpressionTiempo
    {
        public override string ProcesarTiempo(DateTime _dtFechaBase, DateTime _dtFechaEvaluar)
        {
            string cReturn = string.Empty;
            int iHora = 59;
            var iTotalMinutos = Math.Abs((_dtFechaBase - _dtFechaEvaluar).TotalMinutes);
            if (iTotalMinutos <= iHora)
            {
                cReturn = string.Format("{0} Minutos", (int)iTotalMinutos);
            }
            else
            {
                cReturn = base.ProcesarTiempo(_dtFechaBase, _dtFechaEvaluar);
            }
            return cReturn;
        }
    }
}
