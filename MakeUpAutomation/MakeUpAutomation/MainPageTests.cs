using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Xml.Linq;

namespace MakeUpAutomation
{
    [TestClass]
    public class MainPageTests
    {
        private ChromeDriver driver;
        private Actions action;

        private By popUpClose = By.CssSelector("#popup__window > .popup-close");
        private By buttonBrands = By.XPath("//a[contains(text(),'Бренди')]");
        private By buttonL = By.XPath("//li[contains(.,'L')]");
        private By itemLamelProfessionalLip = By.XPath("//a[contains(text(),'Lamel Professional')]");
        private By hoverSliderLipLamelProfessional = By.XPath("//a[contains(text(),'Lamel Professional Lipliner')]");
        private By buttonBuyItem = By.CssSelector(".active .button");
        private By itemInBasket = By.CssSelector(".active .button");

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            action = new Actions(driver);
            driver.Navigate().GoToUrl("https://makeup.com.ua/ua/");

        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }

        [TestMethod]
        public void OpenLinkBrands()
        {

            driver.FindElement(popUpClose).Click();

            driver.FindElement(buttonBrands).Click();

            driver.FindElement(buttonL).Click();

            driver.FindElement(itemLamelProfessionalLip).Click();

            action.MoveToElement(driver.FindElement(hoverSliderLipLamelProfessional)).Perform();

            Assert.IsNotNull(buttonBuyItem);

            driver.FindElement(buttonBuyItem).Click();

            Assert.IsNotNull(itemLamelProfessionalLip);
        }
    }
}
