using Jobs.Core.Dtos.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jobs.Core.Dtos.Responses
{
    public class JobResponse
    {
        public List<Job> AllJobs { get; set; }
        public ResponseStatus responseStatus { get; set; }
    }
}
