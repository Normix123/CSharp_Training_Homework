using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task_2
{
    public class Algorithm
    {
        public IEnumerable<Entity> Data { get; }

        public Algorithm(string pathFile)
        {
            if (!TextRepository.IsFileExistOrNotEmpty(pathFile)) throw new FileNotFoundException(nameof(pathFile));
            Data = TextRepository.LoadEntities(pathFile).Result;
        }

        public string GetLikelyNameOfEntity((double, double) locationTuple, int k) // Try to guess name of class using k-number closest points
        {
            // Get list {Name, Count}, where Name is uniq name of a class, Count is count of uniq class name 

            var list = (from e in GetClosestEntities(locationTuple, k).AsParallel()
                group e by e.Name
                into key
                select new { Name = key.Key, Count = key.Count()}).ToList();

            if (k % 2 == 0 && list.First().Count == k / 2)
                throw new Exception(
                    $"Collision has occurred, {nameof(locationTuple)} cannot be assigned to any of classes.");

            return list.First().Count > list.Last().Count ? list.First().Name : list.Last().Name;
        }

        public IEnumerable<Entity> GetClosestEntities((double, double) locationTuple, int k)  // Get collection of k-number Entity, which are closest to the selected point
        {
            return (from e in from entity in Data.AsParallel()
                    select new {Ent = entity, Distance = DistanceBetween(locationTuple, entity.Position)}
                orderby e.Distance
                select e.Ent).Take(k);
        }

        private double DistanceBetween((double, double) a, (double, double) b)  // Distance between 2 points
        {
            return Math.Sqrt(Math.Pow(a.Item1 - b.Item1, 2) + Math.Pow(b.Item1 - b.Item1, 2));
        }
    }
}