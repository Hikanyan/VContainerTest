using System.Collections.Generic;
using VContainer.Unity;

namespace HikanyanLaboratory.Script.VContainerTest.System
{
    public class StateMachine : ITickable
    {
        // 今のステート
        private State _currentState;

        // ステートの実行
        public void Tick()
        {
            _currentState?.Execute();
        }

        // ステートの変更
        public void ChangeState(State newState)
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState?.Enter();
        }
    }
}