using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
    public  class Emloyee
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string Passcode { get; set; }
        [Required]
        public string PreferredName { get; set; }
        [Required]
       // [Phone]
        public string Phonenumber { get; set; }
       
        [Required]
      //  [EmailAddress]
        public string MailId { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public string bod { get; set; }

    }
}
