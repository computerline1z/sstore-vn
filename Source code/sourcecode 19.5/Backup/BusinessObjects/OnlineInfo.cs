
namespace Mode
{
    public class OnlineInfo
    {
        private int id;
        private int online;
        private int total;
        public OnlineInfo(int id, int online, int total)
        {
            id = id;
            Online = online;
            Total = total;
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int Online
        {
            get { return online; }
            set { online = value; }
        }

        public int Total
        {
            get { return total; }
            set { total = value; }
        }
    }
}
