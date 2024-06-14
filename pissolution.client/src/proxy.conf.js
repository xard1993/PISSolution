const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `http://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
    env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'https://localhost:7208';

const PROXY_CONFIG = [
  {
    context: [
      "/api/property",
    ],
    target,
    secure: false
  }
]

module.exports = PROXY_CONFIG;
