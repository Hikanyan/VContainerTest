using System.Collections;
using Cysharp.Threading.Tasks;
using UnityEngine.Assertions;
namespace HikanyanLaboratory.Script.VContainerScene
{
    public class UniTaskTests
    {
        private async UniTask<int> GetNumberAsync()
        {
            await UniTask.Delay(100);
            return 42;
        }

        public IEnumerator UniTask_ReturnsCorrectNumber() =>
            UniTask.ToCoroutine(async () =>
        {
            int result = await GetNumberAsync();
            Assert.AreEqual(42, result);
        });
    }
}