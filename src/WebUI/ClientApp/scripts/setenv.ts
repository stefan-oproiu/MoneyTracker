const { writeFile } = require('fs');
const { argv } = require('yargs');

require('dotenv').config();

const environment = argv.environment;
const isProduction = environment === 'prod';
const targetPath = isProduction
   ? `./src/environments/environment.prod.ts`
   : `./src/environments/environment.ts`;

const redirectUri = '`${window.location.origin}/auth-callback`';

const environmentFileContent = `
export const environment = {
  production: ${isProduction},
  apiBaseUrl: 'api',
  authConfig: {
    domain: '${process.env.AUTH0_DOMAIN}',
    clientId: '${process.env.AUTH0_CLIENT_ID}',
    redirectUri: ${redirectUri},
    audience: '${process.env.AUTH0_AUDIENCE}',
  }
};
`;

writeFile(targetPath, environmentFileContent, function (err: unknown) {
   if (err) {
      console.log(err);
      process.exit(1);
   }
   console.log(`Wrote variables to ${targetPath}`);
   process.exit(0);
})
