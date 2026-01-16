using System;
namespace Construction
{
    class EstimateDetails
    {
        public float ConstructionArea{get; set;}
        public float SiteArea{get; set;}
    }
    public class ConstructionEstimateException:Exception
    {
        public ConstructionEstimateException(string message):base(message){ }
    }
    class Program
    {
        public static EstimateDetails ValidateConstructionEstimate(float constructionArea, float siteArea)
        {
            if(constructionArea>siteArea)
            {
                throw new ConstructionEstimateException("Sorry your Construction area is not approved");
            }
            EstimateDetails ED = new EstimateDetails();
            ED.ConstructionArea=constructionArea;
            ED.SiteArea=siteArea;
            return ED;
        }
        public static void Main()
        {
            EstimateDetails est=new EstimateDetails();
            Console.WriteLine("Enter the Construction Area");
            est.ConstructionArea=Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Enter the Site Area");
            est.SiteArea=Convert.ToSingle(Console.ReadLine());
            try
            {
                ValidateConstructionEstimate(est.ConstructionArea,est.SiteArea);
                Console.WriteLine("Your Construction area is Approved");
            }
            catch(ConstructionEstimateException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}