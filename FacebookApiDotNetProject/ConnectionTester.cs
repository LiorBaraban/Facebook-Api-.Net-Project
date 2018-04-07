using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

namespace FacebookApiDotNetProject_BeSocial_Logic
{
    public class ConnectionTester : ITester
    {
        private string m_UrlLink;

        public ConnectionTester(string i_UrlLink)
        {
            m_UrlLink = i_UrlLink;
        }

        public bool Test()
        {
            bool isValid = false;
            Uri uri = new Uri(m_UrlLink);
            Ping ping = new Ping();
            PingReply pingReply = ping.Send(uri.Host);
            if (pingReply.Status == IPStatus.Success)
            {
                isValid = true;
            }
            else
            {
                throw new Exception("Couldn't reach site");
            }

            return isValid;
        }
    }
}