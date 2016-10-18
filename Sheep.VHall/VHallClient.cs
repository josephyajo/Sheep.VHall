using Sheep.VHall.Message;
using System;
using System.Linq;
using System.Reflection;

namespace Sheep.VHall
{
    /// <summary>
    /// 微吼客户端
    /// </summary>
    /// <typeparam name="TService">服务模块</typeparam>
    public class VHallClient<TService>
    {
        /// <summary>
        /// 消息处理
        /// </summary>
        /// <typeparam name="TMessage">消息类型</typeparam>
        /// <param name="message">消息对象</param>
        /// <returns>返回值</returns>
        public static dynamic Handle<TMessage>(TMessage message)
        {
            Type type = typeof(TService);
            TaskMessageHandler<TMessage> handler = new TaskMessageHandler<TMessage>();
            object target = Activator.CreateInstance(type);
            MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (MethodInfo method in methods)
            {
                if (method.GetParameters().First().ParameterType.Name.Equals(message.GetType().Name))
                {
                    handler.handle += Delegate.CreateDelegate(typeof(TaskMessageHandler<TMessage>.VHallHandle), target, method) as TaskMessageHandler<TMessage>.VHallHandle;
                    break;
                }
            }
            return handler.Handle(message);
        }
    }
}