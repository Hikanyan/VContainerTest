using HikanyanLaboratory.UISystemTest.Example;
using UnityEngine;

namespace HikanyanLaboratory.UISystemTest
{
    public class UITest : MonoBehaviour
    {
        private UIManager _uiManager;
        private UIScene _scene;
        private UIWindow _window;
        private UIScreen _screen1;
        private UIScreen _screen2;

        private void Start()
        {
            _uiManager = UIManager.Instance;
            _scene = _uiManager.Open<MainScene>(PrefabKeys.MainScene);
            _window = _uiManager.Open<MainWindow>(PrefabKeys.MainWindow, _scene);
            _uiManager.Open<Screen1>(PrefabKeys.Screen1, _window);
        }
    }
}