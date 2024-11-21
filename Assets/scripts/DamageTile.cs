using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "DamageTile", menuName = "2D/Tiles/DamageTile", order = 2)]
public class DamageTile : CustomTile
{
    public int damageAmount = 10;

    public override void PerformOnceEffect(Player player, Tilemap tilemap, Vector3Int position)
    {
        player.ModifyHealth(-damageAmount);
    }

    public override void PerformContinousEffect(
        Player player,
        Tilemap tilemap,
        Vector3Int position
    ) { }
}
