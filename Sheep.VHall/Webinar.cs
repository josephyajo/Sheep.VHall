using Sheep.Kernel.Validation;
using Sheep.VHall.Message;
using Sheep.VHall.Modules;
using Sheep.VHall.Modules.Webinar.Accept;
using Sheep.VHall.Modules.Webinar.Send;
using System;

namespace Sheep.VHall
{
    /// <summary>
    /// 活动管理
    /// </summary>
    public class Webinar :
        IHandleMessages<WebinarList>,
        IHandleMessages<WebinarState>,
        IHandleMessages<WebinarFetch>,
        IHandleMessages<WebinarUpdate>
    {
        public dynamic Handle(WebinarFetch webinarFetch)
        {
            var validationResult = ValidationManager.Validate(webinarFetch);
            if (validationResult.IsValid)
            {
                VHallData data = new VHallData();
                data.InitVHallData(webinarFetch);
                data.SetValue("sign", data.MakeSign());

                WebinarFetchAccept result = null;
                Exception error = null;
                ICommand currentCommand = new RequestCommand(webinarFetch);
                string request = string.Format("{0}{1}?{2}", ServiceInfo.GATEWAY, ServiceInfo.WEBINAR_FETCH, data.ToUrl());
                currentCommand.Execute(s => { return s.Send(request); }, r => { result = r; }, e => { error = e; });
                if (error == null)
                    return result;
                else
                    return error.Message;
            }
            return validationResult;
        }

        public dynamic Handle(WebinarState webinarState)
        {
            var validationResult = ValidationManager.Validate(webinarState);
            if (validationResult.IsValid)
            {
                VHallData data = new VHallData();
                data.InitVHallData(webinarState);
                data.SetValue("sign", data.MakeSign());

                WebinarStateAccept result = null;
                Exception error = null;
                ICommand currentCommand = new RequestCommand(webinarState);
                string request = string.Format("{0}{1}?{2}", ServiceInfo.GATEWAY, ServiceInfo.WEBINAR_STATE, data.ToUrl());
                currentCommand.Execute(s => { return s.Send(request); }, r => { result = r; }, e => { error = e; });
                if (error == null)
                    return result;
                else
                    return error.Message;
            }
            return validationResult;
        }

        public dynamic Handle(WebinarList webinarList)
        {
            var validationResult = ValidationManager.Validate(webinarList);
            if (validationResult.IsValid)
            {
                VHallData data = new VHallData();
                data.InitVHallData(webinarList);
                data.SetValue("sign", data.MakeSign());

                WebinarListAccept result = null;
                Exception error = null;
                ICommand currentCommand = new RequestCommand(webinarList);
                string request = string.Format("{0}{1}?{2}", ServiceInfo.GATEWAY, ServiceInfo.WEBINAR_LIST, data.ToUrl());
                currentCommand.Execute(s => { return s.Send(request); }, r => { result = r; }, e => { error = e; });
                if (error == null)
                    return result;
                else
                    return error.Message;
            }
            return validationResult;
        }

        public dynamic Handle(WebinarUpdate webinarUpdate)
        {
            var validationResult = ValidationManager.Validate(webinarUpdate);
            if (validationResult.IsValid)
            {
                VHallData data = new VHallData();
                data.InitVHallData(webinarUpdate);
                data.SetValue("sign", data.MakeSign());

                WebinarUpdateAccept result = null;
                Exception error = null;
                ICommand currentCommand = new RequestCommand(webinarUpdate);
                string request = string.Format("{0}{1}?{2}", ServiceInfo.GATEWAY, ServiceInfo.WEBINAR_UPDATE, data.ToUrl());
                currentCommand.Execute(s => { return s.Send(request); }, r => { result = r; }, e => { error = e; });
                if (error == null)
                    return result;
                else
                    return error.Message;
            }
            return validationResult;
        }
    }
}
