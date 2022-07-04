using Hangfire.States;
using Hangfire.Storage;

namespace Credit.Hangfire;

public class SucceededStateExpireHandler : IStateHandler
{
    public TimeSpan JobExpirationTimeout;
    public string StateName => SucceededState.StateName;

    public SucceededStateExpireHandler(int jobExpirationTimeout)
    {
        JobExpirationTimeout = TimeSpan.FromMinutes(jobExpirationTimeout);
    }

    public void Apply(ApplyStateContext context, IWriteOnlyTransaction transaction)
    {
        context.JobExpirationTimeout = JobExpirationTimeout;
    }

    public void Unapply(ApplyStateContext context, IWriteOnlyTransaction transaction)
    {
        
    }
}