const puppeteer = require("puppeteer");

async function getPageByUrl(url) {
  const browser = await puppeteer.launch({ headless: false, args: ["--start-maximized"] }),
    [page] = await browser.pages();

  await page.setViewport({ width: 1366, height: 768 });
  await page.goto(url);

  return page;
}

module.exports = {
  getPageByUrl,
};
