namespace HikanyanLaboratory.Script.VContainerTest.System
{
    public abstract class State
    {
        public abstract void Enter(); //ステート開始時の処理
        public abstract void Execute(); //ステート実行時の処理
        public abstract void Exit(); //ステート終了時の処理
    }
}