using Leaf.xNet;
using Newtonsoft.Json.Linq;

namespace _5sim
{
    /* Buy a Activation */
    public static class Buy
    {
        static (int, string) Activation(string auth, string country, string provider , string product)
        {
            int ID;
            string phone;
            HttpRequest web = new HttpRequest();
            web.AddHeader("Authorization", $"Bearer {auth}");
            web.AddHeader("Content-Type", "application/json");
            string url = web.Get($"https://5sim.net/v1/user/buy/activation/" + country + "/" + provider + "/" + product).ToString();
            JObject rss = JObject.Parse(url);
            ID = (int)rss["id"];
            phone = (string)rss["phone"];
            return (ID, phone);
        }

    }
}