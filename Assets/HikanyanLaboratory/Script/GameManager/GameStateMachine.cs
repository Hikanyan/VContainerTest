namespace HikanyanLaboratory.Script.GameManager
{
    public class GameStateMachine
    {
        private GameState _currentState;

        public void ChangeState(GameState newState)
        {
            _currentState?.Exit();
            //_currentState.Execute();
            _currentState = newState;
            _currentState.Enter();
        }
    }
}