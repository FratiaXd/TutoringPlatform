/** @type {import('tailwindcss').Config} */
module.exports = {
    prefix: "t-",
    content: ["./../**/*.{razor,html,cshtml}",
        "./node_modules/flowbite/**/*.js"
    ],
  theme: {
      extend: {
          spacing: {
              '1': '0.25rem',
              '2': '0.5rem',
              '3': '0.75rem',
              '5': '1.25rem',
              '6': '1.5rem',
              '7': '1.75rem',
              '8': '2rem',
              '9': '2.25rem',
              '10': '2.5rem',
              '11': '2.75rem',
              '40': '10rem',
              '42': '10.5rem',
              '44': '11rem',
              '50': '12.5rem',
              '64': '16rem',
              '80': '20rem',
              '81': '20.25rem',
              '82': '20.5rem',
              '83': '20.75rem',
              '84': '21rem',
              '85': '21.25rem',
              '86': '21.5rem',
              '87': '21.75rem',
              '88': '22rem',
              '89': '22.25rem',
              '96': '24rem',
              '112': '28rem',
              '128': '32rem',
          },
      },
  },
    plugins: [
        require('flowbite/plugin')
    ],
}

