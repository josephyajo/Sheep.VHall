namespace Sheep.VHall.Message
{
    public class TaskMessageHandler<TMessage> : IHandleMessages<TMessage>
    {
        public delegate dynamic VHallHandle(TMessage message);

        public event VHallHandle handle;

        public dynamic Handle(TMessage message)
        {
            return handle(message);
        }
    }
}
