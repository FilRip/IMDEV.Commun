using System;
using System.Collections.Generic;
using System.Text;

namespace IMDEV.InstantMessaging
{
    public class GTalk
    {
        private jabber.client.JabberClient _myClient;

        public void connect(string from, string pwd)
        {
            _myClient = new jabber.client.JabberClient();
            _myClient.Server = "gmail.com";
            _myClient.User = from;
            _myClient.Password = pwd;
            _myClient.Connect();
            _myClient.OnConnect += new jabber.connection.StanzaStreamHandler(_myClient_OnConnect);
            _myClient.OnAuthError += new jabber.protocol.ProtocolHandler(_myClient_OnAuthError);
        }

        public void sendMessage(string to, string message)
        {
            try
            {
                _myClient.OnMessage += new jabber.client.MessageHandler(_myClient_OnMessage);
                jabber.protocol.client.Message msg = new jabber.protocol.client.Message(_myClient.Document);
                msg.To = to;
                msg.Body = message;
                _myClient.Write(msg);
            }
            catch (Exception e)
            {
                throw new Exception("Error during sendMessage\r\n" + e.Message);
            }
        }

        private void _myClient_OnAuthError(object sender, System.Xml.XmlElement rp)
        {
            throw new Exception("Connection refused");
        }

        public delegate void delegateConnectionOK();
        public event delegateConnectionOK connectionOK;

        private void _myClient_OnConnect(object sender, jabber.connection.StanzaStream stream)
        {
            connectionOK();
        }

        private void _myClient_OnMessage(object sender, jabber.protocol.client.Message msg)
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            _myClient.Close(true);
        }
    }
}
