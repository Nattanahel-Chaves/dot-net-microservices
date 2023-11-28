using BestBank.AccountService.dtos;
using Microsoft.AspNetCore.Components.Forms;

namespace BestBank.AccountService.Clients
{
    public class NotificationClient
    {
        private readonly HttpClient httpClient;
        private readonly ClientPolicy clientPolicy;
        public NotificationClient(HttpClient httpClient, ClientPolicy clientPolicy)
        {
            this.httpClient=httpClient;
            this.clientPolicy=clientPolicy;
        } 

        public async void PushNotification(CreateNotification notification)
        {
            string ?apiUrl = Environment.GetEnvironmentVariable("NotificationServiceEndpoint");  
            //HttpResponseMessage response = await httpClient.PostAsJsonAsync(apiUrl, notification);
             HttpResponseMessage response = await clientPolicy.WaitingRetry.ExecuteAsync( 
                 () => httpClient.PostAsJsonAsync(apiUrl, notification));

            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
        }

    }
    
}