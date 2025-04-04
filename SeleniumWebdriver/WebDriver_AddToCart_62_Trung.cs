using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace SeleniumSauceDemoTest
{
    [TestFixture]
    public class WebDriver_AddToCart_62_Trung
    {
        private IWebDriver driver_62_Trung;

        [SetUp]
        public void Setup()
        {
            ChromeOptions options_62_Trung = new ChromeOptions();
            options_62_Trung.AddUserProfilePreference("credentials_enable_service", false);
            options_62_Trung.AddUserProfilePreference("profile.password_manager_enabled", false);

            driver_62_Trung = new ChromeDriver(options_62_Trung);
            driver_62_Trung.Manage().Window.Maximize();
            driver_62_Trung.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [Test]
        public void Test_LoginAndAddToCart_62_Trung()
        {
            Thread.Sleep(1000);
            driver_62_Trung.FindElement(By.Id("user-name")).SendKeys("standard_user");
            Thread.Sleep(1000);
            driver_62_Trung.FindElement(By.Id("password")).SendKeys("secret_sauce");
            Thread.Sleep(1000);
            driver_62_Trung.FindElement(By.Id("login-button")).Click();
            Thread.Sleep(2000);


            driver_62_Trung.FindElement(By.CssSelector("button[name='add-to-cart-sauce-labs-backpack']")).Click();
            Thread.Sleep(2000);

            driver_62_Trung.FindElement(By.ClassName("shopping_cart_link")).Click();
            Thread.Sleep(3000);

            IWebElement cartItem_62_Trung = driver_62_Trung.FindElement(By.ClassName("inventory_item_name"));
            Assert.That(cartItem_62_Trung.Text, Is.EqualTo("Sauce Labs Backpack"), "Sản phẩm chưa được thêm vào giỏ hàng!");
        }

        [Test]
        public void Test_InvalidLogin_62_Trung()
        {
            Thread.Sleep(1000);
            driver_62_Trung.FindElement(By.Id("user-name")).SendKeys("invalid_user");
            Thread.Sleep(1000);
            driver_62_Trung.FindElement(By.Id("password")).SendKeys("wrong_password");
            Thread.Sleep(1000);
            driver_62_Trung.FindElement(By.Id("login-button")).Click();
            Thread.Sleep(3000);

            IWebElement errorMessage = driver_62_Trung.FindElement(By.ClassName("error-message-container"));
            Assert.That(errorMessage.Displayed, Is.True, "Thông báo lỗi không hiển thị khi đăng nhập sai!");
        }

        [TearDown]
        public void TearDown()
        {
            driver_62_Trung.Quit();
        }
    }
}