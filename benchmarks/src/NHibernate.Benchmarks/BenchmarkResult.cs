using System;

namespace NHibernate.Benchmarks
{
	public class BenchmarkResult
	{
		// Machine info

		public virtual string MachineName { get; set; }
		public virtual string Framework { get; set; }
		public virtual string Architecture { get; set; }

		// Test info

		public virtual string TestClassFullName { get; set; }
		public virtual string TestClass { get; set; }
		public virtual string TestMethodName { get; set; }
		public virtual string Variation { get; set; }

		public virtual string NHibernateVersion { get; set; }
		public virtual string CustomData { get; set; }

		// Run data

		public virtual DateTime ReportingTime { get; set; }
		public virtual int WarmupIterations { get; set; }
		public virtual int MainIterations { get; set; }

		// Result info
		// Computation time

		public double TimeElapsedMean { get; set; }
		public double TimeElapsedPercentile90 { get; set; }
		public double TimeElapsedPercentile95 { get; set; }
		public double TimeElapsedStandardError { get; set; }
		public double TimeElapsedStandardDeviation { get; set; }

		// Allocated Memory
		public double MemoryAllocated { get; set; }
	}
}
