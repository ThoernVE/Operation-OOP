using OperationOOP.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationOOP.Core.Services
{
    public interface ISortingService
    {

    }
    public class SortingService : ISortingService
    {
        public SortingService() { }

        public List<T> SortByClass<T>(List<T> list) where T : class
        {   
            return list.OrderBy(x => x.GetType().Name).ToList();
        }

        public List<Flower> SortById(List<Flower> list)
        {
            return list.OrderBy(x => x.Id).ToList();
        }

        public List<Flower> SortByAge(List<Flower> list)
        {
            return list.OrderBy(x => x.AgeYears).ToList();
        }

        public List<Flower> SortByCarelevel(List<Flower> list)
        {
            return list.OrderBy(x => x.CareLevel).ToList();
        }

        
    }
}
