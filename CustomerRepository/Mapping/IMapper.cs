namespace RepositoryLayer.Mapping
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CommonModels;
    using DataAccessLayer.Models;

    public interface IMapper
    {
        CustomerEntity? ToDataLayer(Customer? customer);

        Customer? ToCommon(CustomerEntity? customerEntity);
    }
}
