using System;

namespace Model{

    public class LogManager{
        public static Logger GetCurrentClassLogger(){
            return new Logger();
        }

    }

    public class Logger{

        public void Error(string tsErrorMessage){

        }
        public void Error(Exception toEx){
            
        }
    }
}