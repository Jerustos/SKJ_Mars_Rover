using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKJ_Mars_Rover
{
    class Variables
    {
        //Generic Variables
        public static String rover;
        public static String Commando;
        public static Boolean bee;
        public static String allowed_Commands = "MLR";
        public static Boolean debugTrue = false;      
        public static Stack rover_items = new Stack();

        // Movement Variables
        public static String left = "L";
        public static String right = "R";
        public static String move = "M";
        public static String direction = "";
        public static String allowed_Directions = "SNEW";
        public static String dir1;
        public static String dir2;

        // Coordinates
        public static String north = "N";
        public static String south = "S";
        public static String east = "E";
        public static String west = "W";
        public static int x_Cordinate = 0;
        public static int y_Cordinate = 0;
    }
}
