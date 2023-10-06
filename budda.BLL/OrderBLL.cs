using budda.Models;

public class OrderBLL
{
    private readonly OrderDAO _orderDAO;

    public OrderBLL(OrderDAO orderDAO)
    {
        _orderDAO = orderDAO;
    }

    public Order CreateOrder(Order order)
    {
        _orderDAO.CreateOrder(order);
        return order;
    }

    public Order GetOrder(int id)
    {
        return _orderDAO.GetOrder(id);
    }

    public List<Order> GetUserOrders(string userId)
    {
        return _orderDAO.GetUserOrders(userId);
    }

    public void UpdateOrder(int id, string newStatus)
    {
        _orderDAO.UpdateOrder(id, newStatus);
    }
}