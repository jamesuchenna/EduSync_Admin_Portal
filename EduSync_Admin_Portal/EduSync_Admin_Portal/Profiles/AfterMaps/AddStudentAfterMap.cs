using AutoMapper;
using EduSync_Admin_Portal.DomainModel;
using System;
using Address = EduSync_Admin_Portal.DataModel.Address;
using Student = EduSync_Admin_Portal.DataModel.Student;

namespace EduSync_Admin_Portal.Profiles.AfterMaps
{
    public class AddStudentAfterMap : IMappingAction<AddStudentRequest, Student>
    {
        public void Process(AddStudentRequest source, Student destination, ResolutionContext context)
        {
            destination.Id = Guid.NewGuid();
            destination.Address = new Address()
            {
                PhysicalAddress= source.PhysicalAddress,
                PostalAddress= source.PostalAddress
            };
        }
    }
}
