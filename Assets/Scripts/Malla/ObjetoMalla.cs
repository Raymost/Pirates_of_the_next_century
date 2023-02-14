using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoMalla
{
   private PosicionMalla posicionMalla;
   private SistemaMalla sistemaMalla;
   private List<Nave> listaNaves;

   public ObjetoMalla(SistemaMalla sistemaMalla, PosicionMalla posicionMalla) 
   {
        this.posicionMalla = posicionMalla;
        this.sistemaMalla = sistemaMalla;
        listaNaves = new List<Nave>();
   }

    public override string ToString()
    {
      string naveString = "";
      foreach (Nave nave in listaNaves)
      {
         naveString += nave + "\n";
      }
        return naveString;
    }

    public void AddNave(Nave nave)
    {
      listaNaves.Add(nave);
    }

   public void BorrarNave(Nave nave)
   {
      listaNaves.Remove(nave);
   }

    public List<Nave> GetListaNave()
    {
      return listaNaves;
    }

    public bool TieneAlgo()
    {
      return listaNaves.Count > 0;
    }

    public Nave GetNave()
    {
      if (TieneAlgo())
      {
        return listaNaves[0];
      }
      else
      {
        return null;
      }
    }
}
