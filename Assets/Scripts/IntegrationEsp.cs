using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System;

public class IntegrationEsp : MonoBehaviour
{

    //serialPort public float velocity;
    //SerialPort serialPort = new SerialPort("COM2", 9600);

    SerialPort serialPort;
    byte[] buf = new byte[4]; // creates a byte array the size of the data you want to receive.
    int bufCount = 0;
    int a, b;
    // Start is called before the first frame update
    void Start()
    {
        serialPort.Open();
        serialPort.ReadTimeout = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (serialPort.IsOpen)
        {
            try
            {
                Movement(serialPort.ReadByte);
            }
            catch(System.Exception)
            {

            }
        }
        
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 100, 50), "read"))
        {
            serialPort.PortName = "COM1";
            serialPort.Parity = Parity.None;
            serialPort.BaudRate = 9600;
            serialPort.DataBits = 8;
            serialPort.StopBits = StopBits.One;
            serialPort.Open();
            bufCount = 0;
            bufCount += serialPort.Read(buf, bufCount, buf.Length - bufCount);

            a = 0;
            b = 0;
            while (a < bufCount)
            {
                b += buf[a];
                a++;
            }
            print(b);
            serialPort.Close();


        }
    }

    private void Movement(Func<int> readByte)
    {
        throw new NotImplementedException();
    }

    //   void Movement(int direcao)
    //     {
    //       if(direcao == 1)
    //       {
    //transform.Translate(-Vector2.right * velocity * Time.deltaTime, Space.World);
    //}
    //if (direcao == 2)
    //        {
    //transform.Translate(Vector2.right * velocity * Time.deltaTime, Space.World);
    //}
    //}

}
