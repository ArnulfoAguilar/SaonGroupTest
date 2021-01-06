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
        public JobResponse JobsList()
        {
            var result = _repository.JobsList();
            return Mapper.Map<Domain.Responses.JobResponse, Dtos.Responses.JobResponse>(result);
        }
    }
}
