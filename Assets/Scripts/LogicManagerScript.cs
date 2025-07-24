using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class LogicManagerScript : UdonSharpBehaviour
{
    public int itemsFound = 0;
    [SerializeField] int itemsToWin = 5;
    [SerializeField] GameObject explosion;
    [SerializeField] float expX, expY, expZ;
    [SerializeField] float expRate;
    private float time = 0;
    [SerializeField] GameObject magicCircle;
    [SerializeField] float magicTime = 1;
    private bool circleOn = true;
    private GameObject obj;
    [SerializeField] float circleOffset;
    [SerializeField] float soundRateMin;
    [SerializeField] float soundRateMax;
    private float soundRate;
    private float soundTime = 0;
    [SerializeField] GameObject bgm;

    [Header("Fade to Black Settings")]
    [SerializeField] CanvasGroup fadeCanvasGroup; // Assign this in Inspector
    [SerializeField] Transform fadeCanvasTransform;
    [SerializeField] float fadeDelay = 300f;        // Time after sequence to start fade
    [SerializeField] float fadeDuration = 2f;     // Duration of fade to black
    private bool isFading = false;
    private float fadeTimer = 0f;

    private VRCPlayerApi localPlayer;

    private void Start()
    {
        soundRate = Random.Range(soundRateMin, soundRateMax);
        localPlayer = Networking.LocalPlayer;
    }

    void Update()
    {
        // 🔁 Continuously follow the player's head
        if (localPlayer != null && fadeCanvasTransform != null)
        {
            Vector3 headPos = localPlayer.GetTrackingData(VRCPlayerApi.TrackingDataType.Head).position;
            Quaternion headRot = localPlayer.GetTrackingData(VRCPlayerApi.TrackingDataType.Head).rotation;
            Vector3 headForward = headRot * Vector3.forward;

            // Position 1 meter in front of the head
            fadeCanvasTransform.position = headPos + headForward * 1f;
            fadeCanvasTransform.rotation = Quaternion.LookRotation(headForward, Vector3.up);
        }

        // 👇 Rest of your explosion/fade logic (unchanged)
        if (itemsFound == itemsToWin)
        {
            if (time == 0)
            {
                bgm.GetComponent<AudioSource>().Stop();
                obj = Instantiate(magicCircle, new Vector3(expX, gameObject.transform.position.y + circleOffset, expZ), Quaternion.Euler(Vector3.zero));
            }

            if (circleOn && time > magicTime)
            {
                circleOn = false;
                time = 1 + 1 / expRate;
                soundTime = 1 + 1 / soundRate;
                Destroy(obj);
            }

            if (!circleOn)
            {
                if (expRate == 0 || time > 1 / expRate)
                {
                    time = 0;
                    Instantiate(explosion, new Vector3(expX, expY, expZ), Quaternion.Euler(Vector3.zero));
                }

                if (soundRate == 0 || soundTime > 1 / soundRate)
                {
                    soundTime = 0;
                    soundRate = Random.Range(soundRateMin, soundRateMax);
                    gameObject.GetComponent<AudioSource>().Play();
                }

                // Begin fade logic
                if (!isFading)
                {
                    fadeTimer += Time.deltaTime;
                    if (fadeTimer >= fadeDelay)
                    {
                        isFading = true;
                        fadeTimer = 0f;
                        Debug.Log("Fade to black initiated.");
                    }
                }
                else
                {
                    if (fadeCanvasGroup != null && fadeCanvasGroup.alpha < 1f)
                    {
                        fadeCanvasGroup.alpha += Time.deltaTime / fadeDuration;
                    }
                }

                if (fadeCanvasGroup != null && fadeCanvasGroup.alpha < 1f)
                {
                    fadeCanvasGroup.alpha += Time.deltaTime / fadeDuration;
                    Debug.Log("Canvas Alpha: " + fadeCanvasGroup.alpha);
                }
            }

            soundTime += Time.deltaTime;
            time += Time.deltaTime;
        }
    }
}