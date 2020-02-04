using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sebas.QueuedJobs
{
	public abstract class Job
	{
		private JobQueue jobQueue;

		internal protected abstract Task ExecAsync();

		internal void SetQueue(JobQueue jobQueue)
		{
			this.jobQueue = jobQueue;
		}

		protected void AddJob(Job job)
		{
			jobQueue.AddJob(job);
		}
	}
}
