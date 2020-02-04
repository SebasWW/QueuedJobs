using System;
using System.Collections.Generic;
using System.Text;
using Sebas.QueuedJobs.Tracker;

namespace Sebas.QueuedJobs
{
	public class JobQueueSettings
	{
		public uint IncreaseThreadCountWhenJobCountMoreThan { get; set; }

		public IJobQueueTracker Tracker { get; set; }
	}
}
