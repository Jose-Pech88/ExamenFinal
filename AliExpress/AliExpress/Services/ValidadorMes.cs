using System;

namespace AliExpress.Services
{
    public class ValidadorMes : RecuperadorExpressionTiempo
    {
        public override string ProcesarTiempo(DateTime _dtFechaBase, DateTime _dtFechaEvaluar)
        {
            string cReturn = string.Empty;
            int iMes = 30;
            int iValorConvertido = 0;
            var iTotalDias = Math.Abs((_dtFechaBase - _dtFechaEvaluar).TotalDays);
            if (iTotalDias > iMes)
            {
                iValorConvertido = (int)(iTotalDias / iMes);
                cReturn = string.Format("{0} Meses", iValorConvertido);
            }
            else
            {
                cReturn = "No se pudo determinar la expressión tiempo";
            }
            return cReturn;
        }
    }
}
