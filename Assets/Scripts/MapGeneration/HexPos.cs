﻿using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TilePuzzle
{
    [Serializable, InlineProperty(LabelWidth = 13)]
    public struct HexagonPos : IEquatable<HexagonPos>
    {
        [SerializeField, HideLabel]
        private readonly Vector3Int pos;

        public HexagonPos(int hexX, int hexZ)
        {
            pos = new Vector3Int(hexX, -hexX - hexZ, hexZ);
        }

        public static HexagonPos ArrayXYToHexPos(int x, int y)
        {
            int hexX = x - (y >> 1);
            int hexZ = y;
            return new HexagonPos(hexX, hexZ);
        }

        public Vector2Int ToArrayXY()
        {
            int arrayX = pos.x + (pos.z >> 1);
            int arrayY = pos.z;
            return new Vector2Int(arrayX, arrayY);
        }

        public Vector3 ToWorldPos(float worldY = 0)
        {
            //float worldX = (pos.y & 1) == 0
            //    ? pos.x * Hexagon.Size
            //    : (pos.x * Hexagon.Size) + (Hexagon.Size / 2);
            //float worldZ = pos.y * Hexagon.Size * Mathf.Sin(Mathf.PI / 3);

            float worldX = pos.x * Hexagon.Size + pos.z * Hexagon.Size / 2;
            float worldZ = pos.z * Hexagon.Size * Mathf.Sin(Mathf.PI / 3);
            return new Vector3(worldX, worldY, worldZ);
        }

        public override bool Equals(object obj)
        {
            return obj is HexagonPos pos && Equals(pos);
        }

        public bool Equals(HexagonPos other)
        {
            return pos.Equals(other.pos);
        }

        public override int GetHashCode()
        {
            return 991532785 + pos.GetHashCode();
        }

        public override string ToString()
        {
            return pos.ToString();
        }

        public static bool operator ==(HexagonPos left, HexagonPos right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(HexagonPos left, HexagonPos right)
        {
            return !(left == right);
        }
    }
}
