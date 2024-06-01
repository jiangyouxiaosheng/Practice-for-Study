using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //加载AB包，包名为prefab
        AssetBundle ab = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/prefabs");

        //加载主包，这里我的主包名是PC
    //  AssetBundle main_ab = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/主包");
        //加载主包的固定文件，文件名称是AssetBundleManifest，与类名一致
    //   AssetBundleManifest abm = main_ab.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
        //通过固定文件得到依赖信息，传入需要获取依赖信息的AB包名
    //   string[] depends = abm.GetAllDependencies("prefab");
        //加载全部依赖包
        //foreach (string depend in depends)
        //{
        //    AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/" + depend);
        //}

        //加载AB包中的资源
        GameObject go = ab.LoadAsset<GameObject>("AbTest");
        Instantiate(go);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
