using Microsoft.Playwright;

using var playwright = await Playwright.CreateAsync();
await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
{
    Headless = false
});

var context = await browser.NewContextAsync();
var page = await context.NewPageAsync();

// Go to login page
await page.GotoAsync("https://the-internet.herokuapp.com/login");

// Fill credentials
await page.FillAsync("input#username", "tomsmith");
await page.FillAsync("input#password", "SuperSecretPassword!");

// Click login
await page.ClickAsync("button[type='submit']");

// Wait for success message
await page.WaitForSelectorAsync("div.flash.success");
Console.WriteLine("Login successful!");

await Task.Delay(5000);
await browser.CloseAsync();