module.exports = {
    content: [
        './Pages/**/*.cshtml',
        './Views/**/*.cshtml',
        './Areas/Identity/Pages/Views/**/*.cshtml'
    ],
    theme: {
        extend: {},
    },
    plugins: [],
}

const withMT = require("@material-tailwind/html/utils/withMT");


module.exports = withMT({
    content: [
        './Pages/**/*.cshtml',
        './Views/**/*.cshtml',
        './Areas/Identity/Pages/Views/**/*.cshtml'],
    theme: {
        extend: {},
    },
    plugins: [],
});