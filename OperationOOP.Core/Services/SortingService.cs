using OperationOOP.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationOOP.Core.Services
{
    public interface ISortingService //interface to be able to abstract sortingservice
    {
        List<T> SortByClass<T>(List<T> list) where T : class; 
        List<Flower> SortById(List<Flower> list);
        List<Flower> SortByAge(List<Flower> list);
        List<Flower> SortByCarelevel(List<Flower> list);
    }
    public class SortingService : ISortingService
    {
        public SortingService() { } //constructor for sortingservice

        public List<T> SortByClass<T>(List<T> list) where T : class //method for sorting by class, using generics to increase reusability by polymorphism. Need to use GetType.().Name to get the name of the class and be able to sort by that.
        {   
            return list.OrderBy(x => x.GetType().Name).ToList();
        }

        public List<Flower> SortById(List<Flower> list) // method to sort by id
        {
            return list.OrderBy(x => x.Id).ToList();
        }

        public List<Flower> SortByAge(List<Flower> list) //method to sort by age
        {
            return list.OrderBy(x => x.AgeYears).ToList();
        }

        public List<Flower> SortByCarelevel(List<Flower> list) //method to sort by carelevel. Works in sorting since Enum can translate to number.
        {
            return list.OrderBy(x => x.CareLevel).ToList();
        }

        
    }
}
