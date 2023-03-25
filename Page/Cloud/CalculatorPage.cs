using AngleSharp.Dom;
using Framework.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V108.Debugger;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Framework.Page.Cloud
{
    public class CalculatorPage : AbstractPage
    {
        public static By outerFrameLocator = By.XPath("//article[@id='cloud-site']//iframe");

        public static By innerFrameLocator = By.Id("myFrame");

        [FindsBy(How = How.XPath, Using = "//article[@id='cloud-site']//iframe")]
        private IWebElement outerFrame;
        //private IWebElement outerFrame => base.WaitAndFindElement(outerFrameLocator);

        [FindsBy(How = How.Id, Using = "myFrame")]
        private IWebElement innerFrame;
        //private IWebElement innerFrame => base.WaitAndFindElement(innerFrameLocator);

        [FindsBy(How = How.XPath, Using = "//div[@title='Compute Engine']")]
        private IWebElement computeEngineItem;

        [FindsBy(How = How.XPath, Using = "//form[@name='ComputeEngineForm']//label[contains(text(), 'Number of instances')]/following-sibling::input")]
        private IWebElement numberOfInstances;

        [FindsBy(How = How.XPath, Using = "//form[@name='ComputeEngineForm']//label[contains(text(), 'Operating System / Software')]/following-sibling::md-select")]
        private IWebElement operatingSystem;

        [FindsBy(How = How.XPath, Using = "//form[@name='ComputeEngineForm']//label[contains(text(), 'Provisioning model')]/following-sibling::md-select")]
        private IWebElement provisioningModel;

        [FindsBy(How = How.XPath, Using = "//form[@name='ComputeEngineForm']//label[contains(text(), 'Machine Family')]/following-sibling::md-select")]
        private IWebElement machineFamily;

        [FindsBy(How = How.XPath, Using = "//form[@name='ComputeEngineForm']//label[contains(text(), 'Series')]/following-sibling::md-select")]
        private IWebElement series;

        [FindsBy(How = How.XPath, Using = "//form[@name='ComputeEngineForm']//label[contains(text(), 'Machine type')]/following-sibling::md-select")]
        private IWebElement machineType;

        [FindsBy(How = How.XPath, Using = "//form[@name='ComputeEngineForm']//md-checkbox[@aria-label='Add GPUs']")]
        private IWebElement addGPUs;

        [FindsBy(How = How.XPath, Using = "//form[@name='ComputeEngineForm']//label[contains(text(), 'GPU type')]/following-sibling::md-select")]
        private IWebElement gpuType;

        [FindsBy(How = How.XPath, Using = "//form[@name='ComputeEngineForm']//label[contains(text(), 'Number of GPUs')]/following-sibling::md-select")]
        private IWebElement numberOfGPUs;

        [FindsBy(How = How.XPath, Using = "//form[@name='ComputeEngineForm']//label[contains(text(), 'Local SSD')]/following-sibling::md-select")]
        private IWebElement localSSD;

        [FindsBy(How = How.XPath, Using = "//form[@name='ComputeEngineForm']//label[contains(text(), 'Datacenter location')]/following-sibling::md-select")]
        private IWebElement dataCenterLocation;

        [FindsBy(How = How.XPath, Using = "//form[@name='ComputeEngineForm']//label[contains(text(), 'Committed usage')]/following-sibling::md-select")]
        private IWebElement commitedUsage;

        [FindsBy(How = How.XPath, Using = "//button[@ng-click='listingCtrl.addComputeServer(ComputeEngineForm);']")]
        private IWebElement addToEstimateButton;


        //private By selectOptionsFormLocator = By.XPath("//div[contains(@class, 'md-select-menu-container') and contains(@class,'md-active')]/md-select-menu/md-content/md-option/div[contains(@class,'md-text')]");
        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'md-select-menu-container') and contains(@class,'md-active')]/md-select-menu/md-content/md-option/div[contains(@class,'md-text')]")]
        private IList<IWebElement> selectOptionsForm;

        //private By selectOptionsGroupFormLocator = By.XPath("//div[contains(@class, 'md-select-menu-container') and contains(@class,'md-active')]/md-select-menu/md-content/md-optgroup/md-option/div[contains(@class,'md-text')]");
        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'md-select-menu-container') and contains(@class,'md-active')]/md-select-menu/md-content/md-optgroup/md-option/div[contains(@class,'md-text')]")]
        private IList<IWebElement> selectOptionsGroupForm;

        public CalculatorPage(IWebDriver driver) : base(driver)
        {
        }

        private void SelectOption(IWebElement selection, IList<IWebElement> options, string value)
        {
            if (selection.Text.Contains(value))
            {
                return;
            }
            MoveToElement(selection);
            selection.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(options[0]));
            foreach (IWebElement option in options)
            {
                if (option.Text.Contains(value))
                {
                    MoveToElement(option);
                    option.Click();
                    wait.Until(driver => !option.Displayed);
                    break;
                }
            }
        }

        public void SwitchToFrame()
        {
            SwitchFrame(outerFrameLocator);
            SwitchFrame(innerFrameLocator);
        }

        public EstimatePage ComputeEngine(Engine engine)
        {
            SwitchToFrame();
            EnterNumberOfInstances(engine.NumberOfInstances);
            SelectOperatingSystem(engine.OperatingSystem);
            SelectProvisioningModel(engine.ProvisioningModel);
            SelectMachineFamily(engine.MachineFamily);
            SelectSeries(engine.Series);
            SelectMachineType(engine.MachineType);
            SwitchAddGPUs(engine.AddGPUs);
            SelectGPUType(engine.GPUType);
            SelectNumberOfGPUs(engine.NumberOfGPUs);
            SelectLocalSSD(engine.LocalSSD);
            SelectDatacenterLocation(engine.DataCenterLocation);
            SelectCommitedUsage(engine.CommitedUsage);
            EstimatePage estimatePage = PressAddToEstimate();
            return estimatePage;
        }

        public void EnterNumberOfInstances(int number)
        {
            numberOfInstances.Click();
            numberOfInstances.SendKeys(number.ToString());
        }

        public void SelectOperatingSystem(string os)
        {
            SelectOption(operatingSystem, selectOptionsForm, os);
        }

        public void SelectProvisioningModel(string pm)
        {
            SelectOption(provisioningModel, selectOptionsForm, pm);
        }

        public void SelectMachineFamily(string mf)
        {
            SelectOption(machineFamily, selectOptionsForm, mf);
        }

        public void SelectSeries(string s)
        {
            SelectOption(series, selectOptionsForm, s);
        }

        public void SelectMachineType(string mt)
        {
            SelectOption(machineType, selectOptionsGroupForm, mt);
        }

        public void SwitchAddGPUs(bool enable)
        {
            bool isChecked = addGPUs.GetAttribute("aria-checked") == "true";
            if ((enable && !isChecked) || (!enable && isChecked))
            {
                addGPUs.Click();
            }
        }

        public void SelectGPUType(string gt)
        {
            SelectOption(gpuType, selectOptionsForm, gt);
        }

        public void SelectNumberOfGPUs(string num)
        {
            SelectOption(numberOfGPUs, selectOptionsForm, num);
        }

        public void SelectLocalSSD(string ls)
        {
            SelectOption(localSSD, selectOptionsForm, ls);
        }

        public void SelectDatacenterLocation(string dl)
        {
            SelectOption(dataCenterLocation, selectOptionsGroupForm, dl);
        }

        public void SelectCommitedUsage(string cu)
        {
            SelectOption(commitedUsage, selectOptionsForm, cu);
        }

        public EstimatePage PressAddToEstimate()
        {
            addToEstimateButton.Click();
            return new EstimatePage(driver);
        }
    }
}
