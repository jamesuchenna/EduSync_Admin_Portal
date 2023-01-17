using AutoMapper;
using EduSync_Admin_Portal.DataModel;

namespace EduSync_Admin_Portal.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Student, DomainModel.Student>().ReverseMap();
            CreateMap<Address, DomainModel.Address>().ReverseMap();
            CreateMap<Gender, DomainModel.Gender>().ReverseMap();
        }
    }
}
