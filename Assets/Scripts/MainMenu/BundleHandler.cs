using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class BundleHandler : MonoBehaviour
{
    public static BundleHandler bundlehandler;
    public string[] url, sceneNames;

    static AssetBundle assetBundle;
    WWW www;
    public Image loading;

    bool loadingStart = false;
    private void Awake()
    {
        if (bundlehandler == null)
        {
            bundlehandler = this;
        }

    }
    private void Start()
    {
    }


    private void Update()
    {
        if (loadingStart)
        {
            double v = www.progress;

            loading.fillAmount = (float)v;//portrait

        }

    }

    public void playGamePressed(int i)
    {

        StartCoroutine(s(i));
    }
    IEnumerator s(int i)
    {
        if (!assetBundle)
        {
            using (www = new WWW(url[i]))
            {
                loadingStart = true;
                yield return www;
                if (!string.IsNullOrEmpty(www.error))
                {
                    print(www.error);
                    yield break;

                }
                assetBundle = www.assetBundle;

            }
        }
        loadingStart = false;
        string[] scenes = assetBundle.GetAllScenePaths();

        foreach (string s in scenes)
        {
            print(Path.GetFileNameWithoutExtension(s));
            //print(Path.GetFileNameWithoutExtension(s));
            //loadScene(Path.GetFileNameWithoutExtension(s));
            if (Path.GetFileNameWithoutExtension(s) == sceneNames[i])
            {
                loadScene(Path.GetFileNameWithoutExtension(s));
            }
        }
    }


    public void loadScene(string name)
    {

        SceneManager.LoadScene(name);
    }




}