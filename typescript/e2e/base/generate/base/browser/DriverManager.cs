// <copyright file="DriverManager.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Tests
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.InteropServices;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.IE;

    public class DriverManager : IDisposable
    {
        public IWebDriver Driver { get; set; }

        public string DownloadPath { get; private set; }

        public void Dispose() => this.Stop();

        public void Start()
        {
            this.DownloadPath = Path.GetTempPath() + "SeleniumDownloads\\";

            if (!Directory.Exists(this.DownloadPath))
            {
                Directory.CreateDirectory(this.DownloadPath);
            }

            var options = new ChromeOptions();
            options.AddUserProfilePreference("download.default_directory", this.DownloadPath);
            options.AddUserProfilePreference("download.directory_upgrade", true);
            options.AddArgument("--start-maximized");
            options.AddUserProfilePreference("browser.cache.disk.enable", false);
            options.AddUserProfilePreference("browser.cache.memory.enable", false);
            options.AddUserProfilePreference("browser.cache.offline.enable", false);
            options.AddUserProfilePreference("network.http.use-cache", false);
            options.AddExcludedArgument("enable-automation");

            options.AddArgument("no-sandbox");

            var chromeWebDriver = Environment.GetEnvironmentVariable("ChromeWebDriver");

            var runningPath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);

            this.Driver = Directory.Exists(chromeWebDriver) ?
                new ChromeDriver(chromeWebDriver, options) :
                new ChromeDriver(runningPath, options);

            // TODO: lower timeouts
            this.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(5);
            this.Driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromMinutes(5);
        }

        public void Stop()
        {
            if (this.Driver == null)
            {
                return;
            }

            try
            {
                this.Driver.Close();
            }
            finally
            {
                try
                {
                    this.Driver.Quit();
                }
                finally
                {
                    try
                    {
                        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                        {
                            if (this.Driver is ChromeDriver)
                            {
                                try
                                {
                                    Process.Start("taskkill", "/F /IM chrome.exe")?.WaitForExit();
                                }
                                finally
                                {
                                    try
                                    {
                                        Process.Start("taskkill", "/F /IM chromedriver.exe")?.WaitForExit();
                                    }
                                    finally
                                    {
                                        Directory.Delete(this.DownloadPath, true);
                                    }
                                }
                            }
                            else if (this.Driver is FirefoxDriver)
                            {
                                Process.Start("taskkill", "/F /IM firefox.exe")?.WaitForExit();
                            }
                            else if (this.Driver is InternetExplorerDriver)
                            {
                                Process.Start("taskkill", "/F /IM iexplore.exe")?.WaitForExit();
                            }
                            else
                            {
                                throw new Exception("Can not stop driver of type " + this.Driver.GetType().Name);
                            }
                        }
                    }
                    finally
                    {
                        this.Driver = null;
                    }
                }
            }
        }
    }
}
