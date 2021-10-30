using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vidly.Models;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile:Profile
    {
      
        public MappingProfile()
        {
            

            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
            CreateMap<MembershipType, MembershipTypeDto>();
            CreateMap<Genre, GenreDto>();
            CreateMap<Movie, MovieDto>();
            CreateMap<MovieDto, Movie>();
          //  CreateMap<Customer, CustomerDto>()
          //.ForMember(c => c.Id, opt => opt.Ignore());

          //  CreateMap<CustomerDto, Customer>()
          //     .ForMember(c => c.Id, opt => opt.Ignore());
        }

    }
       
}
