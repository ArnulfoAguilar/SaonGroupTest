using System;
using System.Collections.Generic;
using System.Text;

namespace Jobs.Domain.Entities
{
    public class Job
    {
        public int JobID { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public string CreatedAt { get; set; }
        public string ExpiresAt { get; set; }
    }
}
