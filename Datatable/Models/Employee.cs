using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace Datatable.Models
{
    public class EmployeeModel
    {
        public EmployeeModel()         
        {           
        }
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Location { get; set; }
        public double Age { get; set; }
        public double Salary { get; set; }
        public string Property { get; set; }

    }
}
