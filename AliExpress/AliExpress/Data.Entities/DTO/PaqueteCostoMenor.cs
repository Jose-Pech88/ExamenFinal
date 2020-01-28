using AliExpress.Data.Entities.Interfaces;

namespace AliExpress.Data.Entities.DTO
{
    public class PaqueteCostoMenor : IPaqueteCostoMenor
    {
        public string Empresa { set; get; }
        public decimal CostoEnvio { set; get; }
    }
}
