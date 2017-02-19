    #r "Newtonsoft.Json"

    using System;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using Newtonsoft.Json;

    public static async Task<object> Run(HttpRequestMessage req, TraceWriter log)
    {
        string jsonContent = await req.Content.ReadAsStringAsync();
        dynamic data = JsonConvert.DeserializeObject(jsonContent);
        
        string type =  data["primary_resources"][0]["story_type"];
        string name = data["primary_resources"][0]["name"];
        string url = data["primary_resources"][0]["url"];
        string author = data["performed_by"]["name"];
        string story_id = data["primary_resources"][0]["id"];
        string highlight = data["highlight"];
        string text = author + " just " + highlight + " " + type + " **[#" + story_id + "](" + url + ") - _" + name + "_**"   ;

        // highlights: added, edited, added task:, completed task:, delivered, deleted, accepted, rejected,

        if (highlight == "added")
        {
            // Configure the payload. Encode the message in a JSON object 
            var values = new Dictionary<string, string>
            {
                { "text" , text }
            };
            var content = JsonConvert.SerializeObject(values);
            
            // Send the message to the log for giggles and to the connector API.
            log.Info(text);
            await SendToMSTeams(Environment.GetEnvironmentVariable("TEAMS_URL"), content);   
        }
        if (highlight == "started")
        {
            // Configure the payload. Encode the message in a JSON object 
            var values = new Dictionary<string, string>
            {
                { "text" , text }
            };
            var content = JsonConvert.SerializeObject(values);
            
            // Send the message to the log for giggles and to the connector API.
            log.Info(text);
            await SendToMSTeams(Environment.GetEnvironmentVariable("TEAMS_URL"), content);   
        }
        if (highlight == "finished")
        {
            // Configure the payload. Encode the message in a JSON object 
            var values = new Dictionary<string, string>
            {
                { "text" , text }
            };
            var content = JsonConvert.SerializeObject(values);
            
            // Send the message to the log for giggles and to the connector API.
            log.Info(text);
            await SendToMSTeams(Environment.GetEnvironmentVariable("TEAMS_URL"), content);   
        }
        if (highlight == "delivered")
        {
            // Configure the payload. Encode the message in a JSON object 
            var values = new Dictionary<string, string>
            {
                { "text" , text }
            };
            var content = JsonConvert.SerializeObject(values);
            
            // Send the message to the log for giggles and to the connector API.
            log.Info(text);
            await SendToMSTeams(Environment.GetEnvironmentVariable("TEAMS_URL"), content);   
        }
        if (highlight == "accepted")
        {
            // Configure the payload. Encode the message in a JSON object 
            var values = new Dictionary<string, string>
            {
                { "text" , text }
            };
            var content = JsonConvert.SerializeObject(values);
            
            // Send the message to the log for giggles and to the connector API.
            log.Info(text);
            await SendToMSTeams(Environment.GetEnvironmentVariable("TEAMS_URL"), content);   
        }
        if (highlight == "rejected")
        {
            // Configure the payload. Encode the message in a JSON object 
            var values = new Dictionary<string, string>
            {
                { "text" , text }
            };
            var content = JsonConvert.SerializeObject(values);
            
            // Send the message to the log for giggles and to the connector API.
            log.Info(text);
            await SendToMSTeams(Environment.GetEnvironmentVariable("TEAMS_URL"), content);   
        }

        return req.CreateResponse(HttpStatusCode.OK, new {
            greeting = $"OK!"
        });
    }

    public static async Task SendToMSTeams(string url, string requestBody)
    {  
        using (var client = new HttpClient())
        {
            var content = new StringContent(requestBody, Encoding.UTF8, "application/json");
            await client.PostAsync(url, content);
        }
    }