using System;
using UnityEngine;
using UnityEngine.UI;

public class Splash : MonoBehaviour {

    public Text text; //public for unity; do not access
    public Image image; //public for unity; do not access
    private Graphic current;

    //public for unity; do not access
    public int steps = 15;

    public float startSize = 1f;
    public float endSize = 2f;
    private float size;

    public float startAlpha = 50f;
    public float endAlpha = 0f;
    private float alpha;

    private Color color;

    void Start() {
    void Awake() {
        
        //ignor that this is in Dutch...
        Debug.Log("Het is wel aan het starten!");

        //defaults for variables
        MyUnityTools.dflt(ref text, "SplashText");
        MyUnityTools.dflt(ref image, "SplashImage");
    /*
    }

    void Start(){
    */
        //become invisible
        Debug.Log("Turning splash elements off.");
        image.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
        Debug.Log("Splash elemenents are " + image.gameObject.activeSelf.ToString() + "," + text.gameObject.activeSelf.ToString());
    }

    void Update() {
        if (current != null) {
            Debug.Log("Running the splash");
            size += (endSize - startSize) / steps;
            alpha += (endAlpha - startAlpha) / steps;
            Color c = color;
            c.a = alpha;
            current.color = c;
            Debug.Log(current.color.a);
            current.rectTransform.localScale = new Vector3(size, size, size);
            Debug.Log(text.rectTransform.localScale.x);
            if(Math.Sign(alpha-endAlpha) != Math.Sign(startAlpha-endAlpha) ||
               Math.Sign(size-endSize) != Math.Sign(startSize-endSize)) {
                //stop running when apropriate
                current = null;
                text.gameObject.SetActive(false);
                image.gameObject.SetActive(false);
            }
        }
    }

    public void splash(Sprite s, Color c) {
        /*
        splashes s to the screen
        */
        image.sprite = s;
        text.gameObject.SetActive(false);
        image.gameObject.SetActive(true);
        current = image;
        _splash(c);
    }

    public void splash(string s, Color c) {
        /*
        splashes s  to the screen
        */
        text.text = s;
        current = text;
        text.gameObject.SetActive(true);
        image.gameObject.SetActive(false);
        _splash(c);
    }

    private void _splash(Color c) {
        //the parts of splash shared by splash(Image) and splash(Text)
        alpha = startAlpha;
        size = startSize;
        color = c;
    }
}
