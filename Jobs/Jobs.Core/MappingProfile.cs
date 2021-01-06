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
            //CreateMap<Domain.Responses.ResponseStatus, Dtos.ResponseStatus>();
        }
    }
}
