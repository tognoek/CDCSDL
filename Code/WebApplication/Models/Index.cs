using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Index
    {
        public List<EducationField> EducationFields { get; set; }
        public List<JobRole> JobRoles { get; set; }
        public List<Department> Departments { get; set; }
    }
}