using System;
using System.Diagnostics;
using Traveller.Core.Contracts;

namespace Traveller.Core.Decorators
{
    public class EngineTimerDecorator : IEngine
    {
        private readonly IWriter writer;
        private readonly Stopwatch timer = new Stopwatch();

        public EngineTimerDecorator(IWriter writer)
        {
            this.writer = writer ?? throw new ArgumentNullException("writer");
        }

        public void Start()
        {
            this.writer.Write("The Engine is starting...");
            timer.Start();
        }
        public void Stop()
        {
            timer.Stop();
            this.writer.Write($"The Engine worked for {timer.ElapsedMilliseconds} milliseconds.");
        }
    }
}
