using System;

namespace AliExpress.Services
{
    public class ValidadorDia : RecuperadorExpressionTiempo
    {
        public override string ProcesarTiempo(DateTime _dtFechaBase, DateTime _dtFechaEvaluar)
        {
            string cReturn = string.Empty;
            int iMes = 30;
            var iTotalMes = Math.Abs((_dtFechaBase - _dtFechaEvaluar).TotalDays);
            if (iTotalMes <= iMes)
            {
                cReturn = string.Format("{0} Días", (int)iTotalMes);
            }
            else
            {
                cReturn = base.ProcesarTiempo(_dtFechaBase, _dtFechaEvaluar);
            }
            return cReturn;
        }
    }
}
