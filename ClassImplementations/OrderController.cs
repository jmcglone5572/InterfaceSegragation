using Contracts;
using System;
using System.Collections.Generic;

namespace ClassImplementations
{
    public class OrderController
    {
        private readonly IRead<Order> reader;
        private readonly ISave<Order> saver;
        private readonly IDelete<Order> deleter;

        public OrderController(IRead<Order> reader, ISave<Order> saver, IDelete<Order> deleter)
        {
            this.reader = reader;
            this.saver = saver;
            this.deleter = deleter;
        }

        public void CreateOrder(Order order)
        {
            saver.Save(order);
        }

        public Order GetSingleOrder(Guid identity)
        {
            return reader.ReadOne(identity);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return reader.ReadAll();
        }

        public void UpdateOrder(Order order)
        {
            saver.Save(order);
        }

        public void DeleteOrder(Order order)
        {
            deleter.Delete(order);
        }
    }
}
