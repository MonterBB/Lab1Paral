using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

#region TCP
//const string ip = "127.0.0.1";
//const int port = 8080;

//var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

//var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

//Console.WriteLine("Введите сообщение:");
//var message = Console.ReadLine();

//var data = Encoding.UTF8.GetBytes(message);

//tcpSocket.Connect(tcpEndPoint);
//tcpSocket.Send(data);

//var buffer = new byte[256];
//var size = 0;
//var answer = new StringBuilder();

//do
//{
//    size = tcpSocket.Receive(buffer);
//    answer.Append(Encoding.UTF8.GetString(buffer, 0, size));
//}
//while (tcpSocket.Available > 0);

//Console.WriteLine(answer.ToString());

//tcpSocket.Shutdown(SocketShutdown.Both);
//tcpSocket.Close();

//Console.ReadLine();
#endregion

const string ip = "127.0.0.1";
const int port = 8082;

var udpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

var udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
udpSocket.Bind(udpEndPoint);

while (true)
{
    Console.WriteLine("Введите сообщение:");
    var message = Console.ReadLine();

    var serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8081);//точка сервера
    udpSocket.SendTo(Encoding.UTF8.GetBytes(message), serverEndPoint);//отправка на сервер

    //Используется для получения сообщений
    //var buffer = new byte[256];
    //var size = 0;
    //var data = new StringBuilder();
    //EndPoint senderEndPoint = new IPEndPoint(IPAddress.Any, 0);

    //do
    //{

    //    size = udpSocket.ReceiveFrom(buffer, ref senderEndPoint);
    //    data.Append(Encoding.UTF8.GetString(buffer));
    //}
    //while (udpSocket.Available > 0);

    //Console.WriteLine(data);
}