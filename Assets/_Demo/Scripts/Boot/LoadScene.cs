using UnityEngine;
using UnityEngine.SceneManagement;

namespace Demo.Initialise
{
    public class LoadScene : MonoBehaviour
    {
        [SerializeField] private int _sceneIndex;

        private void Start()
        {
            SceneManager.LoadScene(_sceneIndex);
        }
    }
}