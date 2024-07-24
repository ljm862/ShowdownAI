async function inputText(page, selector, text) {
  await page.waitForSelector(selector);
  await page.type(selector, text);
}

module.exports = {
  inputText,
};
