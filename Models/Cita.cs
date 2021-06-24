using System;
using System.ComponentModel.DataAnnotations;

namespace MvcVeterinaria.Models
{
    public class Cita
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }

        public string Descripcion { get; set; }

        public string MascotaID { get; set; }

        public int VeterinarioID { get; set; }

        public Veterinario Veterinario { get; set; }

        public int MedicamentoID { get; set; }
        public Medicamento Medicamento { get; set; }



    }
}