using System.Reflection;

namespace Sheep.VHall.Modules
{
    public class WebinarFetchResponse : BaseResponse
    {
        public WebinarFetchData data { get; set; }
    }

    public class WebinarFetchData
    {
        public int id { get; set; }

        public string alias_name { get; set; }

        public int user_id { get; set; }

        public string subject { get; set; }

        public string introduction { get; set; }

        public string img_url { get; set; }

        public int category { get; set; }

        public int is_open { get; set; }

        public int layout { get; set; }

        public int verify { get; set; }

        public string password { get; set; }

        public int type { get; set; }

        public int is_single_video { get; set; }

        public int is_iframe { get; set; }

        public int auto_record { get; set; }

        public int is_chat { get; set; }

        public int buffer { get; set; }

        public string t_start { get; set; }

        public string end_time { get; set; }

        public string host { get; set; }

        public string live_start_time { get; set; }

        public override string ToString()
        {
            string fileds = string.Empty;
            PropertyInfo[] props = this.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                fileds += prop.Name + ",";
            }
            return fileds.Substring(0, fileds.Length - 1);
        }
    }
}
