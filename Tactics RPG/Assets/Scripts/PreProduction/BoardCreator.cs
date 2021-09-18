using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoardCreator : MonoBehaviour
{
    [SerializeField] private GameObject tileViewPrefab;
    [SerializeField] private GameObject tileSelectionIndicatorPrefab;
    [SerializeField] private int width = 10;
    [SerializeField] private int depth = 10;
    [SerializeField] private int height = 8;
    [SerializeField] private Point pos;
    [SerializeField] private LevelData levelData;

    private Dictionary<Point, Tile> tiles = new Dictionary<Point, Tile>();

    private Transform marker
    {
        get
        {
            if (marker == null)
            {
                GameObject intance = Instantiate(tileSelectionIndicatorPrefab) as GameObject;
                marker = intance.transform;
            }
            return marker;
        }
    }

    public void GrowArea()
    {
        Rect r = RandomRect();
        GrowArea(r);
    }

    public void ShrinkArea()
    {
        Rect r = RandomRect();
        ShrinkArea(r);
    }
    
    
    Rect RandomRect()
    {
        int x = UnityEngine.Random.Range(0, width);
        int y = UnityEngine.Random.Range(0, depth);
        int w = UnityEngine.Random.Range(1, width - x + 1);
        int h = UnityEngine.Random.Range(1, depth - y + 1);
        return new Rect(x, y, w, h);
    }

    void GrowRect(Rect rect)
    {
        for (int y = (int)rect.yMin; y < (int)rect.yMax; ++y)
        {
            for (int x = (int)rect.xMin; x < (int)rect.xMax; ++x)
            {
                Point p = new Point(x, y);
                GrowSingle(p);
            }
        }
    }

    void ShrinkRect(Rect rect)
    {
        for (int y = (int)rect.yMin; y < (int)rect.yMax; ++y)
        {
            for (int x = (int)rect.xMin; x < (int)rect.xMax; ++x)
            {
                Point p = new Point(x, y);
                ShrinkSingle(p);
            }
        }
    }

    Tile Create()
    {
        GameObject instance = Instantiate(tileViewPrefab) as GameObject;
        instance.transform.parent = transform;
        return instance.GetComponent<Tile>();
    }

    Tile GetOrCreate(Point p)
    {
        if (tiles.ContainsKey(p))
        {
            return tiles[p];
        }

        Tile t = Create();
        t.Load(p, 0);
        tiles.Add(p, t);

        return t;
    }

    void GrowSingle(Point p)
    {
        Tile t = GetOrCreate(p);
        if (t.height < height)
        {
            t.Grow();
        }
    }

    void ShrinkSingle(Point p)
    {
        if (!tiles.ContainsKey(p))
        {
            return;
        }

        Tile t = tiles[p];
        t.Shrink();

        if (t.height <=0)
        {
            tiles.Remove(p);
            DestroyImmediate(t.gameObject);
        }
    }

    public void Grow()
    {
        GrowSingle(pos);
    }

    public void Shrink()
    {
        ShrinkSingle(pos);
    }

    public void UpdateMarker()
    {
        Tile t = tiles.ContainsKey(pos) ? tiles[pos] : null;
        marker.localPosition = t != null ? t.center : new Vector3(pos.x, 0, pos.y);
    }

}


