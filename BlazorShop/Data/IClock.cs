namespace BlazorShop.Data
{
    public interface IClock
    {
        DateTime DateNow { get; set; }
        DayOfWeek DayOfWeek { get; set; }

		public NowTime GetTime();
	}
}