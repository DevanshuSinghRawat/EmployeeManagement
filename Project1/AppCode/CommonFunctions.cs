using Microsoft.VisualBasic;

namespace Project1.AppCode
{
    public static class CommonFunctions
    {
        public static List<string> GetStatusList()
        {
            List<string> items = new List<string>();
            items.Add(Constants.Active);
            items.Add(Constants.Inactive);
            return items;
        }

        public static List<string> GetGenderList()
        {
            List<string> items = new List<string>();
            items.Add(Constants.Male);
            items.Add(Constants.Female);
            items.Add(Constants.Other);
            return items;
        }
    }
}
