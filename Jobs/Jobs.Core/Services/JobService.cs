using Jobs.Core.Dtos.Entities;
using Jobs.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Jobs.Infraestructure.Interfaces;
using AutoMapper;
using Jobs.Core.Dtos.Responses;

namespace Jobs.Core.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _repository;
        public JobService(IJobRepository repository)
        {
            _repository = repository;
        }

        public ResponseStatus Add(Job job)
        {
            var JobDomain = Mapper.Map<Dtos.Entities.Job, Domain.Entities.Job>(job);
            JobDomain.CreatedAt = job.CreatedAt.ToString("yyyy-MM-dd");
            JobDomain.ExpiresAt = job.ExpiresAt.ToString("yyyy-MM-dd");
            var result = _repository.JobAdd(JobDomain);
            return Mapper.Map<Domain.Responses.ResponseStatus, Dtos.Responses.ResponseStatus>(result);
        }

        public Job Edit(int JobID)
        {
            var result = _repository.JobEditGet(JobID);
            return Mapper.Map<Domain.Entities.Job, Dtos.Entities.Job>(result);
        }

        public JobResponse JobsList()
        {
            var result = _repository.JobsList();
            return Mapper.Map<Domain.Responses.JobResponse, Dtos.Responses.JobResponse>(result);
        }
    }
}
