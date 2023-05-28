using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Shoot Ability", order = 2)]
public class ShootAbility : Ability
{
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    [SerializeField] private Transform bulletPrefab;

    public override void Activate(GameObject character)
    {
        Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 ScreenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(ScreenCenterPoint);
        if(Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            mouseWorldPosition = raycastHit.point;
        }

        Transform bulletSpawnPosition = character.transform.GetComponentInChildren<BulletSpawnPosition>().transform;

        Vector3 aimDir = (mouseWorldPosition - bulletSpawnPosition.position).normalized;
        Instantiate(bulletPrefab, bulletSpawnPosition.position, Quaternion.LookRotation(aimDir, Vector3.up));
    }
}
