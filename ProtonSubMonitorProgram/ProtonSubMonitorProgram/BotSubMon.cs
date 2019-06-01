using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using TwitchLib.Client.Events;

namespace ProtonSubMonitorProgram
{
    class BotSubMon
    {
        private static string maindir = Directory.GetCurrentDirectory();
        public static string cachedir = maindir + @"\Cache";

        public static string NewSub = "NEWSUB     from $sub at $tier";
        public static string ReSub = "RESUB    from $sub for $months at $tier. Their message : $mess";
        public static string GiftSub = "GIFTSUB   from $gifter to $recipant";


        internal static void newsub(object sender, OnNewSubscriberArgs e)
        {
            Form1 fm = new Form1();
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
                fm.Processmessage(stamp, holder, " NEWSUB ", " From " + subscriber, "", "");
                //processMessage(holder);
            }
            catch (Exception ee)
            {
                File.AppendAllText(cachedir + @"\errorlog.txt", ee.ToString() + Environment.NewLine);
                Console.WriteLine(ee.ToString() + Environment.NewLine);
            }
        }

        internal static void resub(object sender, OnReSubscriberArgs e)
        {
            Form1 fm = new Form1();

            try
            {
                DateTime dt = System.DateTime.Now;
                string stamp = dt.ToShortDateString() + " " + dt.ToShortTimeString();
                string item = e.ReSubscriber.RawIrc;
                string subscriber = e.ReSubscriber.DisplayName;
                string plan = e.ReSubscriber.SubscriptionPlan.ToString();
                string mess = e.ReSubscriber.ResubMessage;
                string months = "";
                if (item.Contains("streak=0"))
                {
                    months = $"{item.Split(';')[9].Split('=')[1]} cumulative months";
                    Console.WriteLine(months);
                }
                else if (item.Contains("streak=1"))
                {
                    string CMonths = item.Split(';')[9].Split('=')[1];
                    string SMonths = item.Split(';')[12].Split('=')[1];
                    months = $"{item.Split(';')[9].Split('=')[1]} cumulative months and has a {SMonths} month streak";
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
                fm.Processmessage(stamp, holder, " RESUB ", " From " + subscriber, months, mess);
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

        internal static void giftsub(object sender, OnGiftedSubscriptionArgs e)
        {
            Form1 fm = new Form1();
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
                fm.Processmessage(stamp, holder, " GIFTSUB ", " From " + gifter + " to " + subscriber, "", "");
                //processMessage(holder);
            }
            catch (Exception ee)
            {
                File.AppendAllText(cachedir + @"\errorlog.txt", ee.ToString() + Environment.NewLine);
                Console.WriteLine(ee.ToString() + Environment.NewLine);
            }
        }

    }
}
