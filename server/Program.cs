using System.Net;
using System.Net.Sockets;
using System.Text;

#region TCP
//const string ip = "127.0.0.1";
//const int port = 8080;

//var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

//var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
//tcpSocket.Bind(tcpEndPoint);
//tcpSocket.Listen(5);

//while (true)
//{
//    var listener = tcpSocket.Accept();
//    var buffer = new byte[256];
//    var size = 0;
//    var data = new StringBuilder();

//    do
//    {
//        size = listener.Receive(buffer);
//        data.Append(Encoding.UTF8.GetString(buffer, 0, size));
//    }
//    while(listener.Available > 0);

//    Console.WriteLine(data);

//    listener.Send(Encoding.UTF8.GetBytes("Сервер получил сообщение"));

//    listener.Shutdown(SocketShutdown.Both);
//    listener.Close();
//}
#endregion

const string ip = "127.0.0.1"; //ip сервера
const int port = 8081; //порт сервера

var udpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port); //точка подключения

var udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp); //создание сокета
udpSocket.Bind(udpEndPoint);//сокет находится в режиме ожидания

while (true)
{
    var buffer = new byte[256]; //буфер для приёма сообщений
    var size = 0; //реальное количество принятых байт
    var data = new StringBuilder();
    EndPoint senderEndPoint = new IPEndPoint(IPAddress.Any, 0);//получать сообщения можно с любого ip:port

    do
    {
        size = udpSocket.ReceiveFrom(buffer, ref senderEndPoint);//получение сообщения
        data.Append(Encoding.UTF8.GetString(buffer));
    }
    while (udpSocket.Available > 0);//условие, что получен запрос

    udpSocket.SendTo(Encoding.UTF8.GetBytes("Сообщение получено!"), senderEndPoint);//отправить клиенту, что сообщение получено

    Console.WriteLine(data);//вывод сообщения
}



