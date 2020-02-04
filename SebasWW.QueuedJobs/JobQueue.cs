using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Sebas.QueuedJobs.Tracker;

namespace Sebas.QueuedJobs
{
	public class JobQueue
	{
		private readonly JobQueueSettings settings;
		private ConcurrentQueue<Job> queue = new ConcurrentQueue<Job>();

		public JobQueue(JobQueueSettings settings)
		{
			this.settings = settings;
		}

		public void AddJob(Job job)
		{
			job.SetQueue(this);
			queue.Enqueue(job);

			if (settings.IncreaseThreadCountWhenJobCountMoreThan > queue.Count || threadCount = 0)
				Task.Run(ProcessQueue);
		}

		private async Task ProcessQueue()
		{
			try
			{
				settings.Tracker?.OnThreadStarted(this, new ThreadStartedArgs());
			}
			catch (Exception)
			{

			}
			
			while (queue.TryDequeue(out var job))
			{
				var startingArgs = new JobStartingArgs() { Job = job };

				try
				{
					settings.Tracker?.OnJobStarting(this, startingArgs);
				}
				catch (Exception)
				{

				}

				try
				{
					await job.ExecAsync();

					try
					{
						var completedArgs = new JobCompletedArgs() { Job = job , CustomContext = startingArgs.CustomContext };

						settings.Tracker?.OnJobCompleted(this, completedArgs);
					}
					catch (Exception)
					{

					}
				}
				catch (Exception ex)
				{
					try
					{
						var errorArgs = new JobErrorArgs() { Job = job, Exception = ex, CustomContext = startingArgs.CustomContext };

						settings.Tracker?.OnJobError(this, errorArgs);
					}
					catch (Exception)
					{

					}
				}
			}

			try
			{
				settings.Tracker?.OnThreadStopped(this, new ThreadStoppedArgs());
			}
			catch (Exception)
			{

			}
		}
	}
}
