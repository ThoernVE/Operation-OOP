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

        public List<Flower> SortByClass(List<Flower> list)
        {
            
            return list.OrderBy(x => x.GetType()).ToList();
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
