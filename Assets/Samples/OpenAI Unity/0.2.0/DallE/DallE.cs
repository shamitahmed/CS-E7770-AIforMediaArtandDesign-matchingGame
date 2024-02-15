using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Threading.Tasks;

namespace OpenAI
{
    public class DallE : MonoBehaviour
    {
        public static DallE instance;
        [SerializeField] private InputField inputField;
        [SerializeField] private Button button;
        [SerializeField] public Image[] images;
        [SerializeField] private GameObject loadingLabel;

        private OpenAIApi openai = new OpenAIApi();

        private void Start()
        {
            instance = this;
            //button.onClick.AddListener(SendImageRequest);
        }

        public async void SendImageRequest(string input, int imageID)
        {
            images[imageID].sprite = null;
            button.enabled = false;
            inputField.enabled = false;
            loadingLabel.SetActive(true);

            var response = await openai.CreateImage(new CreateImageRequest
            {
                //Prompt = inputField.text,
                Prompt = input + "cartoon" + "white background",
                Size = ImageSize.Size256,
                //Model = "dall-e-3",
                //Quality = "standard",
                //N = 1,
            });

            if (response.Data != null && response.Data.Count > 0)
            {
                using(var request = new UnityWebRequest(response.Data[0].Url))
                {
                    request.downloadHandler = new DownloadHandlerBuffer();
                    request.SetRequestHeader("Access-Control-Allow-Origin", "*");
                    request.SendWebRequest();

                    while (!request.isDone) await Task.Yield();

                    Texture2D texture = new Texture2D(2, 2);
                    texture.LoadImage(request.downloadHandler.data);
                    var sprite = Sprite.Create(texture, new Rect(0, 0, 256, 256), Vector2.zero, 1f);
                    images[imageID].sprite = sprite;

                    if (request.isDone)
                    {
                        GameManager.instance.btnPlay.gameObject.SetActive(true);
                        GameManager.instance.panelGPT.SetActive(false);
                    }
                }
            }
            else
            {
                Debug.LogWarning("No image was created from this prompt.");
            }

            button.enabled = true;
            inputField.enabled = true;
            loadingLabel.SetActive(false);
        }
    }
}
