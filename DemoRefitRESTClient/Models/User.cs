using Newtonsoft.Json;

namespace DemoRefitRESTClient.Models
{
    public class User
    {
        //[JsonProperty(PropertyName="login")]
        public string login { get; set; }

        public override string ToString()
        {
            return login;
        }
    }
}