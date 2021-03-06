﻿namespace TilePuzzle
{
    // 스톤헨지
    public class StoneHenge : WonderTile
    {
        public override void AddToDelegate()
        {
            TileManager.Instance.CalculateCost += WonderFunction;
        }

        // 초원이나 평원에 성지를 지으면 비용 - wonderBonus
        public override void WonderFunction(Tile currentTile, TileBuilding tileBuilding)
        {
            if (currentTile.MyTileTerrain == TileTerrain.Grassland ||
                currentTile.MyTileTerrain == TileTerrain.Plains)
            {
                if (tileBuilding == TileBuilding.HolySite)
                {
                    TileManager.Instance.SelectTileCost -= wonderBonus;
                }
            }
        }

        // 성지 옆에 건설 가능
        public override bool WonderLimit(Tile currentTile)
        {
            if (currentTile.MyTileType == TileType.Water ||
                currentTile.MyTileType == TileType.Mountain)
            {
                return false;
            }

            foreach (var neighbor in currentTile.NeighborTiles)
            {
                if (neighbor.MyTileBuilding == TileBuilding.HolySite)
                {
                    return true;
                }
            }

            return false;
        }
    }
}