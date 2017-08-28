using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEL.ro_Testing {
    class HomePage {
        private IWebDriver driver; 

        [FindsBy(How = How.CssSelector, Using = "head title")]
        private IWebElement title {set; get;}

        [FindsBy(How = How.CssSelector, Using = "#logo_head>img")]
        private IWebElement logo {set; get;}

        [FindsBy(How = How.CssSelector, Using = ".titlebar div.close>a[onclick='hide_retinute();clear_lastaction();']")]
        private IWebElement closeNotification { set; get; }

        [FindsBy(How = How.CssSelector, Using = ".categ_name.a1")]
        private IList<IWebElement> leftMenuItemsList { set; get; }

        [FindsBy(How = How.XPath, Using = ".//div[@id='MenuLeft']/div[1]/div[8]/div[2]/div/div/div/a/span")]
        private IList<IWebElement> submenuItemsList { set; get; }

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public String getTitle()
        {
            String title = driver.Title;
            return title;
        }

        //- Verify that logo is displayed

        public bool LogoDisplayed()
        {
            return logo.Displayed;
        }

        // - If notification is visible click on it to disappear

        public void CloseNotification()
        {
            if (closeNotification.Displayed)
            {
                closeNotification.Click();
            }
        }

        //Click on the 8th input from the left menu and then on the third element from that menu

        public void ClickOnSelectedLeftMenuItem(int index)
        {
            leftMenuItemsList[index].Click();
        }

        public void ClickOnSelectedSubmenuItem(int index)
        {
            
            submenuItemsList[index].Click();

        }

        public String GetSelectedSubmenuItemName(int index)
        {
            String selectedSubmenuItemName = submenuItemsList[index].Text;
            return selectedSubmenuItemName;
        }
       
    }
}
