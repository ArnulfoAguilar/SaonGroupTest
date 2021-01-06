using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jobs.Core
{
    class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain -> Dto
            CreateMap<Domain.Responses.ResponseStatus, Dtos.Responses.ResponseStatus>();
            CreateMap<Domain.Responses.JobResponse, Dtos.Responses.JobResponse>();
            CreateMap<Domain.Entities.Job, Dtos.Entities.Job>();

            //dto->domain
            CreateMap<Dtos.Responses.ResponseStatus, Domain.Responses.ResponseStatus>();
            CreateMap<Dtos.Responses.JobResponse, Domain.Responses.JobResponse>();
            CreateMap<Dtos.Entities.Job, Domain.Entities.Job>();
        }
    }
}
