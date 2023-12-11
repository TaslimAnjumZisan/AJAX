using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AJAX.Models
{
    public class TransectionModel
    {
        [Key]
        public int TransectionId { get; set; }
        
        [Required]
        public string AccountNumber { get; set; }
        
        [Required]

        public string BenificiaryName { get; set; }
       
        [Required]

        public string BankName { get; set; }
        
        [Required]

        public string SWIFTCode { get; set; }
        public int Amount { get; set; }

        public DateTime Date {  get; set; }
    }
}
