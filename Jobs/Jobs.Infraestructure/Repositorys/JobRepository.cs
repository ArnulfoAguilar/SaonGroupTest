using Jobs.Domain.Entities;
using Jobs.Domain.Responses;
using Jobs.Infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jobs.Infraestructure.Repositorys
{
    public class JobRepository : IJobRepository
    {
        public ResponseStatus JobAdd(Job job)
        {
            throw new NotImplementedException();
        }

        public ResponseStatus JobDelete(int JobID)
        {
            throw new NotImplementedException();
        }

        public ResponseStatus JobEdit(Job job)
        {
            throw new NotImplementedException();
        }

        public List<Job> JobsList()
        {
            throw new NotImplementedException();
        }
    }
}
