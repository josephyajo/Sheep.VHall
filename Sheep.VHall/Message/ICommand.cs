using System;
using System.Threading.Tasks;

namespace Sheep.VHall.Message
{
    internal interface ICommand
    {
        void Execute(Func<ISender, dynamic> command, Action<dynamic> result, Action<Exception> error);
    }
}
