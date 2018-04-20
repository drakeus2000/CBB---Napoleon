#pragma strict

function Start () {

}

function Update () {
     var pos = Camera.main.WorldToScreenPoint(transform.position);
     var dir = pos - Input.mousePosition;
     var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
     transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); 
}