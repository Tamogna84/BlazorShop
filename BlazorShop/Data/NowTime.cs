namespace BlazorShop.Data
{
    public class NowTime : IClock
    {
        public DateTime DateNow { get; set; }
        public DayOfWeek DayOfWeek { get; set; }

        public NowTime()
        {
            DateNow = DateTime.Now;
            DayOfWeek = DateTime.Now.DayOfWeek;
        }
		public DateTime GetTime()
		{
			return DateTime.Now;
		}

        NowTime IClock.GetTime()
        {
            throw new NotImplementedException();
        }
    }
}
