using UnityEngine;

namespace HikanyanLaboratory.Script.GameManager
{
    public class PlayState : GameState
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