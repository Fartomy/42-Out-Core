using System.Net.WebSockets;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private GameObject shotPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float delayTime;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float lifeTime;
    private bool canShoot = true;

    void ShootTarget(ref Collider col)
    {
        if (!canShoot)
            return;

        var bullet = Instantiate(bulletPrefab, shotPoint.transform.position, shotPoint.transform.rotation);
        Renderer bltRndr = bullet.GetComponent<Renderer>();
        Material bltMtrl = new Material(bltRndr.sharedMaterial);
        bltMtrl.color = SetUpColor();
        bltRndr.material = bltMtrl;
        bullet.layer = LayerMask.NameToLayer(SetUpLayer());
        Vector3 targetDist = (col.transform.position - shotPoint.transform.position).normalized;
        Rigidbody bulletRgb = bullet.GetComponent<Rigidbody>();
        bulletRgb.AddForce(targetDist * bulletSpeed, ForceMode.VelocityChange);
        Destroy(bullet, lifeTime);

        canShoot = false;
        Invoke("ResetShootDelay", delayTime);
    }

    void ResetShootDelay()
    {
        canShoot = true;
    }

    Color SetUpColor()
    {
        if(transform.gameObject.tag == "turret_red")
            return Color.red;
        if(transform.gameObject.tag == "turret_yellow")
            return Color.yellow;
        if(transform.gameObject.tag == "turret_blue")
            return Color.blue;
        return Color.white;
    }

    string SetUpLayer()
    {
        if(transform.gameObject.tag == "turret_red")
            return "Red";
        if(transform.gameObject.tag == "turret_yellow")
            return "Yellow";
        if(transform.gameObject.tag == "turret_blue")
            return "Blue";
        return null;
    }

    void OnTriggerStay(Collider other)
    {
        if(transform.gameObject.tag == "turret_yellow" && other.gameObject.tag == "John")
            ShootTarget(ref other);
        if(transform.gameObject.tag == "turret_red" && other.gameObject.tag == "Thomas")
            ShootTarget(ref other);
        if(transform.gameObject.tag == "turret_blue" && other.gameObject.tag == "Claire")
            ShootTarget(ref other);
    }
}