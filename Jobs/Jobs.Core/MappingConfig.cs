using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jobs.Core
{
    public class MappingConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(config => config.AddProfile(new MappingProfile()));
        }
    }
}
