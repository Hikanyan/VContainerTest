using UnityEngine;

namespace HikanyanLaboratory.Script
{
    public class ConsoleMessageService : IMessageService
    {
        public void SendMessage(string message)
        {
            Debug.Log(message);
        }
    }
}