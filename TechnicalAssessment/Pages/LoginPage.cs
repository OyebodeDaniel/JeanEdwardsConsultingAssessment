using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalAssessment.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;

        public LoginPage(IWebDriver driver )
        {
            this.driver = driver;
        }
        
        IWebElement loginScreen => driver.FindElement(By.XPath("//div[@id='login_button_container'] //div[@class = 'login-box']"));
        IWebElement userNameField => driver.FindElement(By.XPath("//input[@id='user-name']"));
        IWebElement passwordField => driver.FindElement(By.XPath("//input[@id='password']"));
        IWebElement btnLogin => driver.FindElement(By.XPath("//input[@id='login-button']"));
        IWebElement dashboardScreen => driver.FindElement(By.XPath("//span[contains(text(),'Products')]"));
        IWebElement tShirt => driver.FindElement(By.XPath("//a[@id='item_1_img_link']"));
        IWebElement productDescription => driver.FindElement(By.XPath("//div [@data-test = 'inventory-item-desc']"));
        IWebElement btnAddToCart => driver.FindElement(By.XPath("//button[@id='add-to-cart']"));
        IWebElement addedToCart => driver.FindElement(By.XPath("//span[contains(text(),'1')]"));
        IWebElement btnCart => driver.FindElement(By.XPath("//a[@class='shopping_cart_link']"));
        IWebElement cartScreen => driver.FindElement(By.XPath("//span[contains(text(),'Your Cart')]"));
        IWebElement productQuantity => driver.FindElement(By.XPath("//div[@class='cart_quantity']"));
        IWebElement itemPrice => driver.FindElement(By.XPath("//div[@class='inventory_item_price']"));
        IWebElement itemName => driver.FindElement(By.XPath("//div[@class='inventory_item_name']"));
        IWebElement btnCheckOut => driver.FindElement(By.XPath("//button[@id='checkout']"));
        IWebElement checkOutScreen => driver.FindElement(By.XPath("//span[contains(text(),'Checkout: Your Information')]"));
        IWebElement errorFirstName => driver.FindElement(By.XPath("//h3[normalize-space()='Error: First Name is required']"));
        IWebElement errorLastName => driver.FindElement(By.XPath("//h3[normalize-space()='Error: Last Name is required']"));
        IWebElement errorPostalCode => driver.FindElement(By.XPath("//h3[normalize-space()='Error: Postal Code is required']"));
        IWebElement firstNameField => driver.FindElement(By.XPath("//input[@id='first-name']"));
        IWebElement LastNameField => driver.FindElement(By.XPath("//input[@id='last-name']"));
        IWebElement postalCodeField => driver.FindElement(By.XPath("//input[@id='postal-code']"));
        IWebElement btnContinue => driver.FindElement(By.XPath("//input[@id='continue']"));
        IWebElement tShirtDetails => driver.FindElement(By.XPath("//div[@class='cart_item']"));
        IWebElement paymentInformation => driver.FindElement(By.XPath("//div[normalize-space()='Payment Information:']"));
        IWebElement checkOutPage => driver.FindElement(By.XPath("//div[normalize-space()='Payment Information:']"));
        IWebElement totalAmount => driver.FindElement(By.XPath("//div[@class='summary_total_label']"));
        IWebElement btnFinish => driver.FindElement(By.XPath("//button[@id='finish']"));
        IWebElement orderSuccessful => driver.FindElement(By.XPath("//h2[normalize-space()='Thank you for your order!']"));
        IWebElement btnBackToProducts => driver.FindElement(By.XPath("//button[@id='back-to-products']"));
        IWebElement menuIcon => driver.FindElement(By.XPath("//button[@id='react-burger-menu-btn']"));
        IWebElement btnLogout => driver.FindElement(By.XPath("//div[@aria-hidden = 'false'] //a[@id = 'logout_sidebar_link']"));
        IWebElement btnResetAppState => driver.FindElement(By.XPath("//a[@id='reset_sidebar_link']"));
        IWebElement btnClose => driver.FindElement(By.XPath("//button[@id='react-burger-cross-btn']"));

        
        public void Login(string username, string password)
        {
            userNameField.Click();
            userNameField.Clear();
            userNameField.SendKeys(username);

            passwordField.Click();
            passwordField.Clear();
            passwordField.SendKeys(password);

            btnLogin.Click();
        }


        public bool LoginScreen()
        {
            return loginScreen.Displayed;
        }

        public bool Dashboard()
        {
            return dashboardScreen.Displayed;
        }

        public bool LogoutButtonDisplayed()
        {
            return btnLogout.Displayed;
        }

        public void selectTShirt()
        {
            tShirt.Click();
        }

        public bool ProductDesription()
        {
            return productDescription.Displayed;
        }

        public void ClickAddToCartButton()
        {
            btnAddToCart.Click();
        }
        public bool AddedToCart()
        {
            return addedToCart.Displayed;
        }
        public void ClickCartButton()
        {
            btnCart.Click();
        }
        public bool CartScreen()
        {
            return cartScreen.Displayed;
        }
        public bool ProductQuantity()
        {
            return productQuantity.Displayed;
        }
        public bool ItemPrice()
        {
            return itemPrice.Displayed;
        }
        public bool ItemName()
        {
            return itemName.Displayed;
        }
        public void ClickCheckOut()
        {
            btnCheckOut.Click();
        }
        public bool CheckOutScren()
        {
            return checkOutScreen.Displayed;
        }
        public bool FirstNameRequired()
        {
            return errorFirstName.Displayed;
        }
        public bool LastNameRequired()
        {
            return errorLastName.Displayed;
        }
        public bool PostalCodeNameRequired()
        {
            return errorPostalCode.Displayed;
        }
        public void CheckOut(string firstname, string lastname, string postalcode)
        {
            firstNameField.Click();
            firstNameField.Clear();
            firstNameField.SendKeys(firstname);

            LastNameField.Click();
            LastNameField.Clear();
            LastNameField.SendKeys(lastname);

            postalCodeField.Click();
            postalCodeField.Clear();
            postalCodeField.SendKeys(postalcode);

            btnContinue.Click();
        }
        public bool ShirtDetails()
        {
            return tShirtDetails.Displayed;
        }
        public bool PaynentInformation()
        {
            return paymentInformation.Displayed;
        }
        public bool CheckOutPage()
        {
            return checkOutPage.Displayed;
        }
        public bool TotalAmount()
        {
            return totalAmount.Displayed;
        }
        public void ClickFinish()
        {
            btnFinish.Click();
        }
        public bool OrderSuccessful()
        {
            return orderSuccessful.Displayed;
        }
        public void ClickBackToProduct()
        {
            btnBackToProducts.Click();
        }
        public void ClickMenuIcon()
        {
            menuIcon.Click();
        }
        public void ClickLogout()
        {
            btnLogout.Click();
        }
    }
}
