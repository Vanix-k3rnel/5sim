using Leaf.xNet;
using Newtonsoft.Json.Linq;

namespace Five.Sim
{
    public static class user
    {
        /* Get Profile */
        public static string Profile(string auth)
        {
            HttpRequest web = new HttpRequest();
            web.AddHeader("Authorization", $"Bearer {auth}");
            web.AddHeader("Content-Type", "application/json");
            string url = web.Get($"https://5sim.net/v1/user/profile").ToString();
            JObject rss = JObject.Parse(url);
            return rss.ToString();
        }

        /* Get Payment History */
        public static string Payment_History(string auth)
        {
            HttpRequest web = new HttpRequest();
            web.AddHeader("Authorization", $"Bearer {auth}");
            web.AddHeader("Content-Type", "application/json");
            string url = web.Get($"https://5sim.net/v1/user/payments").ToString();
            JObject rss = JObject.Parse(url);
            return rss.ToString();
        }

    }

    public static class Check
    {
        /* SMS code */
        /* int wait = how much minutes it should wait to recheck */
        public static int SMS_Code(string auth, int id, int wait)
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
                    Thread.Sleep(60 * 1000 * wait);
                }
            }
        }
    }



    public static class Purchase
    {
        /* Buy a Activation */
        public static string Activation(string auth, string country, string provider, string product)
        {
            HttpRequest web = new HttpRequest();
            web.AddHeader("Authorization", $"Bearer {auth}");
            web.AddHeader("Content-Type", "application/json");
            string url = web.Get($"https://5sim.net/v1/user/buy/activation/" + country + "/" + provider + "/" + product).ToString();
            JObject rss = JObject.Parse(url);
            return rss.ToString();
        }

    }

    public static class Order
    {
        /* Finish order */
        public static string Finish(string auth, int id)
        {
            HttpRequest web = new HttpRequest();
            web.AddHeader("Authorization", $"Bearer {auth}");
            web.AddHeader("Content-Type", "application/json");
            string url = web.Get($"https://5sim.net/v1/user/finish/" + id).ToString();
            JObject rss = JObject.Parse(url);
            return rss.ToString();
        }

        /* Cancel order */
        public static string Cancel(string auth, int id)
        {
            HttpRequest web = new HttpRequest();
            web.AddHeader("Authorization", $"Bearer {auth}");
            web.AddHeader("Content-Type", "application/json");
            string url = web.Get($"https://5sim.net/v1/user/cancel/" + id).ToString();
            JObject rss = JObject.Parse(url);
            return rss.ToString();
        }


        /* Ban order */
        public static string Ban(string auth, int id)
        {
            HttpRequest web = new HttpRequest();
            web.AddHeader("Authorization", $"Bearer {auth}");
            web.AddHeader("Content-Type", "application/json");
            string url = web.Get($"https://5sim.net/v1/user/ban/" + id).ToString();
            JObject rss = JObject.Parse(url);
            return rss.ToString();
        }

    }


}
