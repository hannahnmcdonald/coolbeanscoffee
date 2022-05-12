using System.Collections.Generic;
using coolbeanscoffee.data.Models;

namespace coolbeanscoffee.services.Order {
    public interface IOrderService {
        List<SalesOrder> GetOrders();
        ServiceResponse<bool> GenerateOpenOrder(SalesOrder order);
        ServiceResponse<bool> MarkFulfilled(int id);
    }
}