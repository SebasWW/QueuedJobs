namespace Sebas.QueuedJobs.Tracker
{
	public class JobCompletedArgs
	{
		public Job Job { get; internal set; }

		public object CustomContext { get; set; }
	}
}