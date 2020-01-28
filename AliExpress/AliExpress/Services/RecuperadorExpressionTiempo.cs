using AliExpress.Services.Interfaces;
using System;

namespace AliExpress.Services
{
    public abstract class RecuperadorExpressionTiempo : IRecuperadorExpressionTiempo
    {
        private IRecuperadorExpressionTiempo _nextHandler;
        public IRecuperadorExpressionTiempo SiguienteNivel(IRecuperadorExpressionTiempo _recuperadorExpressionTiempo)
        {
            this._nextHandler = _recuperadorExpressionTiempo;

            return _nextHandler;
        }

        public virtual string ProcesarTiempo(DateTime _dtFechaBase, DateTime _dtFechaEvaluar)
        {
            string cReturn = string.Empty;
            if (this._nextHandler != null)
            {
                cReturn = this._nextHandler.ProcesarTiempo(_dtFechaBase, _dtFechaEvaluar);
            }
            return cReturn;
        }
    }
}
