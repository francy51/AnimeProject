using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.ItemSystem
{
    public class QualityList
    {

        [SerializeField]
        public List<Quality> qualityList;

        public void Add(Quality Quality)
        {
            qualityList.Add(Quality);
        }

        public QualityList()
        {
            qualityList = new List<Quality>();
        }

        public void Remove(Quality weapon)
        {
            qualityList.Remove(weapon);
        }

        public void Remove(int index)
        {
            qualityList.RemoveAt(index);
        }

        public void Insert(Quality quality, int index)
        {
            qualityList.Insert(index, quality);
        }

        public void Replace(Quality quality, int index)
        {
            qualityList[index] = quality;
        }

        public int Length()
        {
            return qualityList.Count;
        }
    }
}