using Contracts;
using System;
using System.Collections.Generic;

namespace ClassImplementations
{
    public class OrderReader: IRead<Order>
    {
        IEnumerable<Order> IRead<Order>.ReadAll()
        {
            return new List<Order>(); // TODO: Implement the method.
        }

        Order IRead<Order>.ReadOne(Guid identity)
        {
            return new Order(); // TODO: Implement the method.
        }
    }
}
