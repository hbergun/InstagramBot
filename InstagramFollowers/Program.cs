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
            driver.FindElement(By.Name("username")).SendKeys("instagram@instagram.com"); //Commit Etmeden Önce Mutlaka Sil
            driver.FindElement(By.Id("password")).SendKeys("mypassword"); //Committen Önce Sil
            driver.FindElement(By.XPath("//*[@id='react-root']/section/main/div/article/div/div[1]/div/form/div[6]")).Click();
            //Login End
        }
    }
}
