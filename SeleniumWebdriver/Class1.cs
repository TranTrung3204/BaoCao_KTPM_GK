using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using NUnit.Framework;

namespace Selenium_Webdriver
{
    public class Selenium_Webdriver
    {

        IWebDriver driver_51_Dat;

        private void SetUpChrome_51_Dat()
        {
            var chromeOptions_51_Dat = new ChromeOptions();
            chromeOptions_51_Dat.AddUserProfilePreference("download.default_directory", @"C:\\FileDownloader\\");
            chromeOptions_51_Dat.AddUserProfilePreference("donwload.directory_upgrade:", true);
            chromeOptions_51_Dat.AddUserProfilePreference("download.prompt_for_download", false);
            chromeOptions_51_Dat.AddUserProfilePreference("profile.default_content_settings.popups", 0);
            chromeOptions_51_Dat.AddUserProfilePreference("safebrowsing.enabled", false);

            driver_51_Dat = new ChromeDriver(chromeOptions_51_Dat);
        }

        private void SetUpFireFox_51_Dat()
        {
            FirefoxDriverService service_51_Dat = FirefoxDriverService.CreateDefaultService(@"C:\Users\ASUS\Downloads\HocKy2-Nam3", "geckodriver.exe");
            service_51_Dat.FirefoxBinaryPath = @"C:\\Program Files\\Mozilla Firefox\\firefox.exe";

            var options_51_Dat = new FirefoxOptions();
            options_51_Dat.SetPreference("browser.download.folderList", 2);
            options_51_Dat.SetPreference("browser.download.dir", @"C:\\FileDownloader\\");

            driver_51_Dat = new FirefoxDriver(service_51_Dat, options_51_Dat);
        }

        [TestCase("chrome")]
        [TestCase("firefox")]
        public void UpnDownFile_51_Dat(string browser_51_Dat)
        {
            if (browser_51_Dat == "chrome")
            {
                SetUpChrome_51_Dat();
            }
            if (browser_51_Dat == "firefox")
            {
                SetUpFireFox_51_Dat();
            }

            driver_51_Dat.Navigate().GoToUrl("https://smallpdf.com/vi/pdf-converter");

            string uploadFile_51_Dat = @"C:\\Users\\ASUS\\Downloads\\HocKy2-Nam3\\Selenium\\ABC.pdf";

            IWebElement fileInput_51_Dat = driver_51_Dat.FindElement(By.CssSelector("input[type=file]"));
            fileInput_51_Dat.SendKeys(uploadFile_51_Dat);
            Thread.Sleep(20000);


            driver_51_Dat.FindElement(By.XPath("//*[@id=\"app\"]/div/div/div[3]/div[2]/div[2]/div/div/div[2]/div/div[2]/div/div[1]")).Click();
            driver_51_Dat.FindElement(By.XPath("//*[@id=\"app\"]/div/div/div[3]/div[2]/div[2]/div/div/div[2]/div/div[2]/button[2]/div")).Click();
            Thread.Sleep(10000);
            driver_51_Dat.FindElement(By.XPath("//*[@id=\"app\"]/div/div/div[3]/div[2]/div[2]/div/div/div[2]/div/div[2]/div[2]/div[1]/div/a/div")).Click();

            driver_51_Dat.Quit();
        }

    }
}
