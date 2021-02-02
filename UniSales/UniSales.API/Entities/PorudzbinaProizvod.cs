using System.ComponentModel.DataAnnotations.Schema;

namespace UniSales.API.Entities
{

    public class PorudzbinaProizvod
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PorudzbinaProizvodID { get; set; }

        public int ProizvodID { get; set; }

        public int Cena { get; set; }

        public virtual Proizvod Proizvod { get; set; }
    }
}
