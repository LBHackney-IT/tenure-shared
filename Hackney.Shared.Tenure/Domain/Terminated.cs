using System;

namespace Hackney.Shared.Tenure.Domain
{
    public class Terminated
    {
        public bool IsTerminated { get; set; }

        public string ReasonForTermination { get; set; }
    }
}
