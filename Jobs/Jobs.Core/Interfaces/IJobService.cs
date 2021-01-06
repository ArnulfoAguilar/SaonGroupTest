using Jobs.Core.Dtos.Entities;
using Jobs.Core.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jobs.Core.Interfaces
{
    public interface IJobService
    {
        JobResponse JobsList();
        ResponseStatus Add(Job job);
        Job Edit(int JobID);
    }
}
