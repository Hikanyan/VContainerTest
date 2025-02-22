namespace HikanyanLaboratory.UISystem
{
    public class TitleSceneModel
    {
        // データモデルの定義
        public void StartGame()
        {
            UIManager.Instance.Open<ScenarioScenePresenter>(PrefabKeys.ScenarioScene);
            UIManager.Instance.Close<TitleScenePresenter>();
        }

        public void OpenTitleMenu()
        {
            //UIManager.Instance.Open<>()
        }
        
    }
}