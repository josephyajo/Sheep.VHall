using Sheep.Kernel.Reflaction;
using Sheep.VHall.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sheep.VHall.Modules
{
    public class VHallData
    {
        private SortedDictionary<string, object> values = new SortedDictionary<string, object>();

        public void InitVHallData<T>(T obj)
        {
            VHallData data = new VHallData();
            PropertyInfo[] props = typeof(T).GetProperties();
            foreach (PropertyInfo prop in props)
            {
                Func<object, object> getValue = ReappearMember.CreatePropertyGetter(prop);
                object value = getValue(this);
                if (value != null) SetValue(prop.Name, value);
            }
        }

        public void SetValue(string key, object value)
        {
            values[key] = value;
        }

        public object GetValue(string key)
        {
            object o = null;
            values.TryGetValue(key, out o);
            return o;
        }

        public SortedDictionary<string, object> GetValues()
        {
            return values;
        }

        public void SetValues(SortedDictionary<string, object> values)
        {
            this.values = values;
        }

        public string ToUrl()
        {
            List<string> url = new List<string>();
            foreach (KeyValuePair<string, object> pair in values)
            {
                if (pair.Value == null)
                    continue;

                url.Add(string.Format("{0}={1}", pair.Key, pair.Value));
            }
            return string.Join("&", url);
        }

        public string MakeSign()
        {
            string sign = string.Empty;
            string secret_key = sign = GenerateHandler.Config.SecretKey;

            foreach (KeyValuePair<string, object> pair in values)
            {
                if (pair.Value == null)
                    continue;

                string.Join("", sign, pair.Key, pair.Value);
            }
            return string.Join("", sign, secret_key);
        }
    }
}
