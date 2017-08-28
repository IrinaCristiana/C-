using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEL.ro_Testing
{
    class SelectedCategoryPage
    { 

        [FindsBy(How = How.CssSelector, Using = "head title")]
        private IWebElement title { set; get; }

        [FindsBy(How = How.XPath, Using = ".//div[@id='bodycode']/div[2]/span/span/a/b[@itemprop='name']")]
        private IList<IWebElement> pathItemsList { get; set; }

        [FindsBy(How = How.XPath, Using = ".//div[@id='listProducts']/div[1]/div[2]/div[5]/div/div/div/h4/a/span ")]
        private IList<IWebElement> productsList { get; set;}

        [FindsBy(How = How.CssSelector, Using = ".titlebar div.close>a[onclick='hide_retinute();clear_lastaction();']")]
        private IWebElement closeNotification {set; get; }

        [FindsBy(How = How.Id, Using = "mesaj_custom")]
        private IWebElement popUp { set; get; }


        private IWebDriver driver;

        private String path = "";

        public SelectedCategoryPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public String getSelectedCategoryName()
        {
            String selectedItemName = driver.Title;
            return selectedItemName;
        }

        public String GetPath()
        {
            for(int i=0; i<pathItemsList.Count; i++)
            {
                path += pathItemsList[i].Text + " :: ";
            }
            return path;
        }

        public void ClickOnProduct()
        {
            for (int i = 0; i < productsList.Count; i++)
            {
                if(productsList[i].Text.Contains("Kaspersky Anti-Virus 2017 1PC 1An+3luni gratuite")){
                    productsList[i].Click();
                }
            }
        }

        public void CloseNotification()
        {
            if (popUp.Displayed)
            {
                closeNotification.Click();
            }
        }
    }
}
