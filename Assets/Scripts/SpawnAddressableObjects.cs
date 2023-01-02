using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


public class VideoPlayer : MonoBehaviour
{
    // TODO here the video player
}

[System.Serializable]
public class AssetReferenceVideo : AssetReferenceT<VideoPlayer>
{
    public AssetReferenceVideo(string guid) : base(guid)
    {
    }
}

public class SpawnAddressableObjects : MonoBehaviour
{

    [SerializeField] AssetReference assetReference;
    [SerializeField] AssetLabelReference assetFolderWithLabel;
    [SerializeField] AssetReferenceGameObject assetGameObject;
    [SerializeField] AssetReferenceVideo assetVideoPlayer;

    // Use this for initialization
    void Start()
    {
        Debug.Log(UnityEngine.AddressableAssets.Addressables.BuildPath);
        Debug.Log(UnityEngine.AddressableAssets.Addressables.RuntimePath);
        GetAssets();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetAssets()
    {
        TextManager.Instance.SetText("Starting to load assets...", true);

        if (assetReference != null)
        {
            // TODO fix <Sprite>
            assetReference.LoadAssetAsync<Sprite>().Completed += (asyncOperationHandle) =>
            {
                if (asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
                {
                    //Instantiate(asyncOperationHandle.Result);
                    // TODO this is just a test...
                    TextManager.Instance.SetImage(asyncOperationHandle.Result);
                    TextManager.Instance.SetText("Added Sprite Asset to Unity UI!");
                }
                else
                {
                    Debug.Log("Failed to load asset!: " + asyncOperationHandle.DebugName);
                    TextManager.Instance.SetText("Failed to load asset!: " + asyncOperationHandle.DebugName);
                }
            };

        }
        if (assetFolderWithLabel != null)
        {
            // TODO fix this and make it dynamic!!!
            Addressables.LoadAssetsAsync<GameObject>(assetFolderWithLabel, (gameObject) =>
            {
                Instantiate(gameObject);
            }).Completed += (asyncOperationHandle) =>
            {
                if (asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
                {
                    Debug.Log("folder of assets loaded!");
                    TextManager.Instance.SetText("folder of assets loaded!");
                }
                else
                {
                    Debug.Log("Failed to load asset!: " + asyncOperationHandle.DebugName);
                    TextManager.Instance.SetText("Failed to load asset!: " + asyncOperationHandle.DebugName);
                }
            };

        }
        if (assetGameObject != null)
        {
            // TODO make this better...
            assetGameObject.LoadAssetAsync<GameObject>().Completed += (asyncOperationHandle) =>
            {
                if (asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
                {
                    GameObject obj = Instantiate(asyncOperationHandle.Result);
                    obj.transform.position = new Vector3(-5, 0, 0); // DEBUG...
                    TextManager.Instance.SetText("GameObject Asset loaded!");

                }
                else
                {
                    Debug.Log("Failed to load asset!: " + asyncOperationHandle.DebugName);
                    TextManager.Instance.SetText("Failed to load asset!: " + asyncOperationHandle.DebugName);
                }
            };
        }
        if (assetVideoPlayer != null)
        {
            Debug.Log("TODO...");
            TextManager.Instance.SetText("TODO VIDEOPLAYER Assets loader!");
        }



    }
}
