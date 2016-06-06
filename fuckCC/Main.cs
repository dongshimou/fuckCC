using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fuckCC
{
    using Microsoft.Win32;
    using System.Collections;
    using System.IO;
    using System.Management;
    using System.Net;
    using System.Net.NetworkInformation;
    using System.Net.Sockets;
    using System.Reflection;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography;
    using System.Threading;
    using Microsoft.VisualBasic;
    
    using Microsoft.VisualBasic.CompilerServices;
    using fuckCC;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text;
    using System.Web.Script.Serialization;
    using System.Windows.Forms;
    
    public static class Main
    {
        public static IPEndPoint ipendPoint_0 = new IPEndPoint(Dns.GetHostAddresses("net.nsu.edu.cn")[0], 8080);
        public static UdpClient udpClient_0 = new UdpClient(0);
        public static RSACryptoServiceProvider rsacryptoServiceProvider_0 = new RSACryptoServiceProvider();
        public static RSACryptoServiceProvider rsacryptoServiceProvider_1 = new RSACryptoServiceProvider();
        public static Queue<string> queue_1 = new Queue<string>();
        public static string string_2="";
        //RSA
        public static JavaScriptSerializer javaScriptSerializer_0 = new JavaScriptSerializer();
        public static DateTime dateTime_1;
        public static long long_0 = 0L;
        public static string string_4 = "https://net.nsu.edu.cn/ad.html";
        public static List<byte> list_0 = new List<byte>();
        private static List<string> list_1 = new List<string>();

        public static int int_0 = 0;
        public static int int_1 = 0;
        public static int int_2 = 0;
        public static int int_3 = 1;
        public static int int_4 = 1;
        public static int int_5 = 0;

        public static bool bool_0 = false;
        public static DateTime dateTime_0;
        private static DateTime dateTime_2;
        public static Queue<string> queue_0 = new Queue<string>();

        public static byte byte_0 = 40;


        //---------
        public static bool bool_1 = false;
        public static string string_3 = null;
        public static string un=null;
        public static string pw=null;
        public static string string_5 = null;
        public static string string_0 = "1.15.11.11111";
        //---------


        //cookie-----
        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool InternetSetCookie(string string_6, string string_7, string string_8);
        //cookie-----

        

        //thread1
        public static void smethod_19()//貌似是不停的获取地址
        {
            IPEndPoint iPEndPoint = new IPEndPoint(0L, 0);
            byte[] array = Main.udpClient_0.Receive(ref iPEndPoint);
            if (iPEndPoint.Equals(Main.ipendPoint_0))
            {
                if (array.Length > 8 && (array[0] == 78 & array[1] == 83 & array[2] == 85 & array[3] == 67 & array[4] == 86) && (int)BitConverter.ToUInt16(array, 6) == array.Length - 8)
                {
                    byte[] array2 = new byte[array.Length - 9 + 1];
                    Array.Copy(array, 8, array2, 0, array2.Length);
                    if (array[5] == 49)
                    {
                        array2 = Main.smethod_24(array2);
                        if (array2 != null)
                        {
                            Main.queue_1.Enqueue(Encoding.Default.GetString(array2));
                        }
                    }
                    else
                    {
                        if (array[5] == 48 && array2.Length > 0)
                        {
                            Main.queue_1.Enqueue(Encoding.Default.GetString(array2));
                        }
                    }
                }
            }
        }
        private static byte[] smethod_24(Array array_0)
        {
            byte[] result;
            if (array_0.Length % 128 > 0) result = null;
            else
            {
                int num = (int)Math.Round(Conversion.Int((double)array_0.Length / 128.0));
                byte[] array = new byte[0];
                int num2 = num;
                for (int i = 1; i <= num2; i++)
                {
                    byte[] array2 = new byte[128];
                    Array.Copy(array_0, (i - 1) * 128, array2, 0, 128);
                    array2 = Main.rsacryptoServiceProvider_1.Decrypt(array2, false);
                    int num3 = array.Length;
                    array = (byte[])Utils.CopyArray(array, new byte[num3 + array2.Length - 1 + 1]);
                    array2.CopyTo(array, num3);
                }
                result = array;
            }
            return result;
        }
        //thread2
        public static void smethod_6()//登录进程
        {
            while (true)
            {
                if (Main.queue_1.Count > 0)
                {
                    string input = Main.queue_1.Dequeue();
                    Hashtable hashtable = (Hashtable)Main.javaScriptSerializer_0.Deserialize(input, typeof(Hashtable));
                    if (hashtable != null && hashtable.ContainsKey("T") && hashtable.ContainsKey("K"))
                    {
                        string left = Conversions.ToString(Operators.ConcatenateObject(hashtable["K"], ""));
                        Main.dateTime_1 = DateAndTime.Now;
                        if (hashtable["Token"] != null)
                        {
                            Main.long_0 = Conversions.ToLong(hashtable["Token"]);
                            Main.smethod_3("Token", Conversions.ToString(Main.long_0));
                            //设置cookies
                        }
                        if (hashtable["DEFURL"] != null)
                        {
                            Main.string_4 = Conversions.ToString(hashtable["DEFURL"]);
                        }
                        if (hashtable["URL"] != null)
                        {
                            Main.smethod_1(Conversions.ToString(hashtable["URL"]));
                            //没卵用的函数
                        }
                        if (Operators.CompareString(left, "LOGIN", false) != 0)
                        {
                            if (Operators.CompareString(left, "WAIT", false) != 0)
                            {
                                if (Operators.CompareString(left, "LOGOUT", false) != 0)
                                {
                                    if (Operators.CompareString(left, "KEEP", false) != 0)
                                    {
                                        if (Operators.CompareString(left, "TIME", false) != 0)
                                        {
                                            if (Operators.CompareString(left, "MSG", false) == 0)
                                            {
                                                Main.list_0.Add(109);
                                                //Main.smethod_16(hashtable);
                                            }
                                        }
                                        else
                                        {
                                            Main.list_0.Add(116);
                                            //Main.smethod_7(hashtable);
                                        }
                                    }
                                    else
                                    {
                                        Main.list_0.Add(107);
                                        //Main.smethod_15(hashtable);
                                        //重新登录
                                    }
                                }
                                else
                                {
                                    Main.list_0.Add(120);
                                    //Main.smethod_11(hashtable);
                                    //注销
                                }
                            }
                            else
                            {
                                Main.list_0.Add(119);
                                Main.smethod_14(hashtable);
                                //登录
                            }
                        }
                        else
                        {
                            Main.list_0.Add(108);
                            //Main.smethod_9(hashtable);
                            //bool_1=true [when error]
                            //等待开网
                        }
                    }
                }
                Thread.Sleep(10);
            }
        }
        private static void smethod_3(string un,string pw)
        {
            InternetSetCookie("http://net.nsu.edu.cn", un, pw);
            InternetSetCookie("https://net.nsu.edu.cn", un, pw);
        }
        private static void smethod_1(string string_6)
        {
            if (string_6.ToLower().StartsWith("https://net.nsu.edu.cn"))
            {
                string_6 = "http://" + string_6.Substring(8);
            }
            if (string_6.Contains("?"))
                string_6 = string_6 + "&TICK" + Conversions.ToString(DateAndTime.Now.Ticks);
            else
                string_6 = string_6 + "?TICK" + Conversions.ToString(DateAndTime.Now.Ticks);
            //后面还有一大堆、貌似是设置背景图
        }
        private static void smethod_14(Hashtable hashtable_0)
        {
            if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(hashtable_0["Result"], true, false), !Main.bool_0)))
            {
                Main.list_1.Clear();
                Main.int_0 = 0;
                Main.int_1 = 0;
                Main.int_2 = 0;
                Main.int_3 = 0;
                Main.int_4 = 0;
                Main.int_5 = 0;
                Main.bool_0 = true;
                Main.dateTime_0 = DateAndTime.Now;
                Thread thread = new Thread(new ThreadStart(Main.smethod_18));
                //登录的函数
                thread.Start();
            }
        }
        private static void smethod_18()//生成hashtable
        {
            while (true)
            {
                if ((DateAndTime.Now - Main.dateTime_2).TotalMinutes >= (double)Main.int_5)
                {
                    //string text = Main.smethod_27();
                    string text = "";
                    if (Operators.CompareString(text, "", false) > 0)
                    {
                        Hashtable hashtable = new Hashtable();
                        hashtable.Add("K", "REPORT");
                        hashtable.Add("T", DateAndTime.Now.Ticks);
                        hashtable.Add("Value", text);
                        hashtable.Add("ADP", string.Concat(new string[]
                        {
                        Conversions.ToString(Main.int_0),
                        "|",
                        Conversions.ToString(Main.int_1),
                        "|",
                        Conversions.ToString(Main.int_2),
                        "|",
                        Conversions.ToString(Main.int_3),
                        "|CheckAdpCount|",
                        Conversions.ToString(Main.int_5),
                        "|",
                        Conversions.ToString(Main.dateTime_2.Ticks)
                        }));
                        text = Main.javaScriptSerializer_0.Serialize(hashtable);
                        Main.list_0.Add(82);
                        Main.queue_0.Enqueue(text);
                    }
                }
                Thread.Sleep(10000);
                if (!Main.bool_0)
                {
                    break;
                }
                Hashtable hashtable2 = new Hashtable();
                hashtable2.Add("K", "KEEP");
                hashtable2.Add("T", DateAndTime.Now.Ticks);
                hashtable2.Add("Token", Main.long_0);
                string item = Main.javaScriptSerializer_0.Serialize(hashtable2);
                Main.list_0.Add(75);
                Main.queue_0.Enqueue(item);
            }
        }
        //thread3
        public static void smethod_5()
        {
            while (true)
            {
                if (Main.queue_0.Count > 0)
                {
                    string s = Main.queue_0.Dequeue();
                    byte[] array = Main.smethod_23(Encoding.Default.GetBytes(s));
                    byte[] array2 = new byte[array.Length + 7 + 1];
                    Array.Copy(array, 0, array2, 8, array.Length);
                    array2[0] = 78;
                    array2[1] = 83;
                    array2[2] = 85;
                    array2[3] = 67;
                    array2[4] = 86;
                    array2[5] = 49;
                    ushort value = (ushort)array.Length;
                    Array.Copy(BitConverter.GetBytes(value), 0, array2, 6, 2);
                    Main.udpClient_0.Client.SendTo(array2, Main.ipendPoint_0);
                }
                Thread.Sleep(10);
            }
        }
        private static byte[] smethod_23(Array array_0)
        {
            byte[] result;
            int num = (int)Math.Round(Math.Ceiling((double)array_0.Length / 117.0));
            byte[] array = new byte[num * 128 - 1 + 1];
            int num2 = num;
            for (int i = 1; i <= num2; i++)
            {
                int num3 = Conversions.ToInteger(Interaction.IIf(num == i, array_0.Length - (num - 1) * 117, 117));
                byte[] array2 = new byte[num3 - 1 + 1];
                Array.Copy(array_0, (i - 1) * 117, array2, 0, num3);
                array2 = Main.rsacryptoServiceProvider_0.Encrypt(array2, false);
                array2.CopyTo(array, (i - 1) * 128);
            }
            result = array;
            return result;
        }
        //thread4
        public static void smethod_4()
        {
            while (true)
            {
                if ((DateAndTime.Now - Main.dateTime_1).TotalSeconds < 12.0)
                {
                    Main.smethod_2("_" + Conversions.ToString(Main.byte_0));
                    Main.byte_0 += 1;
                    if (Main.byte_0 % 10 == 8)
                    {
                        Main.byte_0 = (byte)Math.Round((double)unchecked(Conversion.Int(VBMath.Rnd() * 3f) * 10f + 40f));
                    }
                }
                Thread.Sleep(120);
            }
        }
        private static void smethod_2(string string_0)
        {
            //貌似没什么卵用的函数
        }
        //other
        public static string smethod_25()
        {
            var pingReply = new Ping().Send("net.nsu.edu.cn", 100, new byte[1], new PingOptions(1, true));
            var iPAddress = pingReply.Address;

            NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            var result = "GW";
            foreach (var networkInterface in allNetworkInterfaces)
            {
                
                string text = networkInterface.GetPhysicalAddress().ToString();
                if (text.Length == 12)
                {
                    var iPProperties = networkInterface.GetIPProperties();
                    var enumerator = iPProperties.GatewayAddresses.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        var current = enumerator.Current;
                        if (iPAddress.Equals(current.Address))
                        {
                            var enumerator2 = iPProperties.UnicastAddresses.GetEnumerator();
                            while (enumerator2.MoveNext())
                            {
                                var current2 = enumerator2.Current;
                                var address = current.Address.ToString();
                                string id = networkInterface.Id;
                                //主要是ADPID 
                                result = string.Concat(new string[]
                                                                {
                                                address,
                                                " ",
                                                text,
                                                " ",
                                                networkInterface.Id
                                                                });
                                return result;
                            }
                        }
                    }
                }
            }
            return null;
        }
        public static void smethod_8(string un, string pw, bool flag)
        {
            RegistryKey registryKey = Registry.Users.CreateSubKey(".DEFAULT\\Software\\VB and VBA Program Settings\\NSUCC");
            if (registryKey.GetValue("RSA") != null)
            {
                object obj = Operators.ConcatenateObject(registryKey.GetValue("RSA"), "");
                obj = Main.DoDES(Conversions.ToString(obj), Environment.MachineName, true);
                if (obj != null)
                {
                    string_2 = Conversions.ToString(obj);
                    Main.rsacryptoServiceProvider_1.FromXmlString(Conversions.ToString(obj));
                }
            }
            Main.string_3 = Main.rsacryptoServiceProvider_1.ToXmlString(false);
            string text = smethod_25();
            string[] array = text.Split(new char[]
                    {
                        ' '
                    });
            Main.string_5 = array[2];
            Hashtable hashtable = new Hashtable();
            /*string unun, pwpw;
            unun= DoDES(un, "UN", false);
            pwpw = DoDES(pw, "PW", false);*/
            hashtable.Add("UserID", un);
            hashtable.Add("UserPW", pw);
            hashtable.Add("IP", array[0]);
            hashtable.Add("MAC", array[1]);
            hashtable.Add("ADPID", array[2]);
            hashtable.Add("Port", Main.udpClient_0.Client.LocalEndPoint.ToString().Split(new char[]
            {
                        ':'
            })[1]);
            hashtable.Add("CName", Environment.MachineName);
            hashtable.Add("OSVer", Environment.OSVersion.VersionString);
            hashtable.Add("CVer", Main.string_0);
            hashtable.Add("RSA", Main.string_3);
            hashtable.Add("T", DateAndTime.Now.Ticks);
            hashtable.Add("K", "LOGIN");
            string item = Main.javaScriptSerializer_0.Serialize(hashtable);
            Main.list_0.Add(76);
            Main.queue_0.Enqueue(item);
            Main.bool_1 = false;
            Main.bool_0 = false;
            Thread thread = new Thread(new ThreadStart(Main.smethod_17));
            thread.Start();
        }
        private static void GETWNPW()
        {
            RegistryKey key = Registry.Users.CreateSubKey(@".DEFAULT\Software\VB and VBA Program Settings\NSUCC");
            un = Convert.ToString(key.GetValue("UN"));
            pw = Convert.ToString(key.GetValue("PW"));
        }
        private static string DoMD5(string string_6)//MD5 hash
        {
            return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(Encoding.Default.GetBytes(string_6))).Replace("-", "");
        }
        public static string DoDES(string string_6, string string_7, bool bool_2 = false)//DES hash
        {
            //string_6 == UN
            //string_7 == PW
            string str;

            byte[] bytes;
            CryptoStream stream2;
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            MemoryStream stream = new MemoryStream();
            provider.Key = Encoding.ASCII.GetBytes(DoMD5(string_7).Substring(0, 8));
            provider.IV = provider.Key;
            if (bool_2)
            {
                bytes = Convert.FromBase64String(string_6);
                stream2 = new CryptoStream(stream, provider.CreateDecryptor(), CryptoStreamMode.Write);
            }
            else
            {
                bytes = Encoding.UTF8.GetBytes(string_6);
                stream2 = new CryptoStream(stream, provider.CreateEncryptor(), CryptoStreamMode.Write);
            }
            stream2.Write(bytes, 0, bytes.Length);
            stream2.FlushFinalBlock();
            if (bool_2)
            {
                return Encoding.UTF8.GetString(stream.ToArray());
            }
            str = Convert.ToBase64String(stream.ToArray());
            return str;
        }
        public static void smethod_17()//变换hashtable
        {
            int num = 1;
            do
            {
                Thread.Sleep(1000);
                if (Main.bool_0 | Main.bool_1)
                {
                    break;
                }
                Hashtable hashtable = new Hashtable();
                hashtable.Add("K", "WAIT");
                hashtable.Add("T", DateAndTime.Now.Ticks);
                hashtable.Add("Token", Main.long_0);
                string item = Main.javaScriptSerializer_0.Serialize(hashtable);
                Main.list_0.Add(87);
                Main.queue_0.Enqueue(item);
                num++;
            }
            while (num <= 30);
            if (!Main.bool_0 & !Main.bool_1)
            {
                Main.smethod_1(Main.string_4);
                //貌似没卵用的函数，到这儿就失败了。
            }
        }
        public static void smethod_10()//手动注销
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("K", "LOGOUT");
            hashtable.Add("T", DateAndTime.Now.Ticks);
            hashtable.Add("Token", Main.long_0);
            string item = Main.javaScriptSerializer_0.Serialize(hashtable);
            Main.list_0.Add(88);
            Main.queue_0.Enqueue(item);
            Main.bool_0 = false;
            //Main.smethod_28();
            
        }
    }
}
