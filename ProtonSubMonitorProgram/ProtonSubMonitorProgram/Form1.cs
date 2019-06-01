using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TwitchLib.Client;
using TwitchLib.Client.Models;
using System.Text.RegularExpressions;
using RestSharp;
using Newtonsoft.Json.Linq;
using TwitchLib.Client.Events;
using TwitchLib.Communication.Models;
using TwitchLib.Communication.Clients;
using Microsoft.Extensions.Logging;

namespace ProtonSubMonitorProgram
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        private static string maindir = Directory.GetCurrentDirectory();
        public static string setdir = maindir + @"\Settings";
        public static string cachedir = maindir + @"\Cache";
        public static string NewSub = "NEWSUB     from $sub at $tier";
        public static string ReSub = "RESUB    from $sub for $months at $tier. Their message : $mess";
        public static string GiftSub = "GIFTSUB   from $gifter to $recipant";
        public static string game = "";
        public static string status = "";

        public string TwitchBotName = File.ReadLines(setdir + @"\twitch.txt").Skip(0).Take(1).First();
        public string TwitchBotOauth = File.ReadLines(setdir + @"\twitch.txt").Skip(1).Take(1).First();
        public string TwitchBotChannel = File.ReadLines(setdir + @"\twitch.txt").Skip(2).Take(1).First();
        public string ClientID = File.ReadLines(setdir + @"\twitch.txt").Skip(3).Take(1).First();

        public static DateTime dt = new DateTime();
        public static string stamp = "";
        public static int SubCounter = 0;

        public List<string> Sublisting = new List<string>();
        public List<sublist> TrueSubList = new List<sublist>();
        public List<string> masterholdings = new List<string>();


        TwitchClient client;

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(cachedir))
            {
                Directory.CreateDirectory(cachedir);
                File.WriteAllText(cachedir + @"\giftsub.csv", "");
                File.WriteAllText(cachedir + @"\newsub.csv", "");
                File.WriteAllText(cachedir + @"\resub.csv", "");
                File.WriteAllText(cachedir + @"\errorlog.txt", "");

                //File.Create(cachedir + @"\giftsub.csv");
                //File.Create(cachedir + @"\newsub.csv");
                //File.Create(cachedir + @"\resub.csv");
                //File.Create(cachedir + @"\errorlog.txt");
            }

            if (!File.Exists(cachedir + @"\giftsub.csv"))
            {
                File.WriteAllText(cachedir + @"\giftsub.csv", "");
                //File.Create(cachedir + @"\giftsub.csv");
            }

            if (!File.Exists(cachedir + @"\newsub.csv"))
            {
                File.WriteAllText(cachedir + @"\newsub.csv", "");
                //File.Create(cachedir + @"\newsub.csv");
            }

            if (!File.Exists(cachedir + @"\resub.csv"))
            {
                File.WriteAllText(cachedir + @"\resub.csv", "");
                //File.Create(cachedir + @"\resub.csv");
            }

            if (!File.Exists(cachedir + @"\errorlog.txt"))
            {
                File.WriteAllText(cachedir + @"\errorlog.txt", "");
                //File.Create(cachedir + @"\errorlog.txt");
            }
            LoadMessages();
            twitch_connect();
        }

        private void twitch_connect()
        {
            ConnectionCredentials credentials = new ConnectionCredentials(TwitchBotName, TwitchBotOauth);
            var clientOptions = new ClientOptions
            {
                MessagesAllowedInPeriod = 100,
                ThrottlingPeriod = TimeSpan.FromSeconds(60)
                
            };
            var customClient = new WebSocketClient(clientOptions);
            var client = new TwitchClient(customClient);
            client.Initialize(credentials, TwitchBotChannel);
            client.OnGiftedSubscription += giftsub;
            client.OnNewSubscriber += newsub;
            client.OnReSubscriber += resub;
            client.Connect();
        }

        private void resub(object sender, OnReSubscriberArgs e)
        {
            try
            {
                DateTime dt = System.DateTime.Now;
                string stamp = dt.ToShortDateString() + " " + dt.ToShortTimeString();
                string item = e.ReSubscriber.RawIrc;
                string subscriber = e.ReSubscriber.DisplayName;
                string plan = e.ReSubscriber.SubscriptionPlan.ToString();
                string mess = e.ReSubscriber.ResubMessage;
                string months = "";
                Console.WriteLine(e.ReSubscriber.Months);
                if (item.Contains("msg-param-should-share-streak=0"))
                {
                    string remonths = @";msg-param-cumulative-months=(\d+);";
                    try
                    {
                        MatchCollection match = Regex.Matches(item, remonths);
                        GroupCollection group = match[0].Groups;
                        months = $"{group[1].Value} cumulative months";
                    }
                    catch
                    {
                        months = $"{item.Split(';')[10].Split('=')[1]} cumulative months"; 
                    }
                    Console.WriteLine(months);

                }
                else if (item.Contains("msg-param-should-share-streak=1"))
                {
                    string recmonths = @";msg-param-cumulative-months=(\d+);";
                    string resmonths = @";msg-param-streak-months=(\d+);";
                    string CMonths = "";
                    string SMonths = "";
                    try
                    {
                        MatchCollection match = Regex.Matches(item, recmonths);
                        GroupCollection group = match[0].Groups;
                        CMonths = group[1].Value;
                    }
                    catch
                    {
                        CMonths = item.Split(';')[10].Split('=')[1];
                    }
                    try
                    {
                        MatchCollection match = Regex.Matches(item, resmonths);
                        GroupCollection group = match[0].Groups;
                        SMonths = group[1].Value;
                    }
                    catch
                    {
                        SMonths = item.Split(';')[13].Split('=')[1];
                    }

                    months = $"{CMonths} cumulative months and has a {SMonths} month streak";
                    Console.WriteLine(months);
                }
                Console.WriteLine(e.ReSubscriber.SystemMessage);
                if (mess == "") mess = "No Message";
                if (plan == "1000") plan = "1";
                if (plan == "2000") plan = "2";
                if (plan == "3000") plan = "3";
                string holder = ReSub;
                holder = holder.Replace("$time", stamp);
                holder = holder.Replace("$sub", "<span class='name'>" + subscriber + "</span>");
                holder = holder.Replace("$months", months);
                holder = holder.Replace("$tier", plan);
                holder = holder.Replace("$mess", mess);
                Processmessage(stamp, holder, " RESUB ", " From " + subscriber, months, mess);
                using (StreamWriter writer = new StreamWriter(cachedir + @"\resub.csv", append: true))
                {
                    writer.WriteLine(stamp + "," + subscriber + "," + months + "," + plan + "," + mess);
                }
                //processMessage(holder);
            }
            catch (Exception ee)
            {
                File.AppendAllText(cachedir + @"\errorlog.txt", ee.ToString() + Environment.NewLine);
                Console.WriteLine(ee.ToString() + Environment.NewLine);
            }
        }

        private void newsub(object sender, OnNewSubscriberArgs e)
        {
            try
            {
                DateTime dt = System.DateTime.Now;
                string holder = NewSub;
                string stamp = dt.ToShortDateString() + " " + dt.ToShortTimeString();
                string subscriber = e.Subscriber.DisplayName;
                string plan = e.Subscriber.SubscriptionPlan.ToString();
                string mess = e.Subscriber.ResubMessage;
                if (mess == "") mess = "No Message";
                if (plan == "1000") plan = "1";
                if (plan == "2000") plan = "2";
                if (plan == "3000") plan = "3";
                holder = holder.Replace("$time", stamp);
                holder = holder.Replace("$sub", subscriber);
                holder = holder.Replace("$tier", plan);
                using (StreamWriter writer = new StreamWriter(cachedir + @"\newsub.csv", append: true))
                {
                    writer.WriteLine(stamp + "," + subscriber + "," + plan);
                }
                holder = NewSub;

                holder = holder.Replace("$time", stamp);
                holder = holder.Replace("$sub", "<span class='name'>" + subscriber + "</span>");
                holder = holder.Replace("$tier", plan);
                Processmessage(stamp, holder, " NEWSUB ", " From " + subscriber, "", "");
                //processMessage(holder);
            }
            catch (Exception ee)
            {
                File.AppendAllText(cachedir + @"\errorlog.txt", ee.ToString() + Environment.NewLine);
                Console.WriteLine(ee.ToString() + Environment.NewLine);
            }
        }

        private void giftsub(object sender, OnGiftedSubscriptionArgs e)
        {
            try
            {
                string holder = GiftSub;
                DateTime dt = System.DateTime.Now;
                string stamp = dt.ToShortDateString() + " " + dt.ToShortTimeString();
                string gifter = e.GiftedSubscription.DisplayName;

                if (gifter == "")
                {
                    gifter = e.GiftedSubscription.Login;
                }
                string subscriber = e.GiftedSubscription.MsgParamRecipientDisplayName;
                if (subscriber == "")
                {
                    e.GiftedSubscription.MsgParamRecipientUserName.ToString();
                }
                holder = holder.Replace("$time", stamp);
                holder = holder.Replace("$recipant", subscriber);
                holder = holder.Replace("$gifter", gifter);

                using (StreamWriter writer = new StreamWriter(cachedir + @"\giftsub.csv", append: true))
                {
                    writer.WriteLine(stamp + "," + subscriber + "," + gifter);

                }
                holder = GiftSub;
                holder = holder.Replace("$time", stamp);
                holder = holder.Replace("$recipant", "<span class='name'>" + subscriber + "</span>");
                holder = holder.Replace("$gifter", "<span class='name'>" + gifter + "</span>");
                Processmessage(stamp, holder, " GIFTSUB ", " From " + gifter + " to " + subscriber, "", "");
                //processMessage(holder);
            }
            catch (Exception ee)
            {
                File.AppendAllText(cachedir + @"\errorlog.txt", ee.ToString() + Environment.NewLine);
                Console.WriteLine(ee.ToString() + Environment.NewLine);
            }
        }

        private void LoadMessages()
        {
            tbSubList.Text = "";
            // ReSub Reload
            using (StreamReader reader = new StreamReader(cachedir + @"\resub.csv"))
            {
                string lines;
                while ((lines = reader.ReadLine()) != null)
                {
                    //"$time RESUB from $sub for $months months at $tier. Their message : $mess"
                    string holder = ReSub;
                    String[] subinfo = lines.Split(',');
                    string date = subinfo[0];
                    string subcriber = subinfo[1];
                    string months = subinfo[2];
                    string tier = subinfo[3];
                    string mess = subinfo[4];

                    //holder = holder.Replace("$time", date);
                    holder = holder.Replace("$sub", "<span class='name'>" + subcriber + "</span>");
                    holder = holder.Replace("$months", months);
                    holder = holder.Replace("$tier", tier);
                    holder = holder.Replace("$mess", mess);

                    TrueSubList.Add(new sublist
                    {
                        Datetime = System.DateTime.Parse(date),
                        annoucment = holder,
                        Subtype = " RESUB ",
                        Subname = "from" + subcriber,
                        submonths = " for " + months,
                        SubMessage = " " + mess
                    });
                }


            }


            // NewSub Reload
            using (StreamReader reader = new StreamReader(cachedir + @"\newsub.csv"))
            {
                string lines;
                while ((lines = reader.ReadLine()) != null)
                {
                    //"$time NEWSUB from $sub at $tier"
                    string holder = NewSub;
                    String[] subinfo = lines.Split(',');
                    string date = subinfo[0];
                    string subcriber = subinfo[1];
                    string tier = subinfo[2];
                    //holder = holder.Replace("$time", date);
                    holder = holder.Replace("$sub", "<span class='name'>" + subcriber + "</span>");
                    holder = holder.Replace("$tier", tier);

                    TrueSubList.Add(new sublist
                    {
                        Datetime = System.DateTime.Parse(date),
                        annoucment = holder,
                        Subtype = " NEWSUB ",
                        Subname = "from " + subcriber,
                        submonths = "",
                        SubMessage = ""
                    });
                }
            }


            // GiftSub Reload
            using (StreamReader reader = new StreamReader(cachedir + @"\giftsub.csv"))
            {
                string lines;
                while ((lines = reader.ReadLine()) != null)
                {
                    //$time GIFTSUB from $gifter to $recipant"
                    string holder = GiftSub;
                    String[] subinfo = lines.Split(',');
                    string date = subinfo[0];
                    string subcriber = subinfo[1];
                    string gifter = subinfo[2];
                    //holder = holder.Replace("$time", date);
                    holder = holder.Replace("$recipant", "<span class='name'>" + subcriber + "</span>");
                    holder = holder.Replace("$gifter", "<span class='name'>" + gifter + "</span>");
                    holder = holder.Replace("$recipant", subcriber );
                    holder = holder.Replace("$gifter", gifter );


                    TrueSubList.Add(new sublist
                    {
                        Datetime = System.DateTime.Parse(date),
                        annoucment = holder,
                        Subtype = " GIFTSUB ",
                        Subname = " from " + gifter + " to " + subcriber,
                        submonths = "",
                        SubMessage = ""
                    });
                }


            }

            TrueSubList.Sort((b, a) => b.Datetime.CompareTo(a.Datetime));

            foreach (var item in TrueSubList)
            {
                Processmessage(item.Datetime.ToString(), item.annoucment, item.Subtype, item.Subname, item.submonths, item.SubMessage);
                // Console.WriteLine(item.Datetime.ToString(), item.annoucment);
            }

        }

        public void Processmessage(string stamp, string holder, string Subtype, string Subname, 
            string submonths, string SubMessage)
        {
            if (holder.Contains(" Tier2"))
            {
                SubCounter += 2;
            }
            else if (holder.Contains(" Tier3"))
            {
                SubCounter += 6;
            }
            else
            {
                SubCounter += 1;
            }
            this.TotalSubCount.BeginInvoke(new Action(
                () =>
                {
                TotalSubCount.Value += 1;
            }));
            this.tbSubList.BeginInvoke(new Action(
                    () =>
                    {
                        tbSubList.Text += "<li>" + stamp + " " + holder + "</li>" +
                            Environment.NewLine;
                    }));
            if (Subtype.Contains("NEWSUB"))
            {
                Subname = Subname.Substring(5);
                this.NewSubCount.BeginInvoke(new Action(
                    () =>
                    {
                        NewSubCount.Value += 1;
                    }));
                this.NewSubsLIst.BeginInvoke(new Action(
                    () =>
                    {
                        NewSubsLIst.Text += Subname + ", ";
                    }));
            }
            if (Subtype.Contains("GIFTSUB"))
            {
                Subname = Subname.Substring(6);
                this.GiftSubCount.BeginInvoke(new Action(
                    () =>
                    {
                        GiftSubCount.Value += 1;
                    }));
                this.GiftSubsList.BeginInvoke(new Action(
                    () =>
                    {
                        GiftSubsList.Text += Subname + Environment.NewLine;
                    }));
            }
            if (submonths != "")
            {
                submonths = submonths + " months ";
            }

            this.dgvSub.BeginInvoke(new Action(
                   () =>
                   {
                       dgvSub.Rows.Add(stamp, " " + Subtype, " " + Subname, " " + submonths, SubMessage);
                       dgvSub.Update();
                   }));

            /* foreach(DataGridViewRow row in dgvSub.Rows)
            * {
            *     row.DefaultCellStyle.BackColor = Color.Black;
            *     row.DefaultCellStyle.ForeColor = Color.White;
            * }
            */
            

        }

        private void dgvSub_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ResetNumbers_Click(object sender, EventArgs e)
        {
            NewSubCount.Value = 0;
            NewSubsLIst.Text = "";
            GiftSubCount.Value = 0;
            GiftSubsList.Text = "";
            TotalSubCount.Value = 0;
            tbSubList.Text = "";
        }

        private void OutPut_Click(object sender, EventArgs e)
        {
            var dir = @"C:\ProntonJonLists\";
            string pwd = Directory.GetCurrentDirectory() + @"\";
            if (!Directory.Exists(dir))
            {

                Directory.CreateDirectory(dir);

            }
            dt = System.DateTime.Now;
            stamp =  dt.ToString("d-M-y--H-mm-ss");
            Console.WriteLine(stamp);
            File.AppendAllText(dir + "sublist-" + stamp + ".html", "");
            string filname = @"sublist-" + stamp + ".html";
            File.AppendAllText(dir + filname, "");
            List<string> holder = new List<string>();
            Console.WriteLine(Directory.GetCurrentDirectory());
            //holder[] += File.ReadAllLines(pwd + @"Include\header.txt");

            foreach (string line in File.ReadAllLines(pwd + @"Include\header.txt"))
            {
                File.AppendAllText(dir + filname, line + Environment.NewLine);
            }

            File.AppendAllText(dir + filname, "<h1>ProtonJon Sub List</h1>" +Environment.NewLine);
            File.AppendAllText(dir + filname, "<h2>State of Subs</h2>" + Environment.NewLine);
            File.AppendAllText(dir + filname, "<h3>Total Subs x" + TotalSubCount.Value + "</h3>" + Environment.NewLine);
            File.AppendAllText(dir + filname, "<h3>Total GiftSubs x" + GiftSubCount.Value + "</h3>" + Environment.NewLine);
            File.AppendAllText(dir + filname, "<ul>");

            //File.AppendAllText(dir + filname, "<h2>State of Bits</h2>" + Environment.NewLine);
           //File.AppendAllText(dir + filname, "<p>Number of Bits Received x" + bitcounter.Value.ToString()+ "</p>" + Environment.NewLine);


            foreach (string line in GiftSubsList.Lines)
            {
                File.AppendAllText(dir + filname, "<li>"+ line + "</li>" + Environment.NewLine);
            }
            File.AppendAllText(dir + filname, "</ul>");

            File.AppendAllText(dir + filname, "<h3>Total NewSubs x" + NewSubCount.Value + "</h3>" + Environment.NewLine);

            File.AppendAllText(dir + filname, "<ul>");

            foreach (string line in NewSubsLIst.Lines)
            {
                File.AppendAllText(dir + filname, "<li>" + line + "</li>" + Environment.NewLine);
            }
            File.AppendAllText(dir + filname, "</ul>" + Environment.NewLine);

            File.AppendAllText(dir + filname, "<h3>Main Sub List</h3>" + Environment.NewLine);

            File.AppendAllText(dir + filname, "<ul>" + Environment.NewLine);
            foreach (string line in tbSubList.Lines)
            {
                File.AppendAllText(dir + filname, line + Environment.NewLine);
            }
            File.AppendAllText(dir + filname, "</ul>" + Environment.NewLine);

            foreach (string line in File.ReadAllLines(pwd + @"Include\footer.txt"))
            {
                File.AppendAllText(dir + filname, line + Environment.NewLine);
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            var client = new RestClient();
            client.BaseUrl = new Uri("https://api.twitch.tv/kraken/channels/");
            var request = new RestRequest();
            request.Method = Method.GET;
            request.Resource = TwitchBotChannel + "";
            request.AddHeader("Client-ID", ClientID);
            request.AddHeader("accept", "application/vnd.twitchtv.v3+json");
            request.RequestFormat = DataFormat.Json;
            IRestResponse response = client.Execute(request);
            JObject Holder = JObject.Parse(response.Content);
            game = (string)Holder["game"];
            status = (string)Holder["status"];
            this.Text = TwitchBotChannel + ": " + game + " | " + status;
            Console.WriteLine(TwitchBotChannel + ": " + game + " | " + status);
        }
    }
    public class sublist
    {
        public DateTime Datetime { get; set; }
        public string annoucment { get; set; }
        public string Subtype { get; set; }
        public string Subname { get; set; }
        public string submonths { get; set; }
        public string SubMessage { get; set; }

    }
}
