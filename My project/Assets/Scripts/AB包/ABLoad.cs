using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //����AB��������Ϊprefab
        AssetBundle ab = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/prefabs");

        //���������������ҵ���������PC
    //  AssetBundle main_ab = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/����");
        //���������Ĺ̶��ļ����ļ�������AssetBundleManifest��������һ��
    //   AssetBundleManifest abm = main_ab.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
        //ͨ���̶��ļ��õ�������Ϣ��������Ҫ��ȡ������Ϣ��AB����
    //   string[] depends = abm.GetAllDependencies("prefab");
        //����ȫ��������
        //foreach (string depend in depends)
        //{
        //    AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/" + depend);
        //}

        //����AB���е���Դ
        GameObject go = ab.LoadAsset<GameObject>("AbTest");
        Instantiate(go);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
