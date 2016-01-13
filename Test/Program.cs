using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tzq.WeChatService.Buiness;
using Tzq.WeChatService.Model;

namespace Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateMenuTest("gh_e268fa85d8f3");
        }

        public static void CreateMenuTest(string weixinID)
        {
            MenuInfo firstButon1 = new MenuInfo();
            firstButon1.type = MenuType.click.ToString();
            firstButon1.name = "下一个笑话";
            firstButon1.key = "V1001_HOT";
            List<MenuInfo> button = new List<MenuInfo>();
            button.Add(firstButon1);
            string menuInfostr = JsonConvert.SerializeObject(new
            {
                button = button

            });

            CreateMenuRequest request = new CreateMenuRequest(menuInfostr, ApiAccessTokenManager.Instance.GetTokenByWeixinID(weixinID));
            ApiClient client = new ApiClient();
            var response = client.Execute(request);
            if (!response.IsError)
            {
                Console.WriteLine(response.ToString());
            }
            else
            {
                Console.WriteLine(response.ErrorCode + ", " + response.ErrorMessage);
            }
        }

    }
}
