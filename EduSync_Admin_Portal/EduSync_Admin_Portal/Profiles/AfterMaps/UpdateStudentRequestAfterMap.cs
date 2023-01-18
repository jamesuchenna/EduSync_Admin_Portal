using AutoMapper;
using EduSync_Admin_Portal.DomainModel;
using Address = EduSync_Admin_Portal.DataModel.Address;
using Student = EduSync_Admin_Portal.DataModel.Student;

namespace EduSync_Admin_Portal.Profiles.AfterMaps
{
    public class UpdateStudentRequestAfterMap : IMappingAction<UpdateStudentRequest, Student>
    {
        public void Process(UpdateStudentRequest source, Student destination, ResolutionContext context)
        {
            destination.Address = new Address()
            {
                PhysicalAddress = source.PhysicalAddress,
                PostalAddress = source.PostalAddress
            };
        }
    }
}
