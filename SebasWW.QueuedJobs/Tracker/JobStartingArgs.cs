namespace Sebas.QueuedJobs.Tracker
{
	public class JobStartingArgs
	{
		public Job Job { get; internal set; }

		public object CustomContext { get; set; }
	}
}