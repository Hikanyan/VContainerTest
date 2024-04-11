namespace HikanyanLaboratory.Script.GameManager.System
{
    public class GameManager
    {
        private readonly GameStateMachine _stateMachine;

        public GameManager(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            // 初期ステートを設定
            ChangeState(new TitleState());
        }

        public void ChangeState(GameState newState)
        {
            _stateMachine.ChangeState(newState);
        }
    }
}