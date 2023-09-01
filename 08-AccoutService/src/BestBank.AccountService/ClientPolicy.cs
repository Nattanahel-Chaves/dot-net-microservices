using Polly;
using Polly.Retry;

namespace BestBank.AccountService
{
    public class ClientPolicy
    {
        public AsyncRetryPolicy<HttpResponseMessage> InmediateHttpRetry {get;}
        public AsyncRetryPolicy<HttpResponseMessage> WaitingRetry {get;}

        public ClientPolicy()
        {
            InmediateHttpRetry= Policy.HandleResult<HttpResponseMessage>( 
                res => !res.IsSuccessStatusCode).RetryAsync(5);

            WaitingRetry= Policy.HandleResult<HttpResponseMessage>( 
                res => res.IsSuccessStatusCode).WaitAndRetryAsync(3, time => TimeSpan.FromSeconds(3));
        }
    }

}