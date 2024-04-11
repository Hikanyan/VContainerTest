namespace HikanyanLaboratory.Script.GameManager.System
{
    public class GameManager
    {
        private readonly StateMachine _stateMachine;

        public GameManager(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            // 初期ステートを設定
            ChangeState(new TitleState());
        }

        public void ChangeState(State newState)
        {
            _stateMachine.ChangeState(newState);
        }
    }
}