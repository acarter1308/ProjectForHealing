using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectForHealing.Models
{
    public class ResourceData
    {
        static private List<Resource> resources = new List<Resource>();
       
        
        //Get All
           public static List<Resource> GetAll()
          {
            return resources;
          }
     
        //Add

        public static void Add(Resource newResource)
        {
            resources.Add(newResource);
        }
        //Remove
        public static void Remove(int id)
        {
            Resource removeResources = GetById(id);
            resources.Remove(removeResources);
        }

        //GetByID
        public static Resource GetById(int id)
        {
           return resources.Single(x => x.ResourceID == id);
        }
    }
}
