using System;
using System.Collections.Generic;
using System.Text;

namespace Sebas.QueuedJobs.Tracker
{
	public interface IJobQueueTracker
	{
		void OnThreadStarted(JobQueue jobQueue, ThreadStartedArgs args);
		void OnThreadStopped(JobQueue jobQueue, ThreadStoppedArgs args);

		void OnJobStarting(JobQueue jobQueue, JobStartingArgs args);
		void OnJobError(JobQueue jobQueue, JobErrorArgs args);
		void OnJobCompleted(JobQueue jobQueue, JobCompletedArgs args);
	}
}
