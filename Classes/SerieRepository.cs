using System;

using System.Collections.Generic;

namespace DIO.Series.Interfaces
{
    public class SerieRepository : IRepository<Serie>
    {
        private List<Serie> serieList = new List<Serie>();
        public void Update(int id, Serie object)
        {
            serieList[id] = object;
        }

        public void Delete(int id)
        {
            serieList[id].Delete();
        }

        public void Insert(Serie object)
        {
            serieList.Add(object);
        }

        public List<Serie> List()
        {
            return serieList;
        }

        public int NextId()
        {
            return serieList.Count;
        }

        public Serie GetById(int id)
        {
            return serieList[id];
        }
    }
}