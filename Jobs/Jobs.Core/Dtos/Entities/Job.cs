using System;
using System.Collections.Generic;
using System.Text;

namespace Jobs.Core.Dtos.Entities
{
    public class Job
    {
        public int JobID { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
