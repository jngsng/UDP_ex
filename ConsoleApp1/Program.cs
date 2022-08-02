using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // listening할 포트를 지정하고 UDP Client 객채를 생성
            UdpClient cli = new UdpClient(7777);

            string msg = "안녕하세요";
            byte[] datagram = Encoding.UTF8.GetBytes(msg);

            cli.Send(datagram, datagram.Length, "127.0.0.1", 7777);
            WriteLine("[Send] 127.0.0.1:7777 로 {0} 바이트 전송", datagram.Length);

            IPEndPoint epRemote = new IPEndPoint(IPAddress.Any, 7777);
            byte[] bytes = cli.Receive(ref epRemote);
            WriteLine("[Receive] {0} 로부터 {1} 바이트 수신", epRemote.ToString(), bytes.Length);

            cli.Close();
        }
    }
}
