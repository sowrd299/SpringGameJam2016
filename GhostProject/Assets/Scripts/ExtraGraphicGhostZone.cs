using UnityEngine;
using System.Collections;
using System;

public class ExtraGraphicGhostZone : GhostZone {

    public GameObject extraGraphic;
    public Condition showExtraGraphic;

    void Start() {
        showExtraGraphic = GetComponent<BonusGhost>().showExtraGraphic;
    }

	protected override void playFront() {
        if(showExtraGraphic())extraGraphic.SetActive(true);
        base.playFront();
    }

    protected override void playBack() {
        extraGraphic.SetActive(false);
        base.playBack();
    }

}
