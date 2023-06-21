using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ImageLoader : MonoBehaviour
{
    public static ImageLoader Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadAndSetImageFromURL(string link, Action<Sprite> callback = null)
    {
        StartCoroutine(LoadAndSetImageFromURL_Coroutine(link, callback));
    }

    private IEnumerator LoadAndSetImageFromURL_Coroutine(string link, Action<Sprite> callback = null)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(link);
        yield return request.SendWebRequest();

        switch (request.result) 
        {
            case UnityWebRequest.Result.DataProcessingError:
            case UnityWebRequest.Result.ConnectionError:
            case UnityWebRequest.Result.ProtocolError:
                {
                    Debug.LogError(request.error);
                }
                break;

            default:
                {
                    Texture2D texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
                    Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

                    yield return new WaitForEndOfFrame();
                    callback?.Invoke(sprite);
                }
                break;
        }
    }
}
