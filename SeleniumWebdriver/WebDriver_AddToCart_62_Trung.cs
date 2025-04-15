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

            // Tắt quản lý mật khẩu với nhiều cách khác nhau để đảm bảo
            options_62_Trung.AddUserProfilePreference("credentials_enable_service", false);
            options_62_Trung.AddUserProfilePreference("profile.password_manager_enabled", false);
            options_62_Trung.AddArgument("--password-store=basic");
            options_62_Trung.AddArgument("--disable-features=AutofillAssistant,PasswordManager");

            // Sử dụng chế độ ẩn danh
            options_62_Trung.AddArgument("--incognito");

            // Thêm các tùy chọn bổ sung để ngăn chặn thông báo
            options_62_Trung.AddArgument("--disable-notifications");
            options_62_Trung.AddArgument("--disable-popup-blocking");
            options_62_Trung.AddArgument("--disable-save-password-bubble");

            driver_62_Trung = new ChromeDriver(options_62_Trung);
            driver_62_Trung.Manage().Window.Maximize();
            driver_62_Trung.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [Test]
        public void Test_LoginAndAddToCart_62_Trung()
        {
            Thread.Sleep(1000);
            IWebElement usernameField = driver_62_Trung.FindElement(By.Id("user-name"));
            foreach (char c in "standard_user")
            {
                usernameField.SendKeys(c.ToString());
                Thread.Sleep(100);
            }
            Thread.Sleep(500);

            IWebElement passwordField = driver_62_Trung.FindElement(By.Id("password"));
            foreach (char c in "secret_sauce")
            {
                passwordField.SendKeys(c.ToString());
                Thread.Sleep(100);
            }
            Thread.Sleep(500);

            driver_62_Trung.FindElement(By.Id("login-button")).Click();
            Thread.Sleep(2000);

            // Xử lý thông báo "Change your password" nếu xuất hiện
            try
            {
                // Kiểm tra cả alert và thông báo thông thường
                try
                {
                    IAlert alert = driver_62_Trung.SwitchTo().Alert();
                    alert.Accept();
                    Thread.Sleep(1000);
                }
                catch (NoAlertPresentException) { }

                // Tìm button OK trên popup Google Password Manager nếu có
                var okButtons = driver_62_Trung.FindElements(By.XPath("//button[text()='OK']"));
                if (okButtons.Count > 0)
                {
                    okButtons[0].Click();
                    Thread.Sleep(1000);
                }
            }
            catch (Exception) { }
            string currentUrl = driver_62_Trung.Url;
            if (!currentUrl.Contains("inventory.html"))
            {
                // Thử click vào các vị trí khác để đóng popup nếu nó không phải là alert
                try
                {
                    driver_62_Trung.FindElement(By.TagName("body")).Click();
                    Thread.Sleep(1000);
                }
                catch (Exception) { }
            }

            driver_62_Trung.FindElement(By.CssSelector("button[name='add-to-cart-sauce-labs-backpack']")).Click();
            Thread.Sleep(3000);
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