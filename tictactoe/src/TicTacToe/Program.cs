﻿using System;

namespace Client
{

    class Program
    {

        static void Main(string[] args)
        {
            Console.Title = "Game Client";
            new Client("127.0.0.1", 13000);
        }

    }
}
