namespace coolbeanscoffee.services.Customer {
    public interface ICustomerService {
        List<data.Models.Customer> GetAllCustomers();
        ServiceResponse<data.Models.Customer> CreateCustomer(data.Models.Customer customer);
        ServiceResponse<bool> DeleteCustomer(int id);
        data.Models.Customer GetById(int id);
    }
}