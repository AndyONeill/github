using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PeopleData.Models
{
    [ModelMetadataType(typeof(PersonMetaData))]
    public partial class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public int? HouseNumber { get; set; }
        public string Road { get; set; }
        public string PostCode { get; set; }
    }
}
