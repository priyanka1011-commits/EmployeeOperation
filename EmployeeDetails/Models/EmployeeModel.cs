using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EmployeeDetails.Models
{
    public class EmployeeModel
    {
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        public int age { get; set; }

        public int salary { get; set; }

        public string location { get; set; }

        public string maritalStatus { get; set; }

    }
}