namespace RepositoryLayer.Mapping.Imp
{
    using CommonModels;
    using DataAccessLayer.Models;

    /// <summary>
    /// handle mapping - could use third party library
    /// </summary>
    partial class Mapper
    {
        public CustomerEntity? ToDataLayer(Customer? customer)
        {
            if (customer == null) return null;

            return new CustomerEntity
            {
                Id = customer.Id,
                Name = customer.Name,
                Reference = customer.Reference
            };
        }

        public Customer? ToCommon(CustomerEntity? customerEntity)
        {
            if (customerEntity == null) return null;

            return new Customer()
            {
                Id = customerEntity.Id,
                Name = customerEntity.Name,
                Reference = customerEntity.Reference
            };
        }
    }
}
