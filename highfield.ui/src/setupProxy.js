const { createProxyMiddleware } = require('http-proxy-middleware');

const context = [
    "/users",
];

module.exports = function (app) {
    const appProxy = createProxyMiddleware(context, {
        target: 'http://localhost:53056',
        secure: false
    });

    app.use(appProxy);
};
