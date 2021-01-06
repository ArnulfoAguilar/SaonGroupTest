using System;
using System.Collections.Generic;
using System.Text;
using Jobs.Domain.Entities;
using Jobs.Domain.Responses;

namespace Jobs.Infraestructure.Interfaces
{
    public interface IJobRepository
    {
        public JobResponse JobsList();
        public ResponseStatus JobAdd(Job job);
        public ResponseStatus JobEdit(Job job);
        public Job JobEditGet(int job);
        public ResponseStatus JobDelete(int JobID);

    }
}
