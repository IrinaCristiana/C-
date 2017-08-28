using CEL.ro_Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace CEL.ro_Testing
{
    [TestFixture]
    public class UnitTest1
    {
        private IWebDriver driver;
        HomePage homePage;
        SelectedCategoryPage selectedCategoryPage;

        

       [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            homePage = new HomePage(driver);
            selectedCategoryPage = new SelectedCategoryPage(driver);
            driver.Navigate().GoToUrl("http://www.cel.ro/");
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
            driver.Manage().Window.Maximize();
            homePage.CloseNotification();
        }

         [TearDown]
          public void CloseBrowser()
          {
              driver.Quit();
          }

        //- Verify that title contains "CEL"
        [Test]
        public void Test() {
         //   NUnit.Framework.StringAssert.Contains("CEL", driver.Title);
          NUnit.Framework.StringAssert.Contains("CEL", homePage.getTitle());
            homePage.CloseNotification();
        }

        //Verify that logo is displayed
        [Test]
        public void LogoDisplayedTest()
        {
            NUnit.Framework.Assert.IsTrue(homePage.LogoDisplayed());
        }

        //If notification is visible click on it to disappear
        [Test]
        public void CloseNotificationTest()
        {
            homePage.CloseNotification();
        }

        
        [Test]
        public void ClickOnSelectedItemsTest()
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));

            //Click on the 8th input from the left menu and then on the third element from that menu
            homePage.ClickOnSelectedLeftMenuItem(7);
            homePage.ClickOnSelectedSubmenuItem(2);

            //Verify that title contains "Antivirus"
            NUnit.Framework.StringAssert.Contains("Antivirus", selectedCategoryPage.getSelectedCategoryName());

            //- Verify that the path to that product exists	
            NUnit.Framework.StringAssert.IsMatch("CEL.ro :: Software :: Antivirus", selectedCategoryPage.GetPath());

            //Click on the first product which contains in description: " Kaspersky Anti-Virus 2017 1PC 1An+3luni gratuite "
            selectedCategoryPage.ClickOnProduct();
            SelectedItemPage selectedItemPage = new SelectedItemPage(driver);

            // driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
            Thread.Sleep(6000);
           // selectedItemPage.CloseNotification();       

            //Verify that the title contains the description from above
            NUnit.Framework.StringAssert.Contains("Kaspersky Anti-Virus 2017 1PC 1An+3luni gratuite", selectedItemPage.getSelectedProductTitle());

            //Add the product to the cart
            selectedItemPage.AddToCart();
            Thread.Sleep(4000);
            selectedItemPage.SeeCartDetails();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
            //Verify that the title contains " Continut cos “
            CartPage cartPage = new CartPage(driver);
            NUnit.Framework.StringAssert.Contains("Continut cos", cartPage.GetCartTitle());

            cartPage.ModifyQuantity("3");
            Thread.Sleep(4000);
           
           // NUnit.Framework.Assert.AreEqual("3", cartPage.GetQuantity());

            //Verify that the total price corresponds to the amount changes
            NUnit.Framework.Assert.AreEqual("294", cartPage.GetTotalPrice());
        }

    }
}
