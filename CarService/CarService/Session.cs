using CarService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService
{
    public class Session
    {
        private Session()
        {
            context = new CarServiceContext();
        }

        private static Session? instance;
        public static Session Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Session();
                }
                return instance;
            }
        }

        private CarServiceContext context;
        public CarServiceContext Context => context;
    }
}
