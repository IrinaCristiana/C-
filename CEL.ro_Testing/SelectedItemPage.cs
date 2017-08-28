using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CEL.ro_Testing
{
    class SelectedItemPage
    {
        [FindsBy(How = How.CssSelector, Using = "head title")]
        private IWebElement title { set; get; }

        [FindsBy(How = How.CssSelector, Using = ".titlebar div.close>a[onclick='hide_retinute();clear_lastaction();']")]
        private IWebElement closeNotification { set; get; }

        [FindsBy(How = How.Id, Using = "mesaj_custom")]
        private IWebElement popUp { set; get; }

        [FindsBy(How = How.XPath, Using = ".//div[@id='bodycode']/div[3]/div[1]/div[@class='row']/div[4]/div[@class='buttons']/form/button")]
        private IWebElement addToCartButton { set; get; }

        [FindsBy(How = How.Id, Using = "btngocart")]
        private IWebElement seeCartDetailsButton { set; get; }

        private IWebDriver driver;

        public SelectedItemPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void CloseNotification()
        {
            if (popUp.Displayed)
            {
                closeNotification.Click();
            }
        } 

        public String getSelectedProductTitle()
        {
            String selectedProductTitle = driver.Title;
            return selectedProductTitle;
        }

        public void AddToCart()
        {
            addToCartButton.Click();
           
        }

        public void SeeCartDetails()
        {
            seeCartDetailsButton.Click();
        }
    }
}
