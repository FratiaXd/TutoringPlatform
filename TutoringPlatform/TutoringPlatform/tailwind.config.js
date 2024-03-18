/** @type {import('tailwindcss').Config} */
module.exports = {
    prefix: "t-",
    content: ["./../**/*.{razor,html,cshtml}",
        "./node_modules/flowbite/**/*.js"
    ],
  theme: {
    extend: {},
  },
    plugins: [
        require('flowbite/plugin')
    ],
}

