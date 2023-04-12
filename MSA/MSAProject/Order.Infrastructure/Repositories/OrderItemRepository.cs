﻿using Order.Domain.AggregateModels;

namespace Order.Infrastructure.Repositories;

public class OrderItemRepository : IOrderItemRepository
{
    private readonly DbContextModel _dbContext;
    public OrderItemRepository(DbContextModel dbContext)
    {
        this._dbContext = dbContext;
    }
    public void AddOrderItem(string CustomerId, int ProductId, int Quantity, decimal Price, string IP)
    {
        var newOrderItem = new OrderItem(CustomerId, ProductId, Quantity, Price, IP);
        _dbContext.OrderItem.Add(newOrderItem);
        _dbContext.SaveChanges();
    }
    public int getLastOrderId()
    {
        var order = _dbContext.OrderItem.OrderBy(r => r.OrderId).LastOrDefault();
        return order.OrderId;
    }
}