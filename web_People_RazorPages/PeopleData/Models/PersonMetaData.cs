using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PeopleData.Models
{
    public class PersonMetaData
    {
        [Required]
        [StringLength(50, ErrorMessage ="First Name must have minimum 3 maximum 50 characters", MinimumLength=3)]
        public string FirstName { get; set; }
    }
}
