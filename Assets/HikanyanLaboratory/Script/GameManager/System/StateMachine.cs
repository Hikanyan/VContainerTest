using VContainer.Unity;

namespace HikanyanLaboratory.Script.GameManager.System
{
    public class StateMachine : ITickable
    {
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