using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace fuckCC
{
    public class netTest
    {
        NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
        public netTest()
        {

        }
        public void test()
        {
            foreach (var i in allNetworkInterfaces)
            {
                string text = i.GetPhysicalAddress().ToString();
                string id = i.Id;
            }
        }

    }
}
