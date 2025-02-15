using UnityEngine;

namespace HikanyanLaboratory.Script.VContainerTest.System
{
    public class PlayState : State
    {
        public override void Enter()
        {
            Debug.Log("PlayState Enter");
        }

        public override void Execute()
        {
            Debug.Log("PlayState Execute");
        }

        public override void Exit()
        {
            Debug.Log("PlayState Exit");
        }
    }
}