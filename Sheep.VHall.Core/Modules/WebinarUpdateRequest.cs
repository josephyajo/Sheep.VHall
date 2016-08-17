using Sheep.VHall.Core.Util;
using System;
using System.Reflection;

namespace Sheep.VHall.Core.Modules
{
    public class WebinarUpdateRequest
    {
        public int webinar_id { get; set; }

        public string subject { get; set; }

        public int start_time { get; set; }

        public int? use_global_k { get; set; }

        public int? exist_3rd_auth { get; set; }

        public string auth_url { get; set; }

        public string introduction { get; set; }

        public int? layout { get; set; }

        public int? is_open { get; set; }

        public int? auto_record { get; set; }

        public int? is_chat { get; set; }

        public string host { get; set; }

        public int? buffer { get; set; }

        public override string ToString()
        {
            string parameter = string.Empty;
            PropertyInfo[] props = this.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                Func<object, object> getValue = ReappearMember.CreatePropertyGetter(prop);
                object obj = getValue(this);
                if (obj != null)
                    parameter += "&" + prop.Name + "=" + obj.ToString();
            }
            return parameter;
        }
    }
}
