using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileInteraction : MonoBehaviour
{
    public Tilemap tilemap;
    public Player player;

    private void Update()
    {
        Bounds colliderBounds = player.ColliderBounds();

        Vector3Int minCell = tilemap.WorldToCell(colliderBounds.min);
        Vector3Int maxCell = tilemap.WorldToCell(colliderBounds.max);

        List<Vector3Int> interacted = new List<Vector3Int>();

        for (int x = minCell.x; x <= maxCell.x; x++)
        {
            for (int y = minCell.y; y <= maxCell.y; y++)
            {
                Vector3Int cellPosition = new Vector3Int(x, y, 0);
                TileBase tile = tilemap.GetTile(cellPosition);

                if (tile is CustomTile specialTile)
                {
                    interacted.Add(cellPosition);
                    specialTile.InteractWithPlayer(player, tilemap, cellPosition);
                }
            }
        }

        foreach (var tilePosition in tilemap.cellBounds.allPositionsWithin)
        {
            if (!interacted.Contains(tilePosition))
            {
                TileBase tile = tilemap.GetTile(tilePosition);
                if (tile is CustomTile specialTile)
                {
                    specialTile.ResetInteractionStateWithPlayer();
                }
            }
        }
    }
}
