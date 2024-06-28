using AutoMapper;
using CheshmAsali.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheshmAsali.Domain.Business.Mapping
{
    public static class ModelMapper
    {
        private static IMapper? mapper;
        public static IMapper Init()
        {
            if(mapper == null)
            {
                var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<Customer, Domain.Models.Customer>());

                mapper = config.CreateMapper();
            };
            return mapper;
        }

    }
}
