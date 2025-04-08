using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace CardFlip
{
    public class SettiingBack : MonoBehaviour
    {
        UnityEngine.AsyncOperation op;
        public void Back()
        {
            op = SceneManager.UnloadSceneAsync("SettingScene");
            StartCoroutine(SceneLoadProgress());

        }

        private IEnumerator SceneLoadProgress()
        {
            while (true)
            {
                Debug.Log(op.progress);
                yield return null;
            }
        }
    }
}
