module.exports = {
    content: [
        './Pages/**/*.cshtml',
        './Views/**/*.cshtml',
        './Areas/Identity/Pages/Account/**/*.cshtml',
        './Areas/Identity/Pages/Views/Shared/**/*.cshtml',
        './node_modules/flowbite/**/*.js',
        
    ],
    theme: {
        extend: {},
    },
    plugins: [
        require('flowbite/plugin')
    ],
}

