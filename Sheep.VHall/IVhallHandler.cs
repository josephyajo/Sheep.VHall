using Sheep.VHall.Modules;

namespace Sheep.VHall
{
    public interface IVHallHandler
    {
        bool IsReady { get; }

        WebinarListResponse FetchWebinarList(FetchWebinarRequest request = null);

        WebinarStateResponse FetchWebinarState(int webinar_id);

        WebinarFetchResponse GetWebinarFetch(int webinar_id, string fields = null);

        WebinarUpdateResponse SendWebinarUpdate(WebinarUpdateRequest request);
    }
}
