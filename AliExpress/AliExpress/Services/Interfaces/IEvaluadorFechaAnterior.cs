using System;

namespace AliExpress.Services.Interfaces
{
    public interface IEvaluadorFechaAnterior
    {
        /// <summary>
        /// Evalua si la fecha a evaluar esta en el pasado o en el futuro.
        /// </summary>
        /// <param name="_dtFechaBase">Fecha actual.</param>
        /// <param name="_dtFechaEvaluar">Fecha a evaluar.</param>
        /// <returns>Retorna true si la fecha a evaluar esta en el pasado, en caso contratio retorna false.</returns>
        bool EvaluarFechaAnterior(DateTime _dtFechaBase, DateTime _dtFechaEvaluar);
    }
}
