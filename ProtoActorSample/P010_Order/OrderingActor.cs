﻿using P010_Libs;
using Proto;
using System.Threading.Tasks;

namespace P010_Order
{
    public class OrderingActor : IActor
    {
        public Task ReceiveAsync(IContext context)
        {
            switch (context.Message)
            {
                case Ship ship:
                    context.Parent.Tell(ship);
                    break;
            }
            return Actor.Done;
        }
    }
}