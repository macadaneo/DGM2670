using System;
using System.Collections;
using UnityEngine;

[System.Serializable]
public struct Point : IEquatable<Point>
{
    //The folder: Model, in which this script is located in refers to an architectural patter called Model View Controller or "MVC"

    #region Fields
    public int x;
    public int y;
    #endregion

    #region Constructors
    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    #endregion

    #region Operator Overloads
    public static Point operator +(Point a, Point b)
    {
        return new Point(a.x + b.x, a.y + b.y);
    }

    public static Point operator -(Point p1, Point p2)
    {
        return new Point(p1.x - p2.x, p1.y - p2.y);
    }

    public static bool operator ==(Point a, Point b)
    {
        return a.x == b.x && a.y == b.y;
    }

    public static bool operator !=(Point a, Point b)
    {
        return !(a == b);
    }

    public static implicit operator Vector2(Point p)
    {
        return new Vector2(p.x, p.y);
    }
    #endregion
    
    #region Object Overloads
    public override bool Equals(object obj)
    {
        if (obj is Point)
        {
            Point p = (Point)obj;
            return x == p.x && y == p.y;
        }
        return false;
    }

    public bool Equals(Point p)
    {
        return x == p.x & y == p.y;
    }

    public override int GetHashCode()
    {
        return x ^ y;
    }

    public override string ToString()
    {
        return string.Format("({0}, {1})", x, y);
    }
    #endregion
}

// This script comes from a tutorial by Jonathan Parham
// His tutorial can be found here: http://theliquidfire.com/2015/05/18/tactics-rpg-board-generator/
// Further Modification was made by referencing the updated scrips on Jonathan's Repo
// His Repo can be found here: https://bitbucket.org/jparham/blogtacticsrpg/src/master/
// Any additional modification was made most likely at the behest of Rider.