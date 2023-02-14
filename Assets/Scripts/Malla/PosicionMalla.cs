
// Crea una copia de la posicion de la malla respecto al mundo
using System;

public struct PosicionMalla : IEquatable<PosicionMalla>
{
    public int x;
    public int z;

    public PosicionMalla(int x,int z)
    {
        this.x = x;
        this.z = z;
    }

    public override bool Equals(object obj)
    {
        return obj is PosicionMalla malla &&
               x == malla.x &&
               z == malla.z;
    }

    public bool Equals(PosicionMalla other)
    {
        return this == other;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(x, z);
    }

    public override string ToString()
    {
        return "x: " + x + "x: " + z;
    }

    public static bool operator ==(PosicionMalla a, PosicionMalla b)
    {
        return a.x == b.x && a.z == b.z;
    }

    public static bool operator !=(PosicionMalla a, PosicionMalla b)
    {
        return !(a==b);
    }

    public static PosicionMalla operator +(PosicionMalla a, PosicionMalla b)
    {
        return new PosicionMalla(a.x + b.x, a.z + b.z);
    }
    public static PosicionMalla operator -(PosicionMalla a, PosicionMalla b)
    {
        return new PosicionMalla(a.x - b.x, a.z - b.z);
    }
}
