using OpenQA.Selenium;

namespace Tests.ApplicationTests
{
    using System.Reflection;
    using Components;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Linq;
    using Xunit;
    using Allors;

    [Collection("Test collection")]
    public class AutoTest : Test
    {
        private readonly MethodInfo[] navigateTos;

        public AutoTest(TestFixture fixture)
            : base(fixture)
        {
            this.navigateTos = this.Sidenav.GetType()
                .GetMethods()
                .Where(v => v.Name.StartsWith("NavigateTo"))
                .ToArray();
        }

        [Fact]
        public async void List()
        {
            this.Login();

            foreach (var navigateTo in this.navigateTos)
            {
                var page = (Component)navigateTo.Invoke(this.Sidenav, null);
            }
        }

        [Fact]
        public async void CreateDialog()
        {
            this.Login();

            foreach (var navigateTo in this.navigateTos)
            {
                var page = (Component)navigateTo.Invoke(this.Sidenav, null);

                var createMethod = page.GetType().GetMethods().FirstOrDefault(v => v.Name.StartsWith("Create"));
                var dialog = (Component)createMethod?.Invoke(page, null);

                Cancel(dialog);
            }
        }

        [Fact]
        public async void EditDialog()
        {
            this.Login();

            foreach (var navigateTo in this.navigateTos)
            {
                var page = (Component)navigateTo.Invoke(this.Sidenav, null);

                var tableProperty = page.GetType().GetProperties().FirstOrDefault(v => v.PropertyType == typeof(MatTable));
                if (tableProperty != null)
                {
                    var table = (MatTable)tableProperty?.GetGetMethod().Invoke(page, null);
                    var action = table.Actions.FirstOrDefault(v => v.Equals("edit"));

                    if (action != null)
                    {
                        var objects = this.Session.Instantiate(table.ObjectIds);
                        foreach (IObject @object in objects)
                        {
                            table.Action(@object, action);

                            this.Driver.WaitForAngular();
                            var dialogElement = this.Driver.FindElement(By.CssSelector("mat-dialog-container ng-component[data-test-scope]"));
                            var testScope = dialogElement.GetAttribute("data-test-scope");
                            var type = Assembly.GetExecutingAssembly().GetTypes().First(v => v.Name.Equals(testScope));
                            var dialog = (Component)Activator.CreateInstance(type, this.Driver, null);

                            Cancel(dialog);
                        }
                    }
                }
            }
        }

        [Fact]
        public async void OverviewPage()
        {
            this.Login();

            foreach (var navigateTo in this.navigateTos)
            {
                var page = (Component)navigateTo.Invoke(this.Sidenav, null);

                var tableProperty = page.GetType().GetProperties().FirstOrDefault(v => v.PropertyType == typeof(MatTable));
                if (tableProperty != null)
                {
                    var table = (MatTable)tableProperty?.GetGetMethod().Invoke(page, null);
                    var action = table.Actions.FirstOrDefault(v => v.Equals("overview"));

                    if (action != null)
                    {
                        var objects = this.Session.Instantiate(table.ObjectIds);
                        foreach (IObject @object in objects)
                        {
                            table.Action(@object, action);
                            this.Driver.Navigate().Back();
                        }
                    }
                }
            }
        }

        private static void Cancel(Component dialog)
        {
            var cancelProperty = dialog?.GetType().GetProperties().FirstOrDefault(v => v.Name.Equals("cancel", StringComparison.InvariantCultureIgnoreCase));
            dynamic cancel = cancelProperty?.GetGetMethod().Invoke(dialog, null);

            cancel?.Click();
        }
    }
}
