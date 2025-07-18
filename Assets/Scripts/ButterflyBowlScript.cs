
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ButterflyBowlScript : UdonSharpBehaviour
{
    [SerializeField] GameObject[] butterflies;
    [SerializeField] GameObject particles;
    public bool isCorrectColor()
    {
        //Debug.Log("bowl correct? " + butterflies[0].GetComponent<ButterflyScript>().isCorrectColor());
        return butterflies[0].GetComponent<ButterflyScript>().isCorrectColor();
    }

    public void setColor(Material mat)
    {
        //Debug.Log("setting color in bowl");
        foreach (GameObject butterfly in butterflies)
        {
            butterfly.GetComponent<ButterflyScript>().setColor(mat);
        }
        Instantiate(particles, gameObject.transform.position,
            Quaternion.Euler(Vector3.zero));
        gameObject.GetComponent<AudioSource>().Play();
    }
}
