using AutoMapper;
using EduSync_Admin_Portal.DataModel;
using EduSync_Admin_Portal.DomainModel;
using EduSync_Admin_Portal.Profiles.AfterMaps;
using Address = EduSync_Admin_Portal.DataModel.Address;
using Gender = EduSync_Admin_Portal.DataModel.Gender;
using Student = EduSync_Admin_Portal.DataModel.Student;

namespace EduSync_Admin_Portal.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Student, DomainModel.Student>().ReverseMap();
            CreateMap<Address, DomainModel.Address>().ReverseMap();
            CreateMap<Gender, DomainModel.Gender>().ReverseMap();
            CreateMap<UpdateStudentRequest, Student>()
                .AfterMap<UpdateStudentRequestAfterMap>();
        }
    }
}
