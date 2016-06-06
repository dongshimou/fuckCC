using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = "UserName";
            label2.Text = "Password";
            button1.Text = "Login in";
            init();
        }
        void init()
        {
            string un, pw;
            RegistryKey key = Registry.Users.CreateSubKey(@".DEFAULT\Software\VB and VBA Program Settings\NSUCC");
            un = Convert.ToString(key.GetValue("UN"));
            pw = Convert.ToString(key.GetValue("PW"));
            textBox1.Text = Main.DoDES(un, "UN", true);
            textBox2.Text = Main.DoDES(pw, "PW", true);
        }
        void save()
        {
            RegistryKey registryKey = Registry.Users.CreateSubKey(".DEFAULT\\Software\\VB and VBA Program Settings\\NSUCC");
            string un, pw;
            un = textBox1.Text;
            pw = textBox2.Text;
            un = Main.DoDES(un, "UN", false);
            pw = Main.DoDES(pw, "PW", false);
            registryKey.SetValue("UN", un);
            registryKey.SetValue("PW", pw);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Login();
            //save();
        }
        void Login()
        {
            Main.smethod_8(textBox1.Text, textBox2.Text, true);
            //开始登录

            Main.ipendPoint_0 = new IPEndPoint(Dns.GetHostAddresses("net.nsu.edu.cn")[0], 8080);
            Main.udpClient_0.Client.IOControl((IOControlCode)2550136844L, new byte[1], null);
            Main.rsacryptoServiceProvider_0.FromXmlString(Main.string_2);

            Thread thread1 = new Thread(new ThreadStart(Main.smethod_19));
            thread1.Start();
            Thread thread2 = new Thread(new ThreadStart(Main.smethod_6));
            thread2.Start();
            Thread thread3 = new Thread(new ThreadStart(Main.smethod_5));
            thread3.Start();
            Thread thread4 = new Thread(new ThreadStart(Main.smethod_4));
            thread4.Start();

        }
    }
}
