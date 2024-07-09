using Allure.NUnit;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechnicalAssessment.Pages;

namespace TechnicalAssessment
{
    public class Tests

    {

        private ChromeOptions GetChromeOptions()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--incognito");
            return options;
        }
      
        [SetUp]
        
        public void Setup()
        {
        }
        

        [Test]
        public void TestBuyTShirt()
        {
            //Create a new instance of selenium web driver
            IWebDriver driver = new ChromeDriver(GetChromeOptions());
            
            //Navigate to URL
            TestContext.WriteLine("Step 1: Saucedemo is launched in Incognito mode.");
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            
            //Maximaize chrome Window 
            driver.Manage().Window.Maximize();

            //POM Initialization
            LoginPage loginPage = new LoginPage(driver);

            // Log in
            TestContext.WriteLine("Step 2: Valid Credentials inputted and login button is clicked.");
            loginPage.Login("standard_user", "secret_sauce");
            if (loginPage.Dashboard())
            {
                TestContext.WriteLine("Step 3: The Dashboard is Displayed.");
            }
            else
            {
                TestContext.WriteLine("Error: The Dashboard is not displayed.");
                Assert.Fail("The Dashboard is not displayed.");
            }

            // Select a T-shirt
            TestContext.WriteLine("Step 4: A Product is selected.");
            loginPage.selectTShirt();
            if (loginPage.ProductDesription())
            {
                TestContext.WriteLine("Step 5: Product Details is displayed.");
            }
            else
            {
                TestContext.WriteLine("Error: Product description is not displayed.");
                Assert.Fail("Product description is not displayed.");
            }


            // Add to cart
            TestContext.WriteLine("Step 6: Add the selected T-shirt to the cart.");
            loginPage.ClickAddToCartButton();
            if (loginPage.AddedToCart())
            {
                TestContext.WriteLine("Step 7: T-shirt is added to the cart successfully.");
            }
            else
            {
                TestContext.WriteLine("Error: T-shirt was not added to cart.");
                Assert.Fail("T-shirt was not added to cart.");
            }

            // Go to cart
            TestContext.WriteLine("Step 8: Go to the cart.");
            loginPage.ClickCartButton();
            if (loginPage.CartScreen())
            {
                TestContext.WriteLine("Step 9: The cart page is displayed.");
            }
            else
            {
                TestContext.WriteLine("Error: Cart screen is not displayed.");
                Assert.Fail("Cart screen is not displayed.");
            }

            // Verify cart contents
            TestContext.WriteLine("Step 10: Verify the cart contents.");
            if (loginPage.ProductQuantity() && loginPage.ItemPrice() && loginPage.ItemName())
            {
                TestContext.WriteLine("Step 11: Cart contents are correct.");
            }
            else
            {
                TestContext.WriteLine("Error: Cart contents are incorrect.");
                Assert.Fail("Cart contents are incorrect.");
            }

            // Proceed to checkout
            TestContext.WriteLine("Step 12: Proceed to checkout.");
            loginPage.ClickCheckOut();
            if (loginPage.CheckOutScren())
            {
                TestContext.WriteLine("Step 13: Checkout screen is displayed.");
            }
            else
            {
                TestContext.WriteLine("Error: Checkout screen is not displayed.");
                Assert.Fail("Checkout screen is not displayed.");
            }

            // Verify Checkout Required Fields
            TestContext.WriteLine("Step 14: Enter checkout information (First name, Last name, Postal code).");
            loginPage.CheckOut("", "Doe", "1234");
            ClassicAssert.IsTrue(loginPage.FirstNameRequired(), "FirstName is Required error is not displayed.");

            driver.Navigate().Refresh();
            loginPage.CheckOut("John", "", "1234");
            bool lastNameIsRequiredErrorIsDisplayed = loginPage.LastNameRequired();

            driver.Navigate().Refresh();
            loginPage.CheckOut("John", "Doe", "");
            bool PostalCodeIsRequiredErrorIsDisplayed = loginPage.PostalCodeNameRequired();

            // Enter checkout information
            loginPage.CheckOut("John", "Doe", "1234");

            // Verify order summary and finish
            TestContext.WriteLine("Step 15: Verify order summary details.");

            if (loginPage.ShirtDetails() && loginPage.PaynentInformation() && loginPage.CheckOutPage() && loginPage.TotalAmount())
            {
                TestContext.WriteLine("Step 16: Order summary details are correct.");
            }
            else
            {
                TestContext.WriteLine("Error: Order summary details are incorrect.");
                Assert.Fail("Order summary details are incorrect.");
            }

            //Finish Order
            TestContext.WriteLine("Step 17: Complete the order by clicking Finish.");
            loginPage.ClickFinish();
            if (loginPage.OrderSuccessful())
            {
                TestContext.WriteLine("Step 18: Order confirmation is displayed, indicating a successful purchase.");
            }
            else
            {
                TestContext.WriteLine("Error: Order confirmation is not displayed.");
                Assert.Fail("Order confirmation is not displayed.");
            }
            loginPage.ClickBackToProduct();

            //Logout
            TestContext.WriteLine("Step 19: Logout from the application.");
            loginPage.ClickMenuIcon();

            bool logOutBtnIsDisplayed = loginPage.LogoutButtonDisplayed();

            // Wait before checking the dashboard
            Thread.Sleep(2000); // Wait for 5 seconds

            loginPage.ClickLogout();
            if (loginPage.LoginScreen())
            {
                TestContext.WriteLine("Step 20: User is successfully logged out and redirected to the login page.");
            }
            else
            {
                TestContext.WriteLine("Error: Logout was not successful.");
                Assert.Fail("Logout was not successful.");
            }

            driver.Quit();
        }
    }
} 
