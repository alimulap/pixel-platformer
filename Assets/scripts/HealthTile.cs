using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "HealthTile", menuName = "2D/Tiles/HealthTile", order = 1)]
public class HealthTile : CustomTile
{
    public int healAmount = 10;

    public override void PerformOnceEffect(Player player, Tilemap tilemap, Vector3Int position)
    {
        player.ModifyHealth(healAmount);

        tilemap.SetTile(position, null);
    }

    public override void PerformContinousEffect(
        Player player,
        Tilemap tilemap,
        Vector3Int position
    ) { }
}
