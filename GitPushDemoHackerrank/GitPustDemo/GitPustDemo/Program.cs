using System;
using System.Collections.Generic;

namespace GitPustDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //this is hackerrank challenge as //http,,,,sdlbkjrhg
            /*
            both of these versions work. The second version is MUCH slower!
            */
            List<int> grades = new List<int>();
            List<int> res = new List<int>();// used for both versions        
            foreach (int x in grades)
            {
                if (x % 5 > 2 && (x >= 38))
                    res.Add(x + (5 - x % 5));
                else
                    res.Add(x);
            }
            //return res;


            // for(int x=0; x<grades.Count; x++)
            // {
            //     if(grades[x]>97){
            //         res.Add(100);
            //     }
            //     else if(grades[x]>92 && grades[x]<95){
            //         res.Add(95);
            //     }
            //     else if(grades[x]>87 && grades[x]<90){
            //         res.Add(90);
            //     }
            //     else if(grades[x]>82 && grades[x]<85){
            //         res.Add(85);
            //     }
            //     else if(grades[x]>77 && grades[x]<80){
            //         res.Add(80);
            //     }
            //     else if(grades[x]>72 && grades[x]<75){
            //         res.Add(75);
            //     }
            //     else if(grades[x]>67 && grades[x]<70){
            //         res.Add(70);
            //     }
            //     else if(grades[x]>62 && grades[x]<65){
            //         res.Add(65);
            //     }
            //     else if(grades[x]>57 && grades[x]<60){
            //         res.Add(60);
            //     }
            //     else if(grades[x]>52 && grades[x]<55){
            //         res.Add(55);
            //     }
            //     else if(grades[x]>47 && grades[x]<50){
            //         res.Add(50);
            //     }
            //     else if(grades[x]>42 && grades[x]<45){
            //         res.Add(45);
            //     }
            //     else if(grades[x]>37 && grades[x]<40){
            //         res.Add(40);
            //     }
            //     else{
            //         res.Add(grades[x]);
            //     }
            // }
            //return res;
        }
    }
}
