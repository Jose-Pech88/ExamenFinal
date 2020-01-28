using System;

namespace AliExpress.Services
{
    public class ValidadorHora : RecuperadorExpressionTiempo
    {
        public override string ProcesarTiempo(DateTime _dtFechaBase, DateTime _dtFechaEvaluar)
        {
            string cReturn = string.Empty;
            int iHora = 23;
            var iTotalHora = Math.Abs((_dtFechaBase - _dtFechaEvaluar).TotalHours);
            if (iTotalHora <= iHora)
            {
                cReturn = string.Format("{0} Horas", (int)iTotalHora);
            }
            else
            {
                cReturn = base.ProcesarTiempo(_dtFechaBase, _dtFechaEvaluar);
            }
            return cReturn;
        }
    }
}
