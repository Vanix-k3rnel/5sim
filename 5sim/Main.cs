using Leaf.xNet;
using Newtonsoft.Json.Linq;

namespace _5sim
{
    public static class user
    {
        public static string Profile(string auth)
        {
            HttpRequest web = new HttpRequest();
            web.AddHeader("Authorization", $"Bearer {auth}");
            web.AddHeader("Content-Type", "application/json");
            string url = web.Get($"https://5sim.net/v1/user/profile").ToString();
            JObject rss = JObject.Parse(url);
            return rss.ToString();
        }


    }
    public static class Verify
    {
        public static int SMS_Code(string auth, int id)
        {
            using (HttpRequest web = new HttpRequest())
            {
                while (true)
                {
                    web.AddHeader("Authorization", $"Bearer {auth}");
                    web.AddHeader("Content-Type", "application/json");
                    string sms = web.Get($"https://5sim.net/v1/user/check/" + id).ToString();
                    JObject sms_JSON = JObject.Parse(sms);
                    string status = (string)sms_JSON["status"];
                    if (status.Contains("RECEIVED"))
                    {
                        int Verify_code = (int)sms_JSON["sms"][0]["code"];
                        return Verify_code;
                    }
                    Thread.Sleep(60000);
                }
            }
        }
    }


    /* Buy a Activation */
    public static class Main
    {
        public static string Activation(string auth, string country, string provider , string product)
        {
            int ID;
            string phone;
            HttpRequest web = new HttpRequest();
            web.AddHeader("Authorization", $"Bearer {auth}");
            web.AddHeader("Content-Type", "application/json");
            string url = web.Get($"https://5sim.net/v1/user/buy/activation/" + country + "/" + provider + "/" + product).ToString();
            JObject rss = JObject.Parse(url);
            return rss.ToString();
        }

    }
}