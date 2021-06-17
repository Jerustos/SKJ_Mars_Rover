using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKJ_Mars_Rover
{
    class Rover_Methods: Variables
    {
       // Handler
        private static void _handler(String msg)
        {           
            try
            {
                if (msg != null)
                {
                    if (debugTrue)
                    {
                        Console.WriteLine(msg);
                    }
                }             
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong.");
            }
        }

        // Set Directions
        private static String set_Directions()
        {
            dir1 = x_Cordinate + " " + y_Cordinate + " " + direction;
            Console.WriteLine(dir1);
            return dir1;
        }
      

       // Allowed Move
        private static void allowed_Move()
        {
            if (direction != null)
            {
                if (direction == "N")
                {
                    _handler("allowed_Move().1 --> (direction == north)");
                    y_Cordinate = y_Cordinate + 1;
                }
                else if (direction == "E")
                {
                    _handler("allowed_Move().2 --> (direction == east)");
                    x_Cordinate = x_Cordinate + 1;
                }
                else if (direction == "S")
                {
                    _handler("allowed_Move().3 --> (direction == south)");
                    y_Cordinate = y_Cordinate - 1;
                }
                else if (direction == "W")
                {
                    _handler("allowed_Move().4 --> (direction == west)");
                    x_Cordinate = x_Cordinate - 1;
                }
               
            }
        }

        // Rotate
        private static void Rotate(String dir2)
        {
            direction = ((allowed_Directions.IndexOf(dir2) > -1) || (allowed_Commands.IndexOf(dir2) > -1)) ? dir2 : direction;
            _handler("Rotate().1 --> dir=" + dir2 + ", direction=" + direction);
        }
       

        // Execute command
        private static void execute_Command(String com)
        {
            _handler("execute_Command().1 --> com=" + com);
            if (com != null)
            {
                if (com == "L")
                {
                    _handler("execute_Command().2 --> (com == left)");
                    if (direction == "W")
                    {
                        _handler("execute_Command().3 --> Rotate(west)");
                        Rotate(west);
                    }
                    else if (direction == "S")
                    {
                        _handler("execute_Command().4 --> Rotate(south)");
                        Rotate(south);
                    }
                    else if (direction == "E")
                    {
                        _handler("execute_Command().5 --> Rotate(east)");
                        Rotate(east);
                    }
                    else if (direction == "N")
                    {
                        _handler("execute_Command().6 --> Rotate(north)");
                        Rotate(north);
                    }
                }
                else if (com == "R")
                {
                    _handler("execute_Command().7 --> (com == right)");
                    if (direction == "W")
                    {
                        _handler("execute_Command().8 --> Rotate(west)");
                        Rotate(west);
                    }
                    else if (direction == "S")
                    {
                        _handler("execute_Command().9 --> Rotate(south)");
                        Rotate(south);
                    }
                    else if (direction == "E")
                    {
                        _handler("execute_Command().10 --> Rotate(east)");
                        Rotate(east);
                    }
                    else if (direction == "N")
                    {
                        _handler("execute_Command().11 --> Rotate(north)");
                        Rotate(north);
                    }
                }
                else if (com == "M")
                {
                    _handler("execute_Command().12 --> (com == move)");
                    allowed_Move();
                }
            }
        }
        

        // Catch Int Exception
        private static bool CatchIntException(string theValue)
        {
            try
            {
                Convert.ToInt32(theValue);
                return true;
            }
            catch
            {
                return false;
            }
        }
       

        // Rover Command
        private static String rover_Command(String com)
        {          
            String[] roverList = com.Split(' ');
            for (int i = 0; i < roverList.Length; i++)
            {
                rover = roverList[i];
                _handler("rover_Command().1 rover=" + rover);
                if (rover.Length > 1)
                {
                    for (var z = 0; z < rover.Length; z++)
                    {
                        Commando = rover.Substring(z, 1);
                        _handler("rover_Command().2 Commando=" + Commando);
                        execute_Command(Commando);
                    }
                }
                else
                {
                    bee = CatchIntException(rover);
                    _handler("rover_Command().3 --> bee=" + bee);
                    if (bee)
                    {
                        rover_items.Push(rover);
                        _handler("rover_Command().4 items.Count=" + rover_items.Count);
                        if (rover_items.Count == 2)
                        {
                            y_Cordinate = Convert.ToInt32(rover_items.Pop());
                            x_Cordinate = Convert.ToInt32(rover_items.Pop());
                        }
                    }
                    else if (allowed_Directions.IndexOf(rover) > -1)
                    {
                        direction = rover;
                        _handler("rover_Command().5 direction=" + direction);
                    }
                    else if (allowed_Commands.IndexOf(rover) > -1)
                    {
                        _handler("rover_Command().6 execute_Command(" + rover + ")");
                        execute_Command(rover);
                    }
                }
            }
            return set_Directions();
        }       

        // Handler Base
        public class handler_Base
        {
            public void ShowInfo()
            {
                String cmd = "1 2 N";
                String testData = "1 2 N";
                String x = rover_Command(cmd);

                cmd = "M";
                testData = "1 3 N";
                x = rover_Command(cmd);
                if (x != testData)
                {
                    Console.WriteLine("ERROR: Command Not Allowed!");
                }

                cmd = "M";
                testData = "5 1 E";
                x = rover_Command(cmd);
                if (x != testData)
                {
                    Console.WriteLine("ERROR: Command Not Allowed!");
                }
            }
        }
        
    }
}
