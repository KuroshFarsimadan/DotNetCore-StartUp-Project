
using AutoMapper;
using Project_Skeleton.Entities;
using Project_Skeleton.Models;

namespace Project_Skeleton.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // Map from User to UserDTO
            /*
             * You will see the following in real world applications
             * where you have a legacy application using a completely different
             * data structure than what you are building on top of it for example
             * in Angular 8. 
             */
            CreateMap<OrderItemDTO, OrderItem>().ReverseMap();
            CreateMap<User, UserDTO>();
            CreateMap<Product, ProductDTO>();
            CreateMap<OrderDTO, Order>()
                .ForMember(o => o.Id, ex => ex.MapFrom(o => o.Id)).ReverseMap();

        }
    }
}
