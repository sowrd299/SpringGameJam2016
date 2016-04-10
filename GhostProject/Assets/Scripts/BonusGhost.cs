using UnityEngine;

public class BonusGhost : Ghost {  //its funny because they are actually bad things

    /*
    a ghost type that is worth a unique type of points
    for now, all all bad, "daemon ghosts"
    */

    public int pointsValue = -20; //public for unity; do not access
    public new int PointsValue {
        get { return pointsValue; }
    }

    public override void init(int type, Vector2 minPos, Vector2 maxPos) {
        base.init(type, minPos, maxPos);
    }

    public bool showExtraGraphic() {
        /*
        the Condition underwhich their extra graphic is to be displayed
        */
        return lm.TargetType != Type;
    }

}
