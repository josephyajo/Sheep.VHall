namespace Sheep.VHall.Message
{
    internal interface ISender
    {
        dynamic Send(string request);
    }
}
