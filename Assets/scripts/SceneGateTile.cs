using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "SceneGate", menuName = "2D/Tiles/SceneGate", order = 3)]
public class SceneGate : CustomTile
{
    public string NextScene;

    public override void PerformOnceEffect(Player player, Tilemap tilemap, Vector3Int position)
    {
        SceneManager.LoadScene(this.NextScene);
    }

    public override void PerformContinousEffect(
        Player player,
        Tilemap tilemap,
        Vector3Int position
    ) { }
}
