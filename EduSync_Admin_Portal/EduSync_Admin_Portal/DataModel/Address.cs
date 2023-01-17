using System;

namespace EduSync_Admin_Portal.DataModel
{
    public class Address
    {
        public Guid Id { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }

        //Navigation property
        public Guid StudentId { get; set; }
    }
}
