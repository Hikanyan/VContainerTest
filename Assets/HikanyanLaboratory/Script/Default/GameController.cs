using UnityEngine;
using VContainer;

namespace HikanyanLaboratory.Script.Default
{
    public class GameController : MonoBehaviour
    {
        [Inject] public IMessageService MessageService { get; set; }

        void Start()
        {
            MessageService.SendMessage("Hello, World!");
        }
    }
}