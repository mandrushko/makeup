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

        Dictionary<string, By> paths = new Dictionary<string, By>();


        //    List<By> paths = new()
        //    {
        //    By.CssSelector("#popup__window > .popup-close"),
        //    By.XPath("//a[contains(text(),'Бренди')]"),
        //    By.XPath("//li[contains(.,'L')]"),
        //    By.XPath("//a[contains(text(),'Lamel Professional')]"),
        //    By.XPath("//a[contains(text(),'Lamel Professional Lipliner')]"),
        //    By.CssSelector(".active .button"),
        //    By.CssSelector(".active .button")
        //};



        //private By popUpClose = By.CssSelector("#popup__window > .popup-close");
        //private By buttonBrands = By.XPath("//a[contains(text(),'Бренди')]");
        //private By buttonL = By.XPath("//li[contains(.,'L')]");
        //private By itemLamelProfessionalLip = By.XPath("//a[contains(text(),'Lamel Professional')]");
        //private By hoverSliderLipLamelProfessional = By.XPath("//a[contains(text(),'Lamel Professional Lipliner')]");
        //private By buttonBuyItem = By.CssSelector(".active .button");
        //private By itemInBasket = By.CssSelector(".active .button");

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            action = new Actions(driver);
            driver.Navigate().GoToUrl("https://makeup.com.ua/ua/");
            paths.Add("popUpClose", By.CssSelector("#popup__window > .popup-close"));
            paths.Add("buttonBrands", By.XPath("//a[contains(text(),'Бренди')]"));
            paths.Add("buttonnLetterL", By.XPath("//li[contains(.,'L')]"));
            paths.Add("itemLamelMakeUp", By.XPath("//a[contains(text(),'LAMEL Make Up')]"));
            paths.Add("hoverSliderLipLamelMakeUP", By.XPath("//a[text()='LAMEL Make Up Long Lasting Gel Liner']"));
            paths.Add("buttonBuyItem", By.CssSelector(".active .button"));
            paths.Add("itemInBasket", By.CssSelector(".active .button"));
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }

        [TestMethod]
        public void OpenLinkBrands()
        {

            driver.FindElement(paths["popUpClose"]).Click();

            driver.FindElement(paths["buttonBrands"]).Click();

            driver.FindElement(paths["buttonnLetterL"]).Click();

            driver.FindElement(paths["itemLamelMakeUp"]).Click();

            action.MoveToElement(driver.FindElement(paths["hoverSliderLipLamelMakeUP"])).Perform();

            Assert.IsNotNull(paths["buttonBuyItem"]);

            driver.FindElement(paths["buttonBuyItem"]).Click();

            Assert.IsNotNull(paths["itemInBasket"]);
        }
    }
}
