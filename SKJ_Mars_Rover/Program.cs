using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKJ_Mars_Rover
{
    class Program: Rover_Methods
    {       
        static void Main(string[] args)
        {
            var base_info = new handler_Base();
            base_info.ShowInfo();
        }   
    }
}
