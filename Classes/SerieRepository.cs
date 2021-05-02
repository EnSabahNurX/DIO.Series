// using System;
// using System.Collections.Generic;
// using DIO.Series.Interfaces;

// namespace DIO.Series
// {
//     public class SerieRepositorio : IRepository<Serie>
//     {
//         private List<Serie> serieList = new List<Serie>();
//         public void Update(int id, Serie object)
//         {
//             serieList[id] = object;
//         }

//         public void Delete(int id)
//         {
//             serieList[id].Delete();
//         }

//         public void Add(Serie objeto)
//         {
//             serieList.Add(objeto);
//         }

//         public List<Serie> List()
//         {
//             return serieList;
//         }

//         public int NextId()
//         {
//             return serieList.Count;
//         }

//         public Serie ReturnById(int id)
//         {
//             return serieList[id];
//         }
//     }
// }

using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
    public class SerieRepository : IRepository<Serie>
    {
        private List<Serie> serieList = new List<Serie>();
        public void Update(int id, Serie obj)
        {
            serieList[id] = obj;
        }

        public void Delete(int id)
        {
            serieList[id].Exclude();
        }

        public void Add(Serie obj)
        {
            serieList.Add(obj);
        }

        public List<Serie> List()
        {
            return serieList;
        }

        public int NextId()
        {
            return serieList.Count;
        }

        public Serie ReturnById(int id)
        {
            return serieList[id];
        }
    }
}