require("dotenv").config();

const { selectors } = require("./constants.js"),
  { clickButton, getPageByUrl, inputText } = require("./utils/utils.js");

async function main() {
  await login();
}

async function login() {
  const page = await getPageByUrl("https://play.pokemonshowdown.com/"),
    { ACCOUNT_LOGIN_PASSWORD, ACCOUNT_LOGIN_USERNAME } = process.env,
    { consent, login, password, submit, username } = selectors;

  // TODO: Consent popup is not consistent, for now will just timeout if pop up is not shown.
  await page
    .waitForSelector(consent, { timeout: 15000 })
    .then(async () => clickButton(page, consent));

  await clickButton(page, login);
  await inputText(page, username, ACCOUNT_LOGIN_USERNAME);
  await clickButton(page, submit);
  await inputText(page, password, ACCOUNT_LOGIN_PASSWORD);
  await clickButton(page, submit);
  await page.waitForSelector(".username");
}

main();
