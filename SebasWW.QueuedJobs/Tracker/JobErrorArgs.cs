using System;

namespace Sebas.QueuedJobs.Tracker
{
	public class JobErrorArgs
	{
		public Job Job { get; internal set; }

		public Exception Exception { get; internal set; }

		public object CustomContext { get; set; }
	}
}