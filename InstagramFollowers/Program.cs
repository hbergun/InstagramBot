using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Threading;

namespace InstagramFollowers
{
    public class Program
    {
        public static void Scroll_Event(IWebDriver driver)
        {
            //Scroll
            IWebElement myelement = driver.FindElement(By.CssSelector(".isgrP"));
            Actions action = new Actions(driver);
            action.MoveToElement(myelement)
                    .Click()
                    .KeyDown(Keys.LeftControl)
                    .SendKeys(Keys.ArrowDown)
                    .Build()
                    .Perform();
            //Scroll
        }

        public static List<string> EnToList(IEnumerator<IWebElement> enumerator)
        {
            var list = new List<string>();
            while (enumerator.MoveNext())
            {
                list.Add(enumerator.Current.Text);
                Console.WriteLine(enumerator.Current.Text);
            }
            return list;
        }

        static void Main(string[] args)
        {
            //Thread Sleep Time
            int time = 3000; //ms

            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"D:\Selenium"); //GeckoDriver
            service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe"; //FireFox Path

            IWebDriver driver = new FirefoxDriver(service);
            string url = @"https://www.instagram.com/accounts/login/?source=auth_switcher";
            driver.Navigate().GoToUrl(url);

            //Login
            driver.FindElement(By.Name("username")).SendKeys("YourUsername"); //Your İnstagram UserName Or Email Or Phone Number
            driver.FindElement(By.Name("password")).SendKeys("YourPassword"); //Your İnstagram Password
            driver.FindElement(By.CssSelector("div.Igw0E:nth-child(4)")).Click(); //Login Button Click
            Thread.Sleep(time);
            //Login End

            //Go To Profile Page
            driver.Navigate().GoToUrl(@"https://www.instagram.com/ergunbh/"); //Username
                                                                              //Profile Page Show

            //Get Followers And Following User Count
            //Thread.Sleep(time);
            var followersCount = driver.FindElement(By.CssSelector("li.Y8-fY:nth-child(2) > a:nth-child(1) > span:nth-child(1)")).Text;
            var followingCount = driver.FindElement(By.CssSelector("li.Y8-fY:nth-child(3) > a:nth-child(1) > span:nth-child(1)")).Text;

            //Get Followers And Following List For Current User
            IEnumerator<IWebElement> Followers = null;
            IEnumerator<IWebElement> Following = null;

            driver.FindElement(By.CssSelector("li.Y8-fY:nth-child(2) > a:nth-child(1)")).Click(); //Click Followers Button

            for (int i = 1; i <= 2; i++)
            {
                Scroll_Event(driver);
            }
            Followers = driver.FindElements(By.ClassName("wo9IH")).GetEnumerator();

            var FollowersList = EnToList(Followers);
            driver.FindElement(By.CssSelector(".glyphsSpriteX__outline__24__grey_9")).Click(); //Close Followers Page
            driver.FindElement(By.CssSelector("li.Y8-fY:nth-child(3) > a:nth-child(1)")).Click(); //Click Following Button ==> Open Following Page

            for (int i = 1; i <= 15; i++)
            {
                Scroll_Event(driver);
            }
            Following = driver.FindElements(By.ClassName("wo9IH")).GetEnumerator();
            var FollowingList = EnToList(Following);
            //Created Lists
            Console.Read();
        }
    }
}
