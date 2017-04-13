using System;
using System.Collections.Generic;
using System.Threading;

namespace Mallenom.Standard
{
	static class ExceptionExtensions
	{
		public static bool IsCritical(this Exception exception)
		{
			Assert.IsNotNull(exception);

			if(exception is NullReferenceException) return true;
			if(exception is StackOverflowException) return true;
			if(exception is OutOfMemoryException) return true;
			if(exception is ThreadAbortException) return true;
			if(exception is IndexOutOfRangeException) return true;
			if(exception is AccessViolationException) return true;
			return false;
		}

		public static IEnumerable<Exception> AsEnumerable(this Exception exception)
		{
			while(exception != null)
			{
				yield return exception;
				var aggregate = exception as AggregateException;
				if(aggregate != null)
				{
					foreach(var innerException in aggregate.InnerExceptions)
					foreach(var exc in innerException.AsEnumerable())
					{
						yield return exc;
					}
				}
				else
				{
					exception = exception.InnerException;
				}
			}
		}
	}
}
