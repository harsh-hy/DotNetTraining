using System;
using System.Collections.Generics;
namespace YogaMeditation
{
    class MeditationCenter
    {
        public int MemberId {get; set;}
        public int Age {get; set;}
        public double Weight {get; set;}
        public double Height {get; set;}
        public string? Goal {get; set;}
        public double BMI {get; set;}
    }
    class Program
    {
        public static ArrayList memberlist =  new ArrayList();
        public void AddYogaMember(int memberId,int age,double weight,double height,string goal,double bmi)
        {
            memberlist.Add(new MeditationCenter{MemberId=memberId,Age=age,Weight=weight,Height=height,Goal=goal,BMI=bmi});
        }
        public double CalculateBMI(int memberId)
        {
            foreach(MeditationCenter member in memberlist)
            {
                if(member.MemberId == memberId)
                {
                    double bmi = m.Weight / (m.Height * m.Height);
                    bmi = Math.Floor(bmi * 100) / 100;
                    m.BMI = bmi;
                    return bmi;
                }
            }
            return 0;
        }
        
    }
}