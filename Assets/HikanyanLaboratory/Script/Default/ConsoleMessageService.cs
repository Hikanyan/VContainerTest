﻿using UnityEngine;

namespace HikanyanLaboratory.Script.Default
{
    public class ConsoleMessageService : IMessageService
    {
        public void SendMessage(string message)
        {
            Debug.Log(message);
        }
    }
}