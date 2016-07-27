namespace Sheep.VHall.Core.Modules
{
    public class FetchWebinarRequest
    {
        public int type { get; set; } = 1;

        public int pos { get; set; } = 0;

        public int limit { get; set; } = 0;

        public int?[] status { get; set; } = null;

        public override string ToString()
        {
            string parameter = string.Format("&type={0}&pos={1}", type, pos);
            if (limit != 0)
                parameter += string.Format("&limit={0}", limit);
            if (status != null)
                parameter += string.Format("&status=[{0}]", string.Join(",", status));
            return parameter;
        }
    }
}
