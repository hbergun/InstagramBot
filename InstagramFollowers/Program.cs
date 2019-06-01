using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
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
            driver.FindElement(By.Name("username")).SendKeys("instagram@instagram.com"); //Your İnstagram UserName Or Email Or Phone Number
            driver.FindElement(By.Name("password")).SendKeys("mypassword"); //Your İnstagram Password
            driver.FindElement(By.CssSelector("div.Igw0E:nth-child(4)")).Click();
            //Login End

        }
    }
}
