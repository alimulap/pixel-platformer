using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class CustomTile : Tile
{
    bool hasOnceInteractedWithPlayer = false;

    /// <summary>
    /// Perform a one-time interaction with the player and modify the tilemap.
    /// </summary>
    public abstract void PerformOnceEffect(Player player, Tilemap tilemap, Vector3Int position);

    /// <summary>
    /// Perform continuous interactions with the player and modify the tilemap.
    /// </summary>
    public abstract void PerformContinousEffect(
        Player player,
        Tilemap tilemap,
        Vector3Int position
    );

    /// <summary>
    /// Interact with the player, calling the appropriate interaction logic based on interaction state.
    /// </summary>
    public void InteractWithPlayer(Player player, Tilemap tilemap, Vector3Int position)
    {
        if (this.hasOnceInteractedWithPlayer)
        {
            this.PerformContinousEffect(player, tilemap, position);
        }
        else
        {
            this.PerformOnceEffect(player, tilemap, position);
            this.PerformContinousEffect(player, tilemap, position);
            this.hasOnceInteractedWithPlayer = true;
        }
    }

    /// <summary>
    /// Reset the interaction state for this tile (e.g., when the player leaves the tile).
    /// </summary>
    public void ResetInteractionStateWithPlayer()
    {
        this.hasOnceInteractedWithPlayer = false;
    }
}
