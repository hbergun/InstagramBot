using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Threading;

namespace InstagramFollowers
{
    class Program
    {
        static void Main(string[] args)
        {
            //Thread Sleep Time
            int time = 3000; //ms

            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"D:\Selenium"); //GeckoDriver
            service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe"; //FireFox Path

            IWebDriver driver = new FirefoxDriver(service);
            string url = @"https://www.instagram.com/accounts/login/?source=auth_switcher";
            driver.Navigate().GoToUrl(url);
            Thread.Sleep(time);
            //Login
            driver.FindElement(By.Name("username")).SendKeys("Myusername"); //Your İnstagram UserName Or Email Or Phone Number
            driver.FindElement(By.Name("password")).SendKeys("MyPassword"); //Your İnstagram Password
            driver.FindElement(By.CssSelector("div.Igw0E:nth-child(4)")).Click();
            //Login End

            //Go To Profile Page
            driver.Navigate().GoToUrl(@"https://www.instagram.com/ergunbh/"); //UserName
            //Profile Page Show

            //Show Followers Page
            driver.Navigate().GoToUrl(@"https://www.instagram.com/ergunbh/followers/");
            //Followers Page Opened

            //Get Followers And Following User Count
            var followersCount = driver.FindElement(By.CssSelector("li.Y8-fY:nth-child(2) > a:nth-child(1) > span:nth-child(1)")).Text;
            var followingCount = driver.FindElement(By.CssSelector("li.Y8-fY:nth-child(3) > a:nth-child(1) > span:nth-child(1)")).Text;

            //Get Names And Usernames For All User
            List<string> Followers = new List<string>();
            List<string> Following = new List<string>();
            for (int i = 0; i < int.Parse(followersCount); i++)
            {
                Followers.Add(driver.FindElement(By.XPath("/html/body/div[3]/div/div[2]/ul/div/li[i]/div/div[1]/div[2]/div[1]/a")).Text);
                Console.WriteLine(Followers[i]);
            }
            for (int i = 0; i < int.Parse(followingCount); i++)
            {
                Following.Add(driver.FindElement(By.XPath("/html/body/div[3]/div/div[2]/ul/div/li[i]/div/div[2]/div[1]/div/div/a")).Text);
                Console.WriteLine(Following[i]);
            }
            Console.Read();
        }
    }
}
