async function clickButton(page, selector) {
  await page.waitForSelector(selector);
  await page.click(selector);
}

module.exports = {
  clickButton,
};
