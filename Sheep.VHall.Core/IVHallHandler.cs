using Sheep.VHall.Core.Modules;

namespace Sheep.VHall.Core
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
