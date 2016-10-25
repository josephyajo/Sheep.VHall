using System;
using System.Threading.Tasks;

namespace Sheep.VHall.Message
{
    internal class RequestCommand : ICommand
    {
        private ISender sender;

        public RequestCommand(ISender sender)
        {
            if (sender == null)
                throw new ArgumentNullException("sender");

            this.sender = sender;
        }

        public void Execute(Func<ISender, dynamic> command, Action<dynamic> result, Action<Exception> error)
        {
            try
            {
                result(command(sender));
            }
            catch (Exception ex)
            {
                error(ex);
            }
        }
    }
}
