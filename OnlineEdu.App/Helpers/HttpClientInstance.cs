namespace OnlineEdu.App.Helpers
{
    public static class HttpClientInstance
    {
        public static HttpClient CreateClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress= new Uri("https://localhost:7295/api/");
            return client;
        } 
                
                    
    }
}
