﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TcpClient
static class Global
{
    private static TcpClient _globalVar = new TcpClient();

    public static TcpClient GlobalVar
    {
        get { return _globalVar; }
        //set { _globalVar = value; }
    }
}
static class Program
{
    /// <summary>
    /// Główny punkt wejścia dla aplikacji.
    /// </summary>
    [STAThread]
    static void Main()
    {
        //TcpClient client = new TcpClient();
        Global.GlobalVar.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2048));
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form1());
    }
}

