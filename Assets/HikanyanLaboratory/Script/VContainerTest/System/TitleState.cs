using UnityEngine;

namespace HikanyanLaboratory.Script.VContainerTest.System
{
    public class TitleState : State
    {
        public override void Enter()
        {
            Debug.Log("TitleState Enter");
        }

        public override void Execute()
        {
            Debug.Log("TitleState Execute");
        }

        public override void Exit()
        {
            Debug.Log("TitleState Exit");
        }
    }
}