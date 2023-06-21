using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;

    [SerializeField]
    private GameObject _loaderCanvas;
    [SerializeField]
    private Image _progressBar;
    [SerializeField]
    private float _progressBarFillSpeed = 3;
    [SerializeField]
    private TMPro.TextMeshProUGUI _progressText;


    private bool _inLoad = false;
    private float _time;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public async void LoadScene(SceneName sceneName)
    {
        if (_inLoad)
            return;
        
        _inLoad = true;
        _time = 0;
        _progressBar.fillAmount = 0;
        var scene = SceneManager.LoadSceneAsync(sceneName.ToString());

        scene.allowSceneActivation = false;
        _loaderCanvas.SetActive(true);

        do
        {
            await Task.Delay(100);
            _time = scene.progress;
            _progressText.SetText($"Загрузка... ( {_time * 100}/100% )");
        }
        while (scene.progress < 0.9f);

        await Task.Delay(3000);
        scene.allowSceneActivation = true;
        await Task.Delay(1000);
        _loaderCanvas.SetActive(false);

        _inLoad = false;
    }

    private void Update()
    {
        _progressBar.fillAmount = Mathf.MoveTowards(_progressBar.fillAmount, _time, _progressBarFillSpeed * Time.deltaTime);
    }
}
