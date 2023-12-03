using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.UI;

public class WebCameraRender : MonoBehaviour
{
    public RawImage rawImage;
    private WebCamTexture webCamTexture;

    void Start()
    {
        // �������� ������ � ������ ����������
        WebCamDevice[] devices = WebCamTexture.devices;
        if (devices.Length > 0)
        {
            webCamTexture = new WebCamTexture(devices[0].name);
            rawImage.texture = webCamTexture;
            webCamTexture.Play();
        }
        else
        {
            Debug.LogError("No camera found on the device.");
        }
    }

    void Update()
    {
        // ��������� ����������� �� RawImage
        if (webCamTexture.isPlaying)
        {
            rawImage.texture = webCamTexture;
        }
    }

    void OnDestroy()
    {
        // ������������� ������ ��� ����������� �������
        if (webCamTexture != null && webCamTexture.isPlaying)
        {
            webCamTexture.Stop();
        }
    }

}
