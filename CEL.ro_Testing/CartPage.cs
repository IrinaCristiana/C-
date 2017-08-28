using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace CEL.ro_Testing
{
    class CartPage
    {
        [FindsBy(How = How.CssSelector, Using = "head title")]
        private IWebElement title { set; get; }

        [FindsBy(How = How.XPath, Using = ".//td[@id='produse_cos']/table/tbody/tr[2]/td[3]/input[@type='text']")]
        private IWebElement quantity { set; get; }

        [FindsBy(How = How.XPath, Using = ".//*[@class='pret_total_final']")]
        private IWebElement totalPrice { set; get; }

        private IWebDriver driver;

        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        public String GetCartTitle()
        {
            String cartTitle = driver.Title;
            return cartTitle;
        }

       public void ModifyQuantity(String qty)
        {
            quantity.Clear();
            quantity.SendKeys(qty);
            quantity.SendKeys(Keys.Enter);
        }

        public String GetQuantity()
        {
            return quantity.Text;        
        }

        public String GetTotalPrice()
        {
            return totalPrice.Text;    
        }
    }
}
