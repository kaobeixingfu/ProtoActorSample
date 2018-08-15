﻿using Proto;
using System;
using System.Threading.Tasks;

namespace P001_HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {        

            //Actor产生一个props（道具）
            var props = Actor.FromProducer(() => new HelloActor());
            //从props衍生pid，pid代理一个actor的地址
            var pid = Actor.Spawn(props);
            //把Hello对象交给HelloActor处理
            pid.Tell(new Hello
            {
                Who = "Alex"
            });
            Console.ReadLine();
        }
    }
    //传递对象
    class Hello
    {
        public string Who;
    }
    //actor
    class HelloActor : IActor
    {
        //被调用
        public Task ReceiveAsync(IContext context)
        {
            var msg = context.Message;
            if (msg is Hello hello)
            {
                Console.WriteLine($"Hello {hello.Who}");
            }
            return Actor.Done;
        }
    }
}
