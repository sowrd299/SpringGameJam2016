using UnityEngine;
using UnityEngine.UI;

public class ImageSelect : MonoBehaviour {

    public Sprite chefSprt;
    public Sprite cowSprt;

	void Start () {
        int type = GetComponent<Ghost>().Type;
        Image img = GetComponentInChildren<Image>();
        switch (type) {
            case 4:
                img.sprite = chefSprt;
                break;
            case 5:
                img.sprite = cowSprt;
                break;
        }
	}

}
