using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class ConnectServer
{
    //casa 192.168.1.132
    //cole 192.168.12.27
    Socket listen;
    IPEndPoint connect;

    public ConnectServer()
    {
        Connect();
    }

    public void Connect()
    {
        listen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        connect = new IPEndPoint(IPAddress.Parse("192.168.12.27"), 20001);
        listen.Connect(connect);               
    }

    public void Disconnect()
    {
        listen.Shutdown(SocketShutdown.Both);
        listen.Close();
    }

     public void InsertHistorial(String datos)
     {
        byte[] opcion = { 1 };
        listen.Send(opcion);      

        Byte[] ok = new byte[8]; 
        listen.Receive(ok);

        byte[] info = Encoding.Default.GetBytes(datos);
        listen.Send(info);

        Disconnect();
     }

    public void InsertRanking(String data)
    {       
        byte[] opcion = { 2 };
        listen.Send(opcion);

        Byte[] ok = new byte[8];
        listen.Receive(ok);

        byte[] info = Encoding.Default.GetBytes(data);
        listen.Send(info);

        Disconnect();
    }

    public String[] getRanking()
    {
        String[] ranking = new String[5];
        byte[] opcion = { 3 };
        listen.Send(opcion);

        //Posicion
        byte[] info = new byte[100];     
        listen.Receive(info);
        ranking[0]= Encoding.Default.GetString(info);
        byte[] next = { 1 };
        listen.Send(next);
        info = null;

        //Posicion    
        listen.Receive(info);
        ranking[1] = Encoding.Default.GetString(info);
        listen.Send(next);
        info = null;

        //Posicion    
        listen.Receive(info);
        ranking[2] = Encoding.Default.GetString(info);
        listen.Send(next);
        info = null;

        //Posicion    
        listen.Receive(info);
        ranking[3] = Encoding.Default.GetString(info);
        listen.Send(next);
        info = null;

        //Posicion    
        listen.Receive(info);
        ranking[4] = Encoding.Default.GetString(info);

        Disconnect();
        return ranking;
    }


    public void CloseServer()
    {
        byte[] opcion = { 0 };
        //num = BitConverter.GetBytes(opcion);
        listen.Send(opcion);

        Byte[] ok = new byte[8];
        listen.Receive(ok);

        Disconnect();
    }
}