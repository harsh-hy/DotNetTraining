using FirstExamlple;
namespace BuisnessLogic
{
    public class BL
    {
        DAL dal = new DAL();
        public string GetData()
        {
            string str = dal.DalFunc()+" Harsh";
            return str;
        }
    }
}
